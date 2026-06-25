namespace WinFormsApp1
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            lblConnection = new Label();
            PanelLeft = new Panel();
            btnClear = new Button();
            lblError = new Label();
            lblHold = new Label();
            lblConfirmed = new Label();
            btnDelete = new Button();
            lblReady = new Label();
            lblDetecting = new Label();
            lblState = new Label();
            PanelTop = new Panel();
            lblClock = new Label();
            label11 = new Label();
            nudPort = new NumericUpDown();
            PanelBottom = new Panel();
            rtbLog = new RichTextBox();
            panel1 = new Panel();
            btnStop = new Button();
            btnStart = new Button();
            rtbResult = new RichTextBox();
            timerClock = new System.Windows.Forms.Timer(components);
            PanelLeft.SuspendLayout();
            PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
            PanelBottom.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblConnection
            // 
            lblConnection.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblConnection.ForeColor = Color.IndianRed;
            lblConnection.Location = new Point(13, 0);
            lblConnection.Name = "lblConnection";
            lblConnection.Size = new Size(162, 40);
            lblConnection.TabIndex = 0;
            lblConnection.Text = "● 연결 안됨";
            lblConnection.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PanelLeft
            // 
            PanelLeft.BackColor = Color.FromArgb(36, 40, 55);
            PanelLeft.Controls.Add(btnClear);
            PanelLeft.Controls.Add(lblError);
            PanelLeft.Controls.Add(lblHold);
            PanelLeft.Controls.Add(lblConfirmed);
            PanelLeft.Controls.Add(btnDelete);
            PanelLeft.Controls.Add(lblReady);
            PanelLeft.Controls.Add(lblDetecting);
            PanelLeft.Dock = DockStyle.Left;
            PanelLeft.Location = new Point(0, 0);
            PanelLeft.Name = "PanelLeft";
            PanelLeft.Size = new Size(160, 694);
            PanelLeft.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DarkRed;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(76, 544);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 34);
            btnClear.TabIndex = 0;
            btnClear.Text = "초기화";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click_1;
            // 
            // lblError
            // 
            lblError.ForeColor = Color.Gray;
            lblError.Location = new Point(30, 298);
            lblError.Name = "lblError";
            lblError.Size = new Size(162, 45);
            lblError.TabIndex = 0;
            lblError.Text = "● Error";
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHold
            // 
            lblHold.ForeColor = Color.Gray;
            lblHold.Location = new Point(30, 170);
            lblHold.Name = "lblHold";
            lblHold.Size = new Size(162, 45);
            lblHold.TabIndex = 0;
            lblHold.Text = "● Hold";
            lblHold.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblConfirmed
            // 
            lblConfirmed.ForeColor = Color.Gray;
            lblConfirmed.Location = new Point(30, 231);
            lblConfirmed.Name = "lblConfirmed";
            lblConfirmed.Size = new Size(162, 45);
            lblConfirmed.TabIndex = 0;
            lblConfirmed.Text = "● Confirmed";
            lblConfirmed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Orange;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(4, 544);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(70, 34);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "삭제";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // lblReady
            // 
            lblReady.ForeColor = Color.Gray;
            lblReady.Location = new Point(30, 42);
            lblReady.Name = "lblReady";
            lblReady.Size = new Size(162, 45);
            lblReady.TabIndex = 0;
            lblReady.Text = "● Ready";
            lblReady.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDetecting
            // 
            lblDetecting.ForeColor = Color.Gray;
            lblDetecting.Location = new Point(30, 110);
            lblDetecting.Name = "lblDetecting";
            lblDetecting.Size = new Size(162, 45);
            lblDetecting.TabIndex = 0;
            lblDetecting.Text = "● Detecting";
            lblDetecting.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblState
            // 
            lblState.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblState.ForeColor = Color.Gray;
            lblState.Location = new Point(312, 0);
            lblState.Name = "lblState";
            lblState.Size = new Size(155, 40);
            lblState.TabIndex = 0;
            lblState.Text = "대기중";
            lblState.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PanelTop
            // 
            PanelTop.BackColor = Color.FromArgb(36, 40, 55);
            PanelTop.Controls.Add(lblClock);
            PanelTop.Controls.Add(lblState);
            PanelTop.Controls.Add(label11);
            PanelTop.Controls.Add(nudPort);
            PanelTop.Controls.Add(lblConnection);
            PanelTop.Dock = DockStyle.Top;
            PanelTop.Location = new Point(160, 0);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(1018, 40);
            PanelTop.TabIndex = 6;
            PanelTop.MouseDown += PanelTop_MouseDown;
            PanelTop.MouseMove += PanelTop_MouseMove;
            PanelTop.MouseUp += PanelTop_MouseUp;
            // 
            // lblClock
            // 
            lblClock.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblClock.ForeColor = Color.FromArgb(220, 225, 236);
            lblClock.Location = new Point(624, 0);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(155, 40);
            lblClock.TabIndex = 0;
            lblClock.Text = "00:00:00";
            lblClock.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(785, 5);
            label11.Name = "label11";
            label11.Size = new Size(48, 25);
            label11.TabIndex = 0;
            label11.Text = "포트";
            // 
            // nudPort
            // 
            nudPort.Location = new Point(835, 3);
            nudPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudPort.Minimum = new decimal(new int[] { 9000, 0, 0, 0 });
            nudPort.Name = "nudPort";
            nudPort.Size = new Size(180, 31);
            nudPort.TabIndex = 2;
            nudPort.Value = new decimal(new int[] { 9000, 0, 0, 0 });
            // 
            // PanelBottom
            // 
            PanelBottom.BackColor = Color.FromArgb(20, 20, 20);
            PanelBottom.Controls.Add(rtbLog);
            PanelBottom.Dock = DockStyle.Bottom;
            PanelBottom.Location = new Point(160, 544);
            PanelBottom.Name = "PanelBottom";
            PanelBottom.Size = new Size(1018, 150);
            PanelBottom.TabIndex = 7;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.FromArgb(36, 40, 55);
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rtbLog.ForeColor = Color.White;
            rtbLog.Location = new Point(0, 0);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(1018, 150);
            rtbLog.TabIndex = 0;
            rtbLog.Text = "";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(36, 40, 55);
            panel1.Controls.Add(btnStop);
            panel1.Controls.Add(btnStart);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(941, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(237, 504);
            panel1.TabIndex = 8;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.IndianRed;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Location = new Point(122, 13);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(112, 34);
            btnStop.TabIndex = 3;
            btnStop.Text = "연결 종료";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click_1;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Green;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Location = new Point(6, 13);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 34);
            btnStart.TabIndex = 3;
            btnStart.Text = "연결시작";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click_1;
            // 
            // rtbResult
            // 
            rtbResult.BackColor = Color.FromArgb(27, 30, 39);
            rtbResult.Dock = DockStyle.Fill;
            rtbResult.Font = new Font("맑은 고딕", 36F, FontStyle.Regular, GraphicsUnit.Point);
            rtbResult.ForeColor = Color.White;
            rtbResult.Location = new Point(160, 40);
            rtbResult.Name = "rtbResult";
            rtbResult.ReadOnly = true;
            rtbResult.Size = new Size(781, 504);
            rtbResult.TabIndex = 9;
            rtbResult.Text = "";
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 694);
            Controls.Add(rtbResult);
            Controls.Add(panel1);
            Controls.Add(PanelBottom);
            Controls.Add(PanelTop);
            Controls.Add(PanelLeft);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load_1;
            PanelLeft.ResumeLayout(false);
            PanelTop.ResumeLayout(false);
            PanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPort).EndInit();
            PanelBottom.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblConnection;
        private Panel PanelLeft;
        private Label lblState;
        private Label lblReady;
        private Label lblError;
        private Label lblConfirmed;
        private Label lblDetecting;
        private Panel PanelTop;
        private Label lblClock;
        private Label lblHold;
        private Panel PanelBottom;
        private RichTextBox rtbLog;
        private Panel panel1;
        private Label label11;
        private Button btnStop;
        private Button btnStart;
        private NumericUpDown nudPort;
        private RichTextBox rtbResult;
        private System.Windows.Forms.Timer timerClock;
        private Button btnClear;
        private Button btnDelete;
    }
}
