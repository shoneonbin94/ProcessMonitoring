namespace BServerMonitoring
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lb_Process = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Text = new System.Windows.Forms.TextBox();
            this.btn_Excute = new System.Windows.Forms.Button();
            this.lbl_Text = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_Count = new System.Windows.Forms.Label();
            this.btn_Kill = new System.Windows.Forms.Button();
            this.lbl_Cpu = new System.Windows.Forms.Label();
            this.lbl_Cpu2 = new System.Windows.Forms.Label();
            this.lbl_Ram = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_DrvTotal = new System.Windows.Forms.Label();
            this.lbl_DrvUse = new System.Windows.Forms.Label();
            this.lbl_DrvAvailable = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Process
            // 
            this.lb_Process.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Process.FormattingEnabled = true;
            this.lb_Process.ItemHeight = 12;
            this.lb_Process.Location = new System.Drawing.Point(9, 67);
            this.lb_Process.Name = "lb_Process";
            this.lb_Process.Size = new System.Drawing.Size(472, 196);
            this.lb_Process.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "ProcessName : ";
            // 
            // tb_Text
            // 
            this.tb_Text.Location = new System.Drawing.Point(137, 42);
            this.tb_Text.Multiline = true;
            this.tb_Text.Name = "tb_Text";
            this.tb_Text.Size = new System.Drawing.Size(144, 20);
            this.tb_Text.TabIndex = 12;
            // 
            // btn_Excute
            // 
            this.btn_Excute.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Excute.Location = new System.Drawing.Point(353, 31);
            this.btn_Excute.Name = "btn_Excute";
            this.btn_Excute.Size = new System.Drawing.Size(61, 31);
            this.btn_Excute.TabIndex = 10;
            this.btn_Excute.Text = "Excute";
            this.btn_Excute.UseVisualStyleBackColor = true;
            this.btn_Excute.Click += new System.EventHandler(this.btn_Excute_Click);
            // 
            // lbl_Text
            // 
            this.lbl_Text.AutoSize = true;
            this.lbl_Text.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Text.Location = new System.Drawing.Point(6, 21);
            this.lbl_Text.Name = "lbl_Text";
            this.lbl_Text.Size = new System.Drawing.Size(169, 13);
            this.lbl_Text.TabIndex = 8;
            this.lbl_Text.Text = "Running Process Count : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_Count);
            this.groupBox3.Controls.Add(this.lb_Process);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_Text);
            this.groupBox3.Controls.Add(this.btn_Excute);
            this.groupBox3.Controls.Add(this.lbl_Text);
            this.groupBox3.Controls.Add(this.btn_Kill);
            this.groupBox3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(460, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 274);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PROCESS";
            // 
            // lbl_Count
            // 
            this.lbl_Count.AutoSize = true;
            this.lbl_Count.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Count.Location = new System.Drawing.Point(190, 21);
            this.lbl_Count.Name = "lbl_Count";
            this.lbl_Count.Size = new System.Drawing.Size(0, 15);
            this.lbl_Count.TabIndex = 15;
            // 
            // btn_Kill
            // 
            this.btn_Kill.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Kill.Location = new System.Drawing.Point(420, 31);
            this.btn_Kill.Name = "btn_Kill";
            this.btn_Kill.Size = new System.Drawing.Size(61, 31);
            this.btn_Kill.TabIndex = 7;
            this.btn_Kill.Text = "Kill";
            this.btn_Kill.UseVisualStyleBackColor = true;
            this.btn_Kill.Click += new System.EventHandler(this.btn_Kill_Click);
            // 
            // lbl_Cpu
            // 
            this.lbl_Cpu.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Cpu.Location = new System.Drawing.Point(6, 30);
            this.lbl_Cpu.Name = "lbl_Cpu";
            this.lbl_Cpu.Size = new System.Drawing.Size(423, 23);
            this.lbl_Cpu.TabIndex = 0;
            this.lbl_Cpu.Text = "CPU Use : ";
            // 
            // lbl_Cpu2
            // 
            this.lbl_Cpu2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Cpu2.Location = new System.Drawing.Point(6, 96);
            this.lbl_Cpu2.Name = "lbl_Cpu2";
            this.lbl_Cpu2.Size = new System.Drawing.Size(423, 23);
            this.lbl_Cpu2.TabIndex = 2;
            this.lbl_Cpu2.Text = "My_system_check CPU Use : ";
            // 
            // lbl_Ram
            // 
            this.lbl_Ram.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Ram.Location = new System.Drawing.Point(6, 62);
            this.lbl_Ram.Name = "lbl_Ram";
            this.lbl_Ram.Size = new System.Drawing.Size(423, 23);
            this.lbl_Ram.TabIndex = 1;
            this.lbl_Ram.Text = "RAM Available Use : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Cpu);
            this.groupBox1.Controls.Add(this.lbl_Cpu2);
            this.groupBox1.Controls.Add(this.lbl_Ram);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 127);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPU";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Matching Monitoring";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_DrvTotal);
            this.groupBox2.Controls.Add(this.lbl_DrvUse);
            this.groupBox2.Controls.Add(this.lbl_DrvAvailable);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(8, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 140);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "C Disk";
            // 
            // lbl_DrvTotal
            // 
            this.lbl_DrvTotal.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_DrvTotal.Location = new System.Drawing.Point(6, 32);
            this.lbl_DrvTotal.Name = "lbl_DrvTotal";
            this.lbl_DrvTotal.Size = new System.Drawing.Size(423, 23);
            this.lbl_DrvTotal.TabIndex = 0;
            this.lbl_DrvTotal.Text = "Total : ";
            // 
            // lbl_DrvUse
            // 
            this.lbl_DrvUse.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_DrvUse.Location = new System.Drawing.Point(6, 100);
            this.lbl_DrvUse.Name = "lbl_DrvUse";
            this.lbl_DrvUse.Size = new System.Drawing.Size(423, 23);
            this.lbl_DrvUse.TabIndex = 2;
            this.lbl_DrvUse.Text = "Use : ";
            // 
            // lbl_DrvAvailable
            // 
            this.lbl_DrvAvailable.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_DrvAvailable.Location = new System.Drawing.Point(6, 68);
            this.lbl_DrvAvailable.Name = "lbl_DrvAvailable";
            this.lbl_DrvAvailable.Size = new System.Drawing.Size(423, 23);
            this.lbl_DrvAvailable.TabIndex = 1;
            this.lbl_DrvAvailable.Text = "Available : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 292);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Server Monitoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Process;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Text;
        private System.Windows.Forms.Button btn_Excute;
        private System.Windows.Forms.Label lbl_Text;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_Count;
        private System.Windows.Forms.Button btn_Kill;
        private System.Windows.Forms.Label lbl_Cpu;
        private System.Windows.Forms.Label lbl_Cpu2;
        private System.Windows.Forms.Label lbl_Ram;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_DrvTotal;
        private System.Windows.Forms.Label lbl_DrvUse;
        private System.Windows.Forms.Label lbl_DrvAvailable;
    }
}

