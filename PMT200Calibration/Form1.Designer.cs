namespace PMT200Calibration
{
    partial class PMT200
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
            this.start = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.open_port = new System.Windows.Forms.Button();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.search_port = new System.Windows.Forms.Button();
            this.value_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(39, 111);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "开始校准";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(39, 165);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 1;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(39, 219);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 2;
            this.stop.Text = "停止校准";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // open_port
            // 
            this.open_port.Location = new System.Drawing.Point(39, 62);
            this.open_port.Name = "open_port";
            this.open_port.Size = new System.Drawing.Size(60, 23);
            this.open_port.TabIndex = 3;
            this.open_port.Text = "打开";
            this.open_port.UseVisualStyleBackColor = true;
            this.open_port.Click += new System.EventHandler(this.start_Port_Click);
            // 
            // comboBox_port
            // 
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(39, 29);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(121, 20);
            this.comboBox_port.TabIndex = 4;

            // 
            // search_port
            // 
            this.search_port.Location = new System.Drawing.Point(100, 62);
            this.search_port.Name = "search_port";
            this.search_port.Size = new System.Drawing.Size(60, 23);
            this.search_port.TabIndex = 5;
            this.search_port.Text = "搜索";
            this.search_port.UseVisualStyleBackColor = true;
            this.search_port.Click += new System.EventHandler(this.search_port_Click);
            // 
            // value_label
            // 
            this.value_label.Font = new System.Drawing.Font("宋体", 30F);
            this.value_label.Location = new System.Drawing.Point(172, 111);
            this.value_label.Name = "value_label";
            this.value_label.Size = new System.Drawing.Size(694, 45);
            this.value_label.TabIndex = 6;
            this.value_label.Text = "当前值：";
            // 
            // PMT200
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolTip;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 450);
            this.Controls.Add(this.value_label);
            this.Controls.Add(this.search_port);
            this.Controls.Add(this.comboBox_port);
            this.Controls.Add(this.open_port);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.save);
            this.Controls.Add(this.start);
            this.Name = "PMT200";
            this.Text = "PMT200资源清查校准软件 v1.0";
            this.ResumeLayout(false);

        }

        #endregion
              
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button open_port;
        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.Button search_port;
        private System.Windows.Forms.Label value_label;
    }
}

