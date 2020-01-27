namespace BlockSnifferIpApp
{
    partial class frmBlockSnifferIpApp
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lstMonitor = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUpdateFirewall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTargetPort = new System.Windows.Forms.TextBox();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkAutoUpdateFirewall = new System.Windows.Forms.CheckBox();
            this.cmbLogicSelect = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTransferMinutes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTransfer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAttackCountMinutes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAttackCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMonitor
            // 
            this.lstMonitor.AutoArrange = false;
            this.lstMonitor.CheckBoxes = true;
            this.lstMonitor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstMonitor.FullRowSelect = true;
            this.lstMonitor.HideSelection = false;
            this.lstMonitor.Location = new System.Drawing.Point(12, 41);
            this.lstMonitor.MultiSelect = false;
            this.lstMonitor.Name = "lstMonitor";
            this.lstMonitor.ShowGroups = false;
            this.lstMonitor.Size = new System.Drawing.Size(461, 237);
            this.lstMonitor.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lstMonitor.TabIndex = 0;
            this.lstMonitor.UseCompatibleStateImageBehavior = false;
            this.lstMonitor.View = System.Windows.Forms.View.Details;
            this.lstMonitor.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstMonitor_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Transfer(KB)";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Alive(s)";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Alive";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Count";
            this.columnHeader5.Width = 46;
            // 
            // btnUpdateFirewall
            // 
            this.btnUpdateFirewall.Enabled = false;
            this.btnUpdateFirewall.Location = new System.Drawing.Point(285, 12);
            this.btnUpdateFirewall.Name = "btnUpdateFirewall";
            this.btnUpdateFirewall.Size = new System.Drawing.Size(107, 23);
            this.btnUpdateFirewall.TabIndex = 1;
            this.btnUpdateFirewall.Text = "Update firewall";
            this.btnUpdateFirewall.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monitor Port:";
            // 
            // txtTargetPort
            // 
            this.txtTargetPort.HideSelection = false;
            this.txtTargetPort.Location = new System.Drawing.Point(101, 14);
            this.txtTargetPort.Name = "txtTargetPort";
            this.txtTargetPort.Size = new System.Drawing.Size(84, 21);
            this.txtTargetPort.TabIndex = 3;
            this.txtTargetPort.Leave += new System.EventHandler(this.txtTargetPort_Leave);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.txtColor);
            this.grpSettings.Controls.Add(this.label8);
            this.grpSettings.Controls.Add(this.chkAutoUpdateFirewall);
            this.grpSettings.Controls.Add(this.cmbLogicSelect);
            this.grpSettings.Controls.Add(this.label5);
            this.grpSettings.Controls.Add(this.txtTransferMinutes);
            this.grpSettings.Controls.Add(this.label6);
            this.grpSettings.Controls.Add(this.txtTransfer);
            this.grpSettings.Controls.Add(this.label7);
            this.grpSettings.Controls.Add(this.label4);
            this.grpSettings.Controls.Add(this.txtAttackCountMinutes);
            this.grpSettings.Controls.Add(this.label3);
            this.grpSettings.Controls.Add(this.txtAttackCount);
            this.grpSettings.Controls.Add(this.label2);
            this.grpSettings.Location = new System.Drawing.Point(12, 284);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(461, 102);
            this.grpSettings.TabIndex = 4;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Highlight Settings";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(138, 20);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(63, 21);
            this.txtColor.TabIndex = 16;
            this.txtColor.Enter += new System.EventHandler(this.txtColor_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "when attack count >";
            // 
            // chkAutoUpdateFirewall
            // 
            this.chkAutoUpdateFirewall.AutoSize = true;
            this.chkAutoUpdateFirewall.Enabled = false;
            this.chkAutoUpdateFirewall.Location = new System.Drawing.Point(6, 75);
            this.chkAutoUpdateFirewall.Name = "chkAutoUpdateFirewall";
            this.chkAutoUpdateFirewall.Size = new System.Drawing.Size(270, 16);
            this.chkAutoUpdateFirewall.TabIndex = 14;
            this.chkAutoUpdateFirewall.Text = "Auto update firewall with highlight items";
            this.chkAutoUpdateFirewall.UseVisualStyleBackColor = true;
            // 
            // cmbLogicSelect
            // 
            this.cmbLogicSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicSelect.FormattingEnabled = true;
            this.cmbLogicSelect.Items.AddRange(new object[] {
            ".",
            "AND",
            "OR"});
            this.cmbLogicSelect.Location = new System.Drawing.Point(98, 47);
            this.cmbLogicSelect.Name = "cmbLogicSelect";
            this.cmbLogicSelect.Size = new System.Drawing.Size(44, 20);
            this.cmbLogicSelect.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(356, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "minutes";
            // 
            // txtTransferMinutes
            // 
            this.txtTransferMinutes.Enabled = false;
            this.txtTransferMinutes.Location = new System.Drawing.Point(317, 47);
            this.txtTransferMinutes.Name = "txtTransferMinutes";
            this.txtTransferMinutes.Size = new System.Drawing.Size(33, 21);
            this.txtTransferMinutes.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(276, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "KB in";
            // 
            // txtTransfer
            // 
            this.txtTransfer.Enabled = false;
            this.txtTransfer.Location = new System.Drawing.Point(219, 47);
            this.txtTransfer.Name = "txtTransfer";
            this.txtTransfer.Size = new System.Drawing.Size(51, 21);
            this.txtTransfer.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(148, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "transfer <";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "minutes";
            // 
            // txtAttackCountMinutes
            // 
            this.txtAttackCountMinutes.Location = new System.Drawing.Point(6, 47);
            this.txtAttackCountMinutes.Name = "txtAttackCountMinutes";
            this.txtAttackCountMinutes.Size = new System.Drawing.Size(33, 21);
            this.txtAttackCountMinutes.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "in";
            // 
            // txtAttackCount
            // 
            this.txtAttackCount.Location = new System.Drawing.Point(332, 20);
            this.txtAttackCount.Name = "txtAttackCount";
            this.txtAttackCount.Size = new System.Drawing.Size(51, 21);
            this.txtAttackCount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Highlight with color";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(398, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmBlockSnifferIpApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 395);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.txtTargetPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdateFirewall);
            this.Controls.Add(this.lstMonitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBlockSnifferIpApp";
            this.Text = "BlockSnifferIpApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBlockSnifferIpApp_FormClosing);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstMonitor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnUpdateFirewall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTargetPort;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.ComboBox cmbLogicSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTransferMinutes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTransfer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAttackCountMinutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAttackCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAutoUpdateFirewall;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExport;
    }
}

