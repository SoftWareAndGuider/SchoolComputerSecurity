namespace SCSA
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.컴퓨터관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.인터넷허용ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.금지ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.허용ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmd금지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.금지ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.허용ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdㅎToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다시시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.절전ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.메세지전송ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모니터보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.번모니터ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.번모니터ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.사진찍기개발중ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.사진폴더열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 423);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.컴퓨터관리ToolStripMenuItem,
            this.메세지전송ToolStripMenuItem,
            this.모니터보기ToolStripMenuItem,
            this.사진찍기개발중ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 컴퓨터관리ToolStripMenuItem
            // 
            this.컴퓨터관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.인터넷허용ToolStripMenuItem,
            this.cmd금지ToolStripMenuItem,
            this.cmdㅎToolStripMenuItem});
            this.컴퓨터관리ToolStripMenuItem.Name = "컴퓨터관리ToolStripMenuItem";
            this.컴퓨터관리ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.컴퓨터관리ToolStripMenuItem.Text = "컴퓨터 관리";
            // 
            // 인터넷허용ToolStripMenuItem
            // 
            this.인터넷허용ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.금지ToolStripMenuItem1,
            this.허용ToolStripMenuItem1});
            this.인터넷허용ToolStripMenuItem.Name = "인터넷허용ToolStripMenuItem";
            this.인터넷허용ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.인터넷허용ToolStripMenuItem.Text = "명령 프롬프트(CMD)";
            // 
            // 금지ToolStripMenuItem1
            // 
            this.금지ToolStripMenuItem1.Name = "금지ToolStripMenuItem1";
            this.금지ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.금지ToolStripMenuItem1.Text = "금지";
            // 
            // 허용ToolStripMenuItem1
            // 
            this.허용ToolStripMenuItem1.Name = "허용ToolStripMenuItem1";
            this.허용ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.허용ToolStripMenuItem1.Text = "허용";
            // 
            // cmd금지ToolStripMenuItem
            // 
            this.cmd금지ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.금지ToolStripMenuItem2,
            this.허용ToolStripMenuItem2});
            this.cmd금지ToolStripMenuItem.Name = "cmd금지ToolStripMenuItem";
            this.cmd금지ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cmd금지ToolStripMenuItem.Text = "작업 관리자 (개발중)";
            // 
            // 금지ToolStripMenuItem2
            // 
            this.금지ToolStripMenuItem2.Name = "금지ToolStripMenuItem2";
            this.금지ToolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.금지ToolStripMenuItem2.Text = "금지";
            // 
            // 허용ToolStripMenuItem2
            // 
            this.허용ToolStripMenuItem2.Name = "허용ToolStripMenuItem2";
            this.허용ToolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.허용ToolStripMenuItem2.Text = "허용";
            // 
            // cmdㅎToolStripMenuItem
            // 
            this.cmdㅎToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.종료ToolStripMenuItem,
            this.다시시작ToolStripMenuItem,
            this.절전ToolStripMenuItem});
            this.cmdㅎToolStripMenuItem.Name = "cmdㅎToolStripMenuItem";
            this.cmdㅎToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cmdㅎToolStripMenuItem.Text = "전원 관리";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 다시시작ToolStripMenuItem
            // 
            this.다시시작ToolStripMenuItem.Name = "다시시작ToolStripMenuItem";
            this.다시시작ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.다시시작ToolStripMenuItem.Text = "다시 시작";
            this.다시시작ToolStripMenuItem.Click += new System.EventHandler(this.다시시작ToolStripMenuItem_Click);
            // 
            // 절전ToolStripMenuItem
            // 
            this.절전ToolStripMenuItem.Name = "절전ToolStripMenuItem";
            this.절전ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.절전ToolStripMenuItem.Text = "절전";
            this.절전ToolStripMenuItem.Click += new System.EventHandler(this.절전ToolStripMenuItem_Click);
            // 
            // 메세지전송ToolStripMenuItem
            // 
            this.메세지전송ToolStripMenuItem.Name = "메세지전송ToolStripMenuItem";
            this.메세지전송ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.메세지전송ToolStripMenuItem.Text = "메세지 전송";
            this.메세지전송ToolStripMenuItem.Click += new System.EventHandler(this.메세지전송ToolStripMenuItem_Click);
            // 
            // 모니터보기ToolStripMenuItem
            // 
            this.모니터보기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.번모니터ToolStripMenuItem,
            this.번모니터ToolStripMenuItem1});
            this.모니터보기ToolStripMenuItem.Name = "모니터보기ToolStripMenuItem";
            this.모니터보기ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.모니터보기ToolStripMenuItem.Text = "모니터 보기";
            // 
            // 번모니터ToolStripMenuItem
            // 
            this.번모니터ToolStripMenuItem.Checked = true;
            this.번모니터ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.번모니터ToolStripMenuItem.Name = "번모니터ToolStripMenuItem";
            this.번모니터ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.번모니터ToolStripMenuItem.Text = "1번 모니터";
            this.번모니터ToolStripMenuItem.Click += new System.EventHandler(this.번모니터ToolStripMenuItem_Click);
            // 
            // 번모니터ToolStripMenuItem1
            // 
            this.번모니터ToolStripMenuItem1.Name = "번모니터ToolStripMenuItem1";
            this.번모니터ToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.번모니터ToolStripMenuItem1.Text = "2번 모니터";
            this.번모니터ToolStripMenuItem1.Click += new System.EventHandler(this.번모니터ToolStripMenuItem1_Click);
            // 
            // 사진찍기개발중ToolStripMenuItem
            // 
            this.사진찍기개발중ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.사진폴더열기ToolStripMenuItem});
            this.사진찍기개발중ToolStripMenuItem.Name = "사진찍기개발중ToolStripMenuItem";
            this.사진찍기개발중ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.사진찍기개발중ToolStripMenuItem.Text = "사진 찍기";
            this.사진찍기개발중ToolStripMenuItem.Click += new System.EventHandler(this.사진찍기개발중ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(661, 237);
            this.label1.TabIndex = 4;
            this.label1.Text = "Offline";
            // 
            // 사진폴더열기ToolStripMenuItem
            // 
            this.사진폴더열기ToolStripMenuItem.Name = "사진폴더열기ToolStripMenuItem";
            this.사진폴더열기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.사진폴더열기ToolStripMenuItem.Text = "사진 폴더 열기";
            this.사진폴더열기ToolStripMenuItem.Click += new System.EventHandler(this.사진폴더열기ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SchoolComputerAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 컴퓨터관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 인터넷허용ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 금지ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 허용ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmdㅎToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다시시작ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 절전ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 메세지전송ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 모니터보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 번모니터ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 번모니터ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmd금지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 금지ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 허용ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 사진찍기개발중ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 사진폴더열기ToolStripMenuItem;
    }
}

