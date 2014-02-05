namespace CBusNoti
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_busno = new System.Windows.Forms.TextBox();
            this.tb_busstop = new System.Windows.Forms.TextBox();
            this.noti_min = new System.Windows.Forms.NumericUpDown();
            this.bt_apply = new System.Windows.Forms.Button();
            this.lb_view = new System.Windows.Forms.Label();
            this.lb_view2 = new System.Windows.Forms.Label();
            this.lb_querytime = new System.Windows.Forms.Label();
            this.bt_alert = new System.Windows.Forms.Button();
            this.lb_content = new System.Windows.Forms.Label();
            this.nt_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.noti_min)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "버스번호";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "정류장";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "알림시간";
            // 
            // tb_busno
            // 
            this.tb_busno.Location = new System.Drawing.Point(94, 57);
            this.tb_busno.Name = "tb_busno";
            this.tb_busno.Size = new System.Drawing.Size(100, 21);
            this.tb_busno.TabIndex = 3;
            // 
            // tb_busstop
            // 
            this.tb_busstop.Location = new System.Drawing.Point(94, 94);
            this.tb_busstop.Name = "tb_busstop";
            this.tb_busstop.Size = new System.Drawing.Size(100, 21);
            this.tb_busstop.TabIndex = 5;
            // 
            // noti_min
            // 
            this.noti_min.Location = new System.Drawing.Point(94, 190);
            this.noti_min.Name = "noti_min";
            this.noti_min.Size = new System.Drawing.Size(100, 21);
            this.noti_min.TabIndex = 6;
            // 
            // bt_apply
            // 
            this.bt_apply.Location = new System.Drawing.Point(119, 140);
            this.bt_apply.Name = "bt_apply";
            this.bt_apply.Size = new System.Drawing.Size(75, 23);
            this.bt_apply.TabIndex = 7;
            this.bt_apply.Text = "새로고침";
            this.bt_apply.UseVisualStyleBackColor = true;
            this.bt_apply.Click += new System.EventHandler(this.bt_apply_Click);
            // 
            // lb_view
            // 
            this.lb_view.AutoSize = true;
            this.lb_view.Location = new System.Drawing.Point(257, 62);
            this.lb_view.Name = "lb_view";
            this.lb_view.Size = new System.Drawing.Size(39, 12);
            this.lb_view.TabIndex = 8;
            this.lb_view.Text = "버스 1";
            // 
            // lb_view2
            // 
            this.lb_view2.AutoSize = true;
            this.lb_view2.Location = new System.Drawing.Point(257, 94);
            this.lb_view2.Name = "lb_view2";
            this.lb_view2.Size = new System.Drawing.Size(39, 12);
            this.lb_view2.TabIndex = 9;
            this.lb_view2.Text = "버스 2";
            // 
            // lb_querytime
            // 
            this.lb_querytime.AutoSize = true;
            this.lb_querytime.Location = new System.Drawing.Point(257, 140);
            this.lb_querytime.Name = "lb_querytime";
            this.lb_querytime.Size = new System.Drawing.Size(85, 12);
            this.lb_querytime.TabIndex = 10;
            this.lb_querytime.Text = "최근 접속 시각";
            // 
            // bt_alert
            // 
            this.bt_alert.Location = new System.Drawing.Point(259, 187);
            this.bt_alert.Name = "bt_alert";
            this.bt_alert.Size = new System.Drawing.Size(75, 23);
            this.bt_alert.TabIndex = 11;
            this.bt_alert.Text = "알림시작";
            this.bt_alert.UseVisualStyleBackColor = true;
            this.bt_alert.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_content
            // 
            this.lb_content.AutoSize = true;
            this.lb_content.Location = new System.Drawing.Point(92, 241);
            this.lb_content.Name = "lb_content";
            this.lb_content.Size = new System.Drawing.Size(57, 12);
            this.lb_content.TabIndex = 12;
            this.lb_content.Text = "알림 내용";
            // 
            // nt_icon
            // 
            this.nt_icon.ContextMenuStrip = this.contextMenuStrip1;
            this.nt_icon.Icon = ((System.Drawing.Icon)(resources.GetObject("nt_icon.Icon")));
            this.nt_icon.Text = "notifyIcon1";
            this.nt_icon.Visible = true;
            this.nt_icon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nt_icon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "기본 데이터 ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_content);
            this.Controls.Add(this.bt_alert);
            this.Controls.Add(this.lb_querytime);
            this.Controls.Add(this.lb_view2);
            this.Controls.Add(this.lb_view);
            this.Controls.Add(this.bt_apply);
            this.Controls.Add(this.noti_min);
            this.Controls.Add(this.tb_busstop);
            this.Controls.Add(this.tb_busno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.noti_min)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_busno;
        private System.Windows.Forms.TextBox tb_busstop;
        private System.Windows.Forms.NumericUpDown noti_min;
        private System.Windows.Forms.Button bt_apply;
        private System.Windows.Forms.Label lb_view;
        private System.Windows.Forms.Label lb_view2;
        private System.Windows.Forms.Label lb_querytime;
        private System.Windows.Forms.Button bt_alert;
        private System.Windows.Forms.Label lb_content;
        private System.Windows.Forms.NotifyIcon nt_icon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

