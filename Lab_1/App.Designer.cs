namespace Lab_1
{
    partial class App
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tables = new TabPage();
            varClassTable = new DataGridView();
            varTable = new DataGridView();
            tablesControlPanel = new Panel();
            label1 = new Label();
            classAmountLabel = new Label();
            classAmountPicker = new NumericUpDown();
            addFileButton = new Button();
            statusStrip = new StatusStrip();
            tablesStatusLabel = new ToolStripStatusLabel();
            graphics = new TabPage();
            BTextBox = new TextBox();
            statusStrip1 = new StatusStrip();
            graphicsStatusLabel = new ToolStripStatusLabel();
            stats = new TabPage();
            resLabel = new Label();
            uKLabel = new Label();
            uALabel = new Label();
            statsTable = new DataGridView();
            statusStrip2 = new StatusStrip();
            statsStatusLabel = new ToolStripStatusLabel();
            anomaly = new TabPage();
            anomalyButton = new Button();
            tabControl.SuspendLayout();
            tables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)varClassTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)varTable).BeginInit();
            tablesControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)classAmountPicker).BeginInit();
            statusStrip.SuspendLayout();
            graphics.SuspendLayout();
            statusStrip1.SuspendLayout();
            stats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)statsTable).BeginInit();
            statusStrip2.SuspendLayout();
            anomaly.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tables);
            tabControl.Controls.Add(graphics);
            tabControl.Controls.Add(stats);
            tabControl.Controls.Add(anomaly);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1612, 726);
            tabControl.TabIndex = 0;
            // 
            // tables
            // 
            tables.Controls.Add(varClassTable);
            tables.Controls.Add(varTable);
            tables.Controls.Add(tablesControlPanel);
            tables.Controls.Add(statusStrip);
            tables.Location = new Point(4, 32);
            tables.Name = "tables";
            tables.Padding = new Padding(3);
            tables.Size = new Size(1604, 690);
            tables.TabIndex = 0;
            tables.Text = "Page 1";
            tables.UseVisualStyleBackColor = true;
            // 
            // varClassTable
            // 
            varClassTable.AllowUserToAddRows = false;
            varClassTable.AllowUserToDeleteRows = false;
            varClassTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            varClassTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            varClassTable.BackgroundColor = SystemColors.ButtonFace;
            varClassTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            varClassTable.Dock = DockStyle.Right;
            varClassTable.Location = new Point(801, 44);
            varClassTable.Margin = new Padding(5);
            varClassTable.Name = "varClassTable";
            varClassTable.ReadOnly = true;
            varClassTable.RowHeadersWidth = 51;
            varClassTable.RowTemplate.Height = 29;
            varClassTable.Size = new Size(800, 618);
            varClassTable.TabIndex = 3;
            // 
            // varTable
            // 
            varTable.AllowUserToAddRows = false;
            varTable.AllowUserToDeleteRows = false;
            varTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            varTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            varTable.BackgroundColor = SystemColors.ButtonFace;
            varTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            varTable.Dock = DockStyle.Left;
            varTable.Location = new Point(3, 44);
            varTable.Margin = new Padding(5);
            varTable.Name = "varTable";
            varTable.ReadOnly = true;
            varTable.RowHeadersWidth = 51;
            varTable.RowTemplate.Height = 29;
            varTable.Size = new Size(758, 618);
            varTable.TabIndex = 2;
            // 
            // tablesControlPanel
            // 
            tablesControlPanel.Controls.Add(label1);
            tablesControlPanel.Controls.Add(classAmountLabel);
            tablesControlPanel.Controls.Add(classAmountPicker);
            tablesControlPanel.Controls.Add(addFileButton);
            tablesControlPanel.Dock = DockStyle.Top;
            tablesControlPanel.Location = new Point(3, 3);
            tablesControlPanel.Name = "tablesControlPanel";
            tablesControlPanel.Size = new Size(1598, 41);
            tablesControlPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(383, 13);
            label1.Name = "label1";
            label1.Size = new Size(59, 23);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // classAmountLabel
            // 
            classAmountLabel.AutoSize = true;
            classAmountLabel.Location = new Point(142, 8);
            classAmountLabel.Name = "classAmountLabel";
            classAmountLabel.Size = new Size(111, 23);
            classAmountLabel.TabIndex = 2;
            classAmountLabel.Text = "К-сть класів";
            // 
            // classAmountPicker
            // 
            classAmountPicker.Location = new Point(259, 6);
            classAmountPicker.Name = "classAmountPicker";
            classAmountPicker.Size = new Size(61, 30);
            classAmountPicker.TabIndex = 1;
            classAmountPicker.ValueChanged += classAmountPicker_ValueChanged;
            // 
            // addFileButton
            // 
            addFileButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addFileButton.Location = new Point(5, 3);
            addFileButton.Name = "addFileButton";
            addFileButton.Size = new Size(131, 35);
            addFileButton.TabIndex = 0;
            addFileButton.Text = "Обрати файл";
            addFileButton.UseVisualStyleBackColor = true;
            addFileButton.Click += addFileButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { tablesStatusLabel });
            statusStrip.Location = new Point(3, 662);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1598, 25);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // tablesStatusLabel
            // 
            tablesStatusLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            tablesStatusLabel.Margin = new Padding(0);
            tablesStatusLabel.Name = "tablesStatusLabel";
            tablesStatusLabel.Size = new Size(1583, 25);
            tablesStatusLabel.Spring = true;
            tablesStatusLabel.Text = "Status";
            // 
            // graphics
            // 
            graphics.Controls.Add(BTextBox);
            graphics.Controls.Add(statusStrip1);
            graphics.Location = new Point(4, 32);
            graphics.Name = "graphics";
            graphics.Padding = new Padding(3);
            graphics.Size = new Size(1604, 690);
            graphics.TabIndex = 1;
            graphics.Text = "Page 2";
            graphics.UseVisualStyleBackColor = true;
            // 
            // BTextBox
            // 
            BTextBox.Location = new Point(8, 8);
            BTextBox.Name = "BTextBox";
            BTextBox.Size = new Size(125, 30);
            BTextBox.TabIndex = 1;
            BTextBox.TextChanged += BTextBox_TextChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { graphicsStatusLabel });
            statusStrip1.Location = new Point(3, 662);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1598, 25);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // graphicsStatusLabel
            // 
            graphicsStatusLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            graphicsStatusLabel.Margin = new Padding(0);
            graphicsStatusLabel.Name = "graphicsStatusLabel";
            graphicsStatusLabel.Size = new Size(1583, 25);
            graphicsStatusLabel.Spring = true;
            graphicsStatusLabel.Text = "Status";
            // 
            // stats
            // 
            stats.Controls.Add(resLabel);
            stats.Controls.Add(uKLabel);
            stats.Controls.Add(uALabel);
            stats.Controls.Add(statsTable);
            stats.Controls.Add(statusStrip2);
            stats.Location = new Point(4, 32);
            stats.Name = "stats";
            stats.Size = new Size(1604, 690);
            stats.TabIndex = 2;
            stats.Text = "Page 3";
            stats.UseVisualStyleBackColor = true;
            // 
            // resLabel
            // 
            resLabel.AutoSize = true;
            resLabel.Location = new Point(10, 384);
            resLabel.Name = "resLabel";
            resLabel.Size = new Size(93, 23);
            resLabel.TabIndex = 4;
            resLabel.Text = "Відповідь";
            // 
            // uKLabel
            // 
            uKLabel.AutoSize = true;
            uKLabel.Location = new Point(10, 348);
            uKLabel.Name = "uKLabel";
            uKLabel.Size = new Size(31, 23);
            uKLabel.TabIndex = 3;
            uKLabel.Text = "uK";
            // 
            // uALabel
            // 
            uALabel.AutoSize = true;
            uALabel.Location = new Point(10, 315);
            uALabel.Name = "uALabel";
            uALabel.Size = new Size(32, 23);
            uALabel.TabIndex = 2;
            uALabel.Text = "uA";
            // 
            // statsTable
            // 
            statsTable.AllowUserToAddRows = false;
            statsTable.AllowUserToDeleteRows = false;
            statsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            statsTable.BackgroundColor = SystemColors.ButtonFace;
            statsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            statsTable.Location = new Point(10, 15);
            statsTable.Margin = new Padding(5);
            statsTable.Name = "statsTable";
            statsTable.ReadOnly = true;
            statsTable.RowHeadersWidth = 51;
            statsTable.RowTemplate.Height = 29;
            statsTable.Size = new Size(840, 261);
            statsTable.TabIndex = 1;
            // 
            // statusStrip2
            // 
            statusStrip2.ImageScalingSize = new Size(20, 20);
            statusStrip2.Items.AddRange(new ToolStripItem[] { statsStatusLabel });
            statusStrip2.Location = new Point(0, 665);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Size = new Size(1604, 25);
            statusStrip2.TabIndex = 0;
            statusStrip2.Text = "statusStrip2";
            // 
            // statsStatusLabel
            // 
            statsStatusLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            statsStatusLabel.Margin = new Padding(0);
            statsStatusLabel.Name = "statsStatusLabel";
            statsStatusLabel.Size = new Size(1589, 25);
            statsStatusLabel.Spring = true;
            statsStatusLabel.Text = "Status";
            // 
            // anomaly
            // 
            anomaly.Controls.Add(anomalyButton);
            anomaly.Location = new Point(4, 32);
            anomaly.Name = "anomaly";
            anomaly.Size = new Size(1604, 690);
            anomaly.TabIndex = 3;
            anomaly.Text = "Page 4";
            anomaly.UseVisualStyleBackColor = true;
            // 
            // anomalyButton
            // 
            anomalyButton.Location = new Point(10, 10);
            anomalyButton.Name = "anomalyButton";
            anomalyButton.Size = new Size(215, 40);
            anomalyButton.TabIndex = 0;
            anomalyButton.Text = "Видалити аномалії";
            anomalyButton.UseVisualStyleBackColor = true;
            anomalyButton.Click += anomalyButton_Click;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1612, 726);
            Controls.Add(tabControl);
            Name = "App";
            Text = "Form1";
            tabControl.ResumeLayout(false);
            tables.ResumeLayout(false);
            tables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)varClassTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)varTable).EndInit();
            tablesControlPanel.ResumeLayout(false);
            tablesControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)classAmountPicker).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            graphics.ResumeLayout(false);
            graphics.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            stats.ResumeLayout(false);
            stats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)statsTable).EndInit();
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
            anomaly.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tables;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel tablesStatusLabel;
        private TabPage graphics;
        private TabPage stats;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel graphicsStatusLabel;
        private StatusStrip statusStrip2;
        private ToolStripStatusLabel statsStatusLabel;
        private Panel tablesControlPanel;
        private Label classAmountLabel;
        private NumericUpDown classAmountPicker;
        private Button addFileButton;
        private DataGridView varClassTable;
        private DataGridView varTable;
        private Label label1;
        private TextBox BTextBox;
        private DataGridView statsTable;
        private Label uKLabel;
        private Label uALabel;
        private Label resLabel;
        private TabPage anomaly;
        private Button anomalyButton;
    }
}