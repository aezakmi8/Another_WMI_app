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
            this.HardInfo_btn = new System.Windows.Forms.Button();
            this.HardTreeinfo = new System.Windows.Forms.TreeView();
            this.classList = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.HardInfo = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.UpdtGrid_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FilldtGrid_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.HardInfo.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.HardTreeinfo.Size = new System.Drawing.Size(448, 367);
            this.HardTreeinfo.TabIndex = 1;
            // 
            // classList
            // 
            this.classList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classList.BackColor = System.Drawing.SystemColors.InfoText;
            this.classList.ForeColor = System.Drawing.Color.Lime;
            this.classList.FormattingEnabled = true;
            this.classList.ItemHeight = 16;
            this.classList.Location = new System.Drawing.Point(577, 28);
            this.classList.Name = "classList";
            this.classList.Size = new System.Drawing.Size(192, 340);
            this.classList.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 42);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 43);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.LogBox.ForeColor = System.Drawing.Color.Lime;
            this.LogBox.FormattingEnabled = true;
            this.LogBox.ItemHeight = 16;
            this.LogBox.Location = new System.Drawing.Point(123, 404);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(517, 116);
            this.LogBox.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.InitialImage = global::Another_WMI_app.Properties.Resources.Anonymous_PNG_Pic;
            this.pictureBox1.Location = new System.Drawing.Point(646, 404);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(128, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.HardInfo);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 556);
            this.tabControl1.TabIndex = 0;
            // 
            // HardInfo
            // 
            this.HardInfo.Controls.Add(this.LogBox);
            this.HardInfo.Controls.Add(this.pictureBox1);
            this.HardInfo.Controls.Add(this.HardInfo_btn);
            this.HardInfo.Controls.Add(this.button2);
            this.HardInfo.Controls.Add(this.classList);
            this.HardInfo.Controls.Add(this.button3);
            this.HardInfo.Controls.Add(this.HardTreeinfo);
            this.HardInfo.Location = new System.Drawing.Point(4, 25);
            this.HardInfo.Name = "HardInfo";
            this.HardInfo.Size = new System.Drawing.Size(780, 527);
            this.HardInfo.TabIndex = 0;
            this.HardInfo.Text = "HardInfo";
            this.HardInfo.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.UpdtGrid_Btn);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Controls.Add(this.FilldtGrid_btn);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(780, 527);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UpdtGrid_Btn
            // 
            this.UpdtGrid_Btn.Location = new System.Drawing.Point(670, 58);
            this.UpdtGrid_Btn.Name = "UpdtGrid_Btn";
            this.UpdtGrid_Btn.Size = new System.Drawing.Size(107, 43);
            this.UpdtGrid_Btn.TabIndex = 11;
            this.UpdtGrid_Btn.Text = "UpdatedtGrid";
            this.UpdtGrid_Btn.UseVisualStyleBackColor = true;
            this.UpdtGrid_Btn.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(670, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(8, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(656, 509);
            this.dataGridView1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // FilldtGrid_btn
            // 
            this.FilldtGrid_btn.Location = new System.Drawing.Point(670, 9);
            this.FilldtGrid_btn.Name = "FilldtGrid_btn";
            this.FilldtGrid_btn.Size = new System.Drawing.Size(107, 43);
            this.FilldtGrid_btn.TabIndex = 1;
            this.FilldtGrid_btn.Text = "FilldtGrid";
            this.FilldtGrid_btn.UseVisualStyleBackColor = true;
            this.FilldtGrid_btn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 551);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.HardInfo.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button HardInfo_btn;
        private System.Windows.Forms.TreeView HardTreeinfo;
        private System.Windows.Forms.ListBox classList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox LogBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage HardInfo;
        private System.Windows.Forms.Button FilldtGrid_btn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UpdtGrid_Btn;
    }
}

