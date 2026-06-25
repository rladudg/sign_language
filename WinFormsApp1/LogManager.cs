using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class LogManager
    {
        private RichTextBox _logBox;
        private string _logFilePath;

        public LogManager(RichTextBox logBox)
        {
            _logBox = logBox;
            _logFilePath = $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        }

        public void Log(string message, Color? color = null)
        {
            string line = $"[{DateTime.Now:HH:mm:ss}] {message}";

            if (_logBox.InvokeRequired)
            {
                _logBox.Invoke(() => AppendLog(line, color));
            }
            else
            {
                AppendLog(line, color);
            }

            File.AppendAllText(_logFilePath, line + "\n");
        }

        private void AppendLog(string line, Color? color)
        {
            _logBox.SelectionStart = _logBox.TextLength;
            _logBox.SelectionLength = 0;
            _logBox.SelectionColor = color ?? Color.White;
            _logBox.AppendText(line + "\n");
            _logBox.ScrollToCaret();
        }
    }
}