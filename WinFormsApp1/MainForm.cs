using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private TcpServer _server = new TcpServer();
        private HangulAutomata _automata = new HangulAutomata();
        private LogManager _log;
        private AppConfig _config;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            _config = AppConfig.Load();
            nudPort.Value = _config.Port;

            _log = new LogManager(rtbLog);

            _server.OnPacketReceived += (packet) =>
                this.Invoke(() => ProcessPacket(packet));

            _server.OnStatusChanged += (status) =>
                this.Invoke(() =>
                {
                    lblConnection.Text = status;
                    lblConnection.ForeColor = status.Contains("연결됨")
                        ? StatusOn
                        : StatusWait;
                });

            ApplyTheme();
            _log.Log("프로그램 시작됨", StatusOn);
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            _config.Port = (int)nudPort.Value;
            _config.Save();

            _server.Start(_config.Port);
            lblConnection.Text = "● 대기 중";
            lblConnection.ForeColor = StatusWait;
            _log.Log("서버 시작 - 포트: " + _config.Port, StatusOn);
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            _server.Stop();
            lblConnection.Text = "● 연결 안됨";
            lblConnection.ForeColor = StatusError;
            _log.Log("서버 종료됨", StatusHold);
        }

        private void ProcessPacket(string raw)
        {
            raw = raw.Trim();
            _log.Log("수신: " + raw, Color.White);

            if (raw.StartsWith("CHAR:"))
            {
                string ch = raw.Substring(5);
                _automata.Input(ch);
                UpdateResult();
            }
            else if (raw.StartsWith("VOICE:"))
            {
                string ch = raw.Substring(6);
                rtbResult.AppendText(ch);
                _log.Log("음성: " + ch, StatusConfirm);
            }
            else if (raw == "CMD:DELETE")
            {
                _automata.Delete();
                UpdateResult();
            }
            else if (raw == "CMD:CLEAR")
            {
                _automata.Clear();
                rtbResult.Clear();
                _log.Log("초기화됨", StatusHold);
            }
            else if (raw.StartsWith("STATE:"))
            {
                UpdateStatePanel(raw.Substring(6));
            }
            else if (raw.StartsWith("ERROR:"))
            {
                _log.Log("오류: " + raw.Substring(6), StatusError);
            }
        }

        private void UpdateResult()
        {
            rtbResult.Text = _automata.GetResult();
        }

        private void UpdateStatePanel(string state)
        {
            lblReady.ForeColor = Color.Gray;
            lblDetecting.ForeColor = Color.Gray;
            lblHold.ForeColor = Color.Gray;
            lblConfirmed.ForeColor = Color.Gray;
            lblError.ForeColor = Color.Gray;

            switch (state)
            {
                case "READY": lblReady.ForeColor = StatusOn; break;
                case "DETECTING": lblDetecting.ForeColor = StatusDetect; break;
                case "HOLD": lblHold.ForeColor = StatusHold; break;
                case "CONFIRMED": lblConfirmed.ForeColor = StatusConfirm; break;
                case "ERROR": lblError.ForeColor = StatusError; break;
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e) => ProcessPacket("CMD:DELETE");
        private void btnClear_Click_1(object sender, EventArgs e) => ProcessPacket("CMD:CLEAR");

        // 시계
        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        // ===== 테마 색 정의 =====
        private static readonly Color BgDeep = Color.FromArgb(27, 30, 39);    // 결과창/로그 (바닥)
        private static readonly Color BgPanel = Color.FromArgb(36, 40, 55);   // 패널 (중간)
        private static readonly Color BgInput = Color.FromArgb(46, 51, 68);   // 입력창 (살짝 띄움)
        private static readonly Color Accent = Color.FromArgb(108, 160, 246); // 포인트색
        private static readonly Color TextMain = Color.FromArgb(220, 225, 236);// 일반 글자
        private static readonly Color TextDim = Color.FromArgb(138, 146, 166);// 흐린 글자

        // ===== 상태등 색 (차분한 톤) =====
        private static readonly Color StatusOn = Color.FromArgb(80, 200, 130);    // READY / 연결됨
        private static readonly Color StatusWait = Color.FromArgb(240, 200, 80);  // 대기
        private static readonly Color StatusDetect = Color.FromArgb(240, 200, 80);// DETECTING
        private static readonly Color StatusHold = Color.FromArgb(240, 160, 70);  // HOLD
        private static readonly Color StatusConfirm = Color.FromArgb(100, 180, 246);// CONFIRMED
        private static readonly Color StatusError = Color.FromArgb(230, 100, 100); // ERROR

        private void ApplyTheme()
        {
            this.BackColor = BgDeep;

            // 패널
            PanelLeft.BackColor = BgPanel;
            PanelTop.BackColor = BgPanel;
            PanelBottom.BackColor = BgDeep;
            panel1.BackColor = BgPanel;

            // 결과창 / 로그
            rtbResult.BackColor = BgDeep; rtbResult.ForeColor = TextMain;
            rtbLog.BackColor = BgDeep; rtbLog.ForeColor = TextMain;

            // 입력류 (패널보다 밝게 → 떠 보임)
            foreach (var c in new Control[] { nudPort })
            {
                c.BackColor = BgInput;
                c.ForeColor = TextMain;
            }

            // 라벨
            foreach (var l in new Label[] { label11, lblClock, lblState })
                l.ForeColor = TextDim;

            // 버튼
            StyleButton(btnStart, Color.FromArgb(46, 160, 110));  // 초록
            StyleButton(btnStop, Color.FromArgb(210, 90, 90));    // 빨강
            StyleButton(btnDelete, Color.FromArgb(230, 160, 60)); // 주황
            StyleButton(btnClear, Color.FromArgb(190, 70, 70));   // 진빨강

            // 상단 포인트선
            PanelTop.Paint += PanelTop_Paint;
        }

        private void PanelTop_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Accent, 2);
            e.Graphics.DrawLine(pen, 0, PanelTop.Height - 1, PanelTop.Width, PanelTop.Height - 1);
        }

        private void StyleButton(Button b, Color baseColor)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = baseColor;
            b.ForeColor = Color.White;
            b.Cursor = Cursors.Hand;
            b.FlatAppearance.MouseOverBackColor = ControlPaint.Light(baseColor, 0.15f);
            b.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(baseColor, 0.1f);
        }
        // 창 드래그 이동 (타이틀 바 없어도 상단 패널 잡고 옮기기)
        private bool _dragging = false;
        private Point _dragStart;

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragStart = e.Location;
        }
        private void PanelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
                this.Location = new Point(
                    this.Location.X + e.X - _dragStart.X,
                    this.Location.Y + e.Y - _dragStart.Y);
        }
        private void PanelTop_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // ESC 키로 닫기
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}