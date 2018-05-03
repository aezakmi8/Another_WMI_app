namespace Another_WMI_app
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HardInfo_btn = new System.Windows.Forms.Button();
            this.HardTreeinfo = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.HardInfo_Tab = new System.Windows.Forms.TabPage();
            this.LogBox = new System.Windows.Forms.ListBox();
            this.Processes_Tab = new System.Windows.Forms.TabPage();
            this.KillProc_Btn = new System.Windows.Forms.Button();
            this.ProcGrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.InstalldAppsGrid = new System.Windows.Forms.DataGridView();
            this.Apps_Tab = new System.Windows.Forms.TabPage();
            this.HardGrid = new System.Windows.Forms.DataGridView();
            this.CommTab = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.HardInfo_Tab.SuspendLayout();
            this.Processes_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstalldAppsGrid)).BeginInit();
            this.Apps_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HardGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // HardInfo_btn
            // 
            this.HardInfo_btn.Location = new System.Drawing.Point(9, 28);
            this.HardInfo_btn.Margin = new System.Windows.Forms.Padding(4);
            this.HardInfo_btn.Name = "HardInfo_btn";
            this.HardInfo_btn.Size = new System.Drawing.Size(107, 43);
            this.HardInfo_btn.TabIndex = 0;
            this.HardInfo_btn.Text = "HardInfo";
            this.HardInfo_btn.UseVisualStyleBackColor = true;
            this.HardInfo_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // HardTreeinfo
            // 
            this.HardTreeinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HardTreeinfo.BackColor = System.Drawing.SystemColors.InfoText;
            this.HardTreeinfo.ForeColor = System.Drawing.Color.Lime;
            this.HardTreeinfo.Location = new System.Drawing.Point(123, 28);
            this.HardTreeinfo.Name = "HardTreeinfo";
            this.HardTreeinfo.Size = new System.Drawing.Size(358, 372);
            this.HardTreeinfo.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Another_WMI_app.Properties.Resources.Anonymous_PNG_Pic;
            this.pictureBox1.InitialImage = global::Another_WMI_app.Properties.Resources.Anonymous_PNG_Pic;
            this.pictureBox1.Location = new System.Drawing.Point(9, 406);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(128, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.HardInfo_Tab);
            this.tabControl1.Controls.Add(this.Processes_Tab);
            this.tabControl1.Controls.Add(this.Apps_Tab);
            this.tabControl1.Controls.Add(this.CommTab);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 556);
            this.tabControl1.TabIndex = 0;
            // 
            // HardInfo_Tab
            // 
            this.HardInfo_Tab.Controls.Add(this.HardGrid);
            this.HardInfo_Tab.Controls.Add(this.LogBox);
            this.HardInfo_Tab.Controls.Add(this.pictureBox1);
            this.HardInfo_Tab.Controls.Add(this.HardInfo_btn);
            this.HardInfo_Tab.Controls.Add(this.HardTreeinfo);
            this.HardInfo_Tab.Location = new System.Drawing.Point(4, 25);
            this.HardInfo_Tab.Name = "HardInfo_Tab";
            this.HardInfo_Tab.Size = new System.Drawing.Size(787, 527);
            this.HardInfo_Tab.TabIndex = 0;
            this.HardInfo_Tab.Text = "HardInfo Tab";
            this.HardInfo_Tab.UseVisualStyleBackColor = true;
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.LogBox.ForeColor = System.Drawing.Color.Lime;
            this.LogBox.FormattingEnabled = true;
            this.LogBox.ItemHeight = 16;
            this.LogBox.Location = new System.Drawing.Point(123, 406);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(358, 116);
            this.LogBox.TabIndex = 10;
            // 
            // Processes_Tab
            // 
            this.Processes_Tab.Controls.Add(this.KillProc_Btn);
            this.Processes_Tab.Controls.Add(this.ProcGrid);
            this.Processes_Tab.Controls.Add(this.tableLayoutPanel1);
            this.Processes_Tab.Location = new System.Drawing.Point(4, 25);
            this.Processes_Tab.Name = "Processes_Tab";
            this.Processes_Tab.Size = new System.Drawing.Size(787, 527);
            this.Processes_Tab.TabIndex = 0;
            this.Processes_Tab.Text = "Processes Tab";
            this.Processes_Tab.UseVisualStyleBackColor = true;
            // 
            // KillProc_Btn
            // 
            this.KillProc_Btn.Location = new System.Drawing.Point(670, 101);
            this.KillProc_Btn.Name = "KillProc_Btn";
            this.KillProc_Btn.Size = new System.Drawing.Size(110, 40);
            this.KillProc_Btn.TabIndex = 13;
            this.KillProc_Btn.Text = "KillProc";
            this.KillProc_Btn.UseVisualStyleBackColor = true;
            this.KillProc_Btn.Click += new System.EventHandler(this.KillProc_Btn_Click);
            // 
            // ProcGrid
            // 
            this.ProcGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProcGrid.BackgroundColor = System.Drawing.SystemColors.ControlText;
            this.ProcGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProcGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ProcGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ProcGrid.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ProcGrid.Location = new System.Drawing.Point(8, 9);
            this.ProcGrid.MultiSelect = false;
            this.ProcGrid.Name = "ProcGrid";
            this.ProcGrid.ReadOnly = true;
            this.ProcGrid.RowTemplate.Height = 24;
            this.ProcGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProcGrid.ShowCellErrors = false;
            this.ProcGrid.Size = new System.Drawing.Size(656, 509);
            this.ProcGrid.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // InstalldAppsGrid
            // 
            this.InstalldAppsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InstalldAppsGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.InstalldAppsGrid.BackgroundColor = System.Drawing.SystemColors.ControlText;
            this.InstalldAppsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstalldAppsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InstalldAppsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.InstalldAppsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InstalldAppsGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.InstalldAppsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.InstalldAppsGrid.GridColor = System.Drawing.SystemColors.ControlText;
            this.InstalldAppsGrid.Location = new System.Drawing.Point(9, 11);
            this.InstalldAppsGrid.Name = "InstalldAppsGrid";
            this.InstalldAppsGrid.RowTemplate.Height = 24;
            this.InstalldAppsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InstalldAppsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InstalldAppsGrid.Size = new System.Drawing.Size(652, 510);
            this.InstalldAppsGrid.TabIndex = 3;
            // 
            // Apps_Tab
            // 
            this.Apps_Tab.Controls.Add(this.InstalldAppsGrid);
            this.Apps_Tab.Location = new System.Drawing.Point(4, 25);
            this.Apps_Tab.Name = "Apps_Tab";
            this.Apps_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Apps_Tab.Size = new System.Drawing.Size(787, 527);
            this.Apps_Tab.TabIndex = 1;
            this.Apps_Tab.Text = "Apps Tab";
            this.Apps_Tab.UseVisualStyleBackColor = true;
            // 
            // HardGrid
            // 
            this.HardGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HardGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.HardGrid.BackgroundColor = System.Drawing.SystemColors.ControlText;
            this.HardGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HardGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.HardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HardGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.HardGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.HardGrid.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HardGrid.Location = new System.Drawing.Point(487, 28);
            this.HardGrid.MultiSelect = false;
            this.HardGrid.Name = "HardGrid";
            this.HardGrid.ReadOnly = true;
            this.HardGrid.RowTemplate.Height = 24;
            this.HardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HardGrid.ShowCellErrors = false;
            this.HardGrid.Size = new System.Drawing.Size(290, 372);
            this.HardGrid.TabIndex = 11;
            this.HardGrid.DoubleClick += new System.EventHandler(this.HardGrid_DoubleClick);
            // 
            // CommTab
            // 
            this.CommTab.Location = new System.Drawing.Point(4, 25);
            this.CommTab.Name = "CommTab";
            this.CommTab.Padding = new System.Windows.Forms.Padding(3);
            this.CommTab.Size = new System.Drawing.Size(787, 527);
            this.CommTab.TabIndex = 2;
            this.CommTab.Text = "CommTab";
            this.CommTab.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(793, 551);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.HardInfo_Tab.ResumeLayout(false);
            this.Processes_Tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstalldAppsGrid)).EndInit();
            this.Apps_Tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HardGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button HardInfo_btn;
        private System.Windows.Forms.TreeView HardTreeinfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Processes_Tab;
        private System.Windows.Forms.TabPage HardInfo_Tab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button KillProc_Btn;
        private System.Windows.Forms.ListBox LogBox;
        public  System.Windows.Forms.DataGridView ProcGrid;
        private System.Windows.Forms.TabPage Apps_Tab;
        private System.Windows.Forms.DataGridView InstalldAppsGrid;
        public System.Windows.Forms.DataGridView HardGrid;
        private System.Windows.Forms.TabPage CommTab;
    }
}

