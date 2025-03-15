using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;
using ChartSeries = System.Windows.Forms.DataVisualization.Charting.Series;

namespace Lab_1
{
    public partial class App : Form
    {
        Reader Reader { get; } = new Reader();
        List<double> Vyborka { get; set; } = new List<double>();
        List<VarRow> VarRows { get; set; } = new List<VarRow>();
        List<VarClassRow> VarClassRows { get; set; } = new List<VarClassRow>();
        int N { get; set; } = 0;
        int M { get; set; } = 0;
        double H { get; set; } = 0.0;
        double B { get; set; } = 0.0;
        double a { get; set; } = 0.0;
        double b { get; set; } = 0.0;
        bool IsProgramicChange { get; set; } = false;
        List<DataTable> Tables { get; set; } = new List<DataTable>();
        List<Chart> Charts { get; set; } = new List<Chart>();
        public App()
        {
            InitializeComponent();
            ReadyTables();
            Prepare();
        }      
        void ReadyTables()
        {           
            DataTable var = new DataTable();

            var.Columns.Add("Номер", typeof(int));
            var.Columns.Add("Значення", typeof(double));
            var.Columns.Add("Частота", typeof(int));
            var.Columns.Add("Відносна частота", typeof(double));
            var.Columns.Add("Емпірична функція", typeof(double));

            varTable.DataSource = var;
            Tables.Add(var);

            varTable.RowHeadersVisible = false;
            varTable.CellFormatting += DataGridView_CellFormatting;           
           
            DataTable varClass = new DataTable();

            varClass.Columns.Add("Номер", typeof(int));
            varClass.Columns.Add("Межі", typeof(string));
            varClass.Columns.Add("Частота", typeof(int));
            varClass.Columns.Add("Відносна частота", typeof(double));
            varClass.Columns.Add("Емпірична функція", typeof(double));

            varClassTable.DataSource = varClass;
            Tables.Add(varClass);

            varClassTable.RowHeadersVisible = false;
            varClassTable.CellFormatting += DataGridView_CellFormatting;            
            
            DataTable stats = new DataTable();

            stats.Columns.Add("Х-ка", typeof(string));
            stats.Columns.Add("Оцінка", typeof(double));
            stats.Columns.Add("Середн квадрат відхил", typeof(double));
            stats.Columns.Add("Довірч інтервал 95%", typeof(string));

            statsTable.DataSource = stats;
            Tables.Add(stats);

            statsTable.RowHeadersVisible = false;
            statsTable.CellFormatting += StatsTableCellsFormat;    
            
            
        }       
        void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            var column = grid.Columns[e.ColumnIndex];
            if ((column.Name == "Емпірична функція" || column.Name == "Відносна частота") && e.Value != null)
            {
                e.Value = string.Format("{0:F4}", e.Value);
                e.FormattingApplied = true;
            }
        }
        void addFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"..\Визуал\Лаб 1";
                openFileDialog.Filter = "Text files (*.txt)|*.txt|Data files (*.dat)|*.dat";
                openFileDialog.Title = "Выберите файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    var vyborkaZCount = Reader.GetFromFile(openFileDialog.FileName, out int n);
                    N = n;                   
                    Generate(vyborkaZCount);
                }
                else
                {
                    tablesStatusLabel.Text = "File not added";
                }
            }
        }
        void Generate(List<(double Value, int Count)> vyborkaZCount)
        {            
            VarRows.Clear();
            VarClassRows.Clear();
            Vyborka.Clear();

            label1.Text = "N = " + Convert.ToString(N);
            
            GenerateVar(vyborkaZCount);
            GenerateVyborka();
            GenerateVarClass();
                        
            FillTable();
           
            GenerateGraphic();
            GenerateGraphicEmpiric();
            GeneratePaper();
            GenerateAnomaly();
        }
        void GenerateVar(List<(double Value, int Count)> vyborkaZCount)
        {
            VarClassRows.Clear();
            
            double empiric = 0.0, p = 0.0;
            foreach (var item in vyborkaZCount)
            {
                p = (double)item.Count / N;
                empiric += p;

                VarRows.Add(new VarRow(item.Value, item.Count, p, empiric));
            }
        }
        void GenerateVyborka()
        {
            Vyborka.Clear();
            
            Vyborka = VarRows.SelectMany
                (item => Enumerable.Repeat(item.Value, item.Count)).ToList();
        }
        void GenerateVarClass()
        {         
            M = (int)(1 + 3.32 * Math.Log10(N));
            M += M % 2 is 1 ? 0 : 1; 

            IsProgramicChange = true;
            classAmountPicker.Value = M;
            IsProgramicChange = false;

            GenerateMVarClasses();
        }
        void GenerateMVarClasses()
        {
            VarClassRows.Clear();
            
            H = (VarRows[^1].Value - VarRows[0].Value) / M;

            double lower = VarRows[0].Value, upper = lower + H;

            for (int i = 0; i < M; i++)
            {
                VarClassRows.Add(new VarClassRow(lower, upper));
                lower = upper;
                upper += H;
            }

            int classCount = 0;
            double classEmpiric = 0.0;

            foreach (var varclass in VarClassRows)
            {
                foreach (var var in VarRows)
                {                    
                    if (var.Value >= varclass.Lower && varclass.Upper - var.Value > 10e-7)
                    {
                        classCount += var.Count;
                    }
                }

                if (varclass == VarClassRows[^1])
                {
                    classCount += VarRows[^1].Count;
                }

                varclass.Count = classCount;
                varclass.RelativeCount = (double)classCount / N;

                classEmpiric += (double)classCount / N;
                varclass.EmpiricFuncValue = classEmpiric;

                classCount = 0;
            }
        }        
        void FillTable()
        {
            FillVarTable();
            FillVarClassTable();
            GetStats();
            Fix();
        }
        void FillVarTable()
        {          
            Tables[0].Rows.Clear();

            int counter = 1;
            foreach (var item in VarRows)
            {
                Tables[0].Rows.Add(counter++, item.Value, item.Count, item.RelativeCount, item.EmpiricFuncValue);
            }
        }
        void FillVarClassTable()
        {            
            Tables[1].Rows.Clear();

            int counter = 1;
            foreach (var item in VarClassRows)
            {
                Tables[1].Rows.Add(counter++, $"[ {item.Lower:F4} ; {item.Upper:F4} )", item.Count, item.RelativeCount, item.EmpiricFuncValue);
            }
        }
        void Fix()
        {
            varTable.Columns["Номер"].Width = 80;
            varTable.Columns["Частота"].Width = 100;
            varTable.Columns["Відносна частота"].Width = 100;
            varTable.Columns["Емпірична функція"].Width = 100;

            varClassTable.Columns["Номер"].Width = 80;
            varClassTable.Columns["Частота"].Width = 100;
            varClassTable.Columns["Відносна частота"].Width = 100;
            varClassTable.Columns["Емпірична функція"].Width = 100;           
        }        
        void classAmountPicker_ValueChanged(object sender, EventArgs e)
        {
            if (classAmountPicker.Value == 0 || VarRows.Count == 0) return;           
            if (IsProgramicChange) return;
            M = (int)classAmountPicker.Value;
            GenerateMVarClasses();
            FillVarClassTable();
            Fix();
            GenerateGraphic();
        }        
        void Prepare()
        {            
            Chart chart = new Chart();
            chart.Name = "graph1";
            chart.Size = new Size(800, 600);
            chart.Location = new Point(10, 20);

            graphics.Controls.Add(chart);
            Charts.Add(chart);

            chart.ChartAreas.Add(new ChartArea("MainArea"));

            ChartSeries barSeries = new ChartSeries("Frequency");
            barSeries.ChartType = SeriesChartType.Column;
            barSeries["PointWidth"] = "1.0";
            barSeries.BorderWidth = 2;
            barSeries.BorderColor = Color.Black;
            Charts[0].Series.Add(barSeries);

            ChartSeries lineSeries = new ChartSeries("Line");
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.Color = Color.Red;
            lineSeries.BorderWidth = 2;
            Charts[0].Series.Add(lineSeries);
            
            Chart chart1 = new Chart();
            chart1.Name = "graph2";
            chart1.Size = new Size(800, 600);
            chart1.Location = new Point(820, 10);

            graphics.Controls.Add(chart1);
            Charts.Add(chart1);

            chart1.ChartAreas.Add(new ChartArea("MainArea"));

            ChartSeries stepLineSeries = new ChartSeries("StepLine");
            stepLineSeries.ChartType = SeriesChartType.StepLine;
            stepLineSeries.Color = Color.Red;
            stepLineSeries.BorderWidth = 2;
            Charts[1].Series.Add(stepLineSeries);
            
            Chart chart2 = new Chart();
            chart2.Name = "graph3";
            chart2.Size = new Size(800, 600);
            chart2.Location = new Point(820, 10);

            stats.Controls.Add(chart2);
            Charts.Add(chart2);

            chart2.ChartAreas.Add(new ChartArea("MainArea"));

            ChartSeries paperSeries = new ChartSeries("Points");
            paperSeries.ChartType = SeriesChartType.Point;
            paperSeries.Color = Color.Red;
            paperSeries.BorderWidth = 2;
            Charts[2].Series.Add(paperSeries);
            
            Chart chart3 = new Chart();
            chart3.Name = "graph4";
            chart3.Size = new Size(800, 600);
            chart3.Location = new Point(10, 70);

            anomaly.Controls.Add(chart3);
            Charts.Add(chart3);

            chart3.ChartAreas.Add(new ChartArea("MainArea"));

            ChartSeries pointSeries = new ChartSeries("Dots");
            pointSeries.ChartType = SeriesChartType.Point;
            pointSeries.LabelBorderWidth = 3;
            pointSeries.BorderColor = Color.Black;
            Charts[3].Series.Add(pointSeries);

            ChartSeries lineASeries = new ChartSeries("LineA");
            lineASeries.ChartType = SeriesChartType.Line;
            lineASeries.Color = Color.Red;
            lineASeries.BorderWidth = 2;
            Charts[3].Series.Add(lineASeries);

            ChartSeries lineBSeries = new ChartSeries("LineB");
            lineBSeries.ChartType = SeriesChartType.Line;
            lineBSeries.Color = Color.Red;
            lineBSeries.BorderWidth = 2;
            Charts[3].Series.Add(lineBSeries);
        }
        void GenerateGraphic()
        {           
            B = Statistics.StandardDeviation(Vyborka) * Math.Pow(N, -1.0 / 5.0);
            IsProgramicChange = true;
            BTextBox.Text = Convert.ToString(B);
            IsProgramicChange = false;

            GenerateGraphicwithB();
        }
        void GenerateGraphicwithB()
        {
            var histX = VarClassRows.Select(item => (item.Upper + item.Lower) / 2).ToList();
            var histY = VarClassRows.Select(item => item.RelativeCount).ToList();

            var kernelX = VarRows.Select(item => item.Value).ToList();
            var kernelY = KDE();

            ChartSeries barSeries = Charts[0].Series[0];
            barSeries.Points.Clear();

            for (int i = 0; i < histX.Count; i++)
            {
                barSeries.Points.AddXY(histX[i], histY[i]);
            }

            ChartSeries lineSeries = Charts[0].Series[1];
            lineSeries.Points.Clear();

            for (int i = 0; i < kernelX.Count; i++)
            {
                lineSeries.Points.AddXY(kernelX[i], kernelY[i]);
            }
        }
        List<double> KDE()
        {
            return VarRows.Select(var => Vyborka.Select(d => Kernel((var.Value - d) / B)).Sum() / (N * B) * H).ToList();
        }              
        double Kernel(double x)
        {            
            return (1.0 / Math.Sqrt(2 * Math.PI)) * Math.Exp(-0.5 * x * x);
        }
        void GenerateGraphicEmpiric()
        {
            var empiricX = VarRows.Select(item => item.Value).ToList();
            var empiricY = VarRows.Select(item => item.EmpiricFuncValue).ToList();            

            ChartSeries stepLineSeries = Charts[1].Series[0];
            stepLineSeries.Points.Clear();

            for (int i = 0; i < empiricX.Count; i++)
            {
                stepLineSeries.Points.AddXY(empiricX[i], empiricY[i]);
            }

        }
        void BTextBox_TextChanged(object sender, EventArgs e)
        {
            if (VarRows.Count == 0) return;
            if (IsProgramicChange) return;
            if (double.TryParse(BTextBox.Text, out double b))
            {
                B = b;
                GenerateGraphicwithB();
            }
            else graphicsStatusLabel.Text = "Invalid B";
        }       
        void GetStats()
        {
            double mean = Statistics.Mean(Vyborka);
            double median = Statistics.Median(Vyborka);
            double stdDev = Statistics.StandardDeviation(Vyborka);
            double skewness = Statistics.Skewness(Vyborka);
            double kurtosis = Statistics.Kurtosis(Vyborka);
            double min = Statistics.Minimum(Vyborka);
            double max = Statistics.Maximum(Vyborka);

            double u = 1.96;
            Tables[2].Rows.Clear();
                
            double meanStdDev = stdDev / Math.Sqrt(N);

            double meanLower = mean - u * meanStdDev;
            double meanUpper = mean + u * meanStdDev;

            Tables[2].Rows.Add("Середнє арифм", mean, meanStdDev, $"[ {meanLower:F4} ; {meanUpper:F4} ]");            

            int medianLowerIndex = (int)(N / 2 - u * Math.Sqrt(N) / 2);
            int medianUpperIndex = (int)(N / 2 + u * Math.Sqrt(N) / 2 + 1);

            Tables[2].Rows.Add("Медіана", median, DBNull.Value, $"[ {Vyborka[medianLowerIndex]:F4} ; {Vyborka[medianUpperIndex]:F4} ]");            

            double stdDevStdDev = stdDev / Math.Sqrt(2 * N);

            double stdDevLower = stdDev - u * stdDevStdDev;
            double stdDevUpper = stdDev + u * stdDevStdDev;

            Tables[2].Rows.Add("Середн квадрат відхил", stdDev, stdDevStdDev, $"[ {stdDevLower:F4} ; {stdDevUpper:F4} ]");            

            double skewStdDev = Math.Sqrt(6 * ((double)N - 2) / ((N + 1) * (N + 3)));

            double skewLower = skewness - u * skewStdDev;
            double skewUpper = skewness + u * skewStdDev;

            Tables[2].Rows.Add("Коеф асиметрії", skewness, skewStdDev, $"[ {skewLower:F4} ; {skewUpper:F4} ]");           

            double kurtStdDev = Math.Sqrt(24 * (double)N * (N - 2) * (N - 3) / (Math.Pow(N + 1, 2) * (N + 3) * (N + 5)));

            double kurtLower = kurtosis - u * kurtStdDev;
            double kurtUpper = kurtosis + u * kurtStdDev;

            Tables[2].Rows.Add("Коеф ексцесу", kurtosis, kurtStdDev, $"[ {kurtLower:F4} ; {kurtUpper:F4} ]");            

            Tables[2].Rows.Add("Мінімальне", min, DBNull.Value, "");            

            Tables[2].Rows.Add("Мінімальне", max, DBNull.Value, "");            

            double uA = skewness / skewStdDev;
            double uK = kurtosis / kurtStdDev;

            uALabel.Text = Convert.ToString(uA);
            uKLabel.Text = Convert.ToString(uK);

            bool uACheck = Math.Abs(uA) < u;
            bool uKCheck = Math.Abs(uK) < u;

            if (uACheck && uKCheck)
            {
                resLabel.Text = "Відповідь: Так, це нормальний розподіл";
            }
            else
            {
                resLabel.Text = "Відповідь: Ні, це НЕ нормальний розподіл";
            }

        }
        void StatsTableCellsFormat(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var column = statsTable.Columns[e.ColumnIndex];
            if ((column.Name == "Оцінка" || column.Name == "Середн квадрат відхил") && e.Value != null)
            {
                e.Value = string.Format("{0:F4}", e.Value);
                e.FormattingApplied = true;
            }
        }
        void GeneratePaper()
        {           
            var paperX = VarRows.Select(item => item.Value).ToList();            
                                                    
            var paperY = VarRows.Select(item => Normal.InvCDF(0, 1, item.EmpiricFuncValue)).SkipLast(1).ToList();

            ChartSeries paperLineSeries = Charts[2].Series[0];
            paperLineSeries.Points.Clear();

            for (int i = 0; i < paperY.Count; i++)
            {
                paperLineSeries.Points.AddXY(paperX[i], paperY[i]);
            }
        }        
        void GenerateAnomaly()
        {
            ChartSeries pointSeries = Charts[3].Series[0];
            pointSeries.Points.Clear();

            for (int i = 0; i < Vyborka.Count; i++)
            {
                pointSeries.Points.AddXY(i, Vyborka[i]);
            }

            ChartSeries lineASeries = Charts[3].Series[1];
            lineASeries.Points.Clear();
           
            double u = 2.57;            

            double a = Statistics.Mean(Vyborka) - u * Statistics.StandardDeviation(Vyborka);
            this.a = a;
            for (int i = 0; i < Vyborka.Count; i++)
            {
                lineASeries.Points.AddXY(i, a);
            }

            ChartSeries lineBSeries = Charts[3].Series[2];
            lineBSeries.Points.Clear();

            double b = Statistics.Mean(Vyborka) + u * Statistics.StandardDeviation(Vyborka);
            this.b = b;
            for (int i = 0; i < Vyborka.Count; i++)
            {
                lineBSeries.Points.AddXY(i, b);
            }
        }
        void anomalyButton_Click(object sender, EventArgs e)
        {
            if (VarRows.Count == 0) return;

            List<(double Value, int Count)> vyborkaZCount = 
                VarRows.Where(item => item.Value > a && item.Value < b).Select(item => (item.Value, item.Count)).ToList();

            if (vyborkaZCount.Count == VarRows.Count) return;

            N = vyborkaZCount.Sum(el => el.Count);
            Generate(vyborkaZCount);
        }
    }
}