using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WinFormsApp1
{
    public class TcpServer
    {
        private TcpListener _listener;
        private Thread _listenThread;
        public bool IsRunning { get; private set; }

        public event Action<string> OnPacketReceived;
        public event Action<string> OnStatusChanged;

        public void Start(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            IsRunning = true;
            _listenThread = new Thread(ListenLoop);
            _listenThread.IsBackground = true;
            _listenThread.Start();
        }

        private void ListenLoop()
        {
            OnStatusChanged?.Invoke("● 대기 중");

            while (IsRunning)
            {
                try
                {
                    var client = _listener.AcceptTcpClient();
                    OnStatusChanged?.Invoke("● 연결됨");

                    var thread = new Thread(() => HandleClient(client));
                    thread.IsBackground = true;
                    thread.Start();
                }
                catch
                {
                    break;
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using var reader = new StreamReader(client.GetStream(), Encoding.UTF8);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    OnPacketReceived?.Invoke(line);
                }
            }
            catch { }
            finally
            {
                OnStatusChanged?.Invoke("● 대기 중");
            }
        }

        public void Stop()
        {
            IsRunning = false;
            _listener.Stop();
        }
    }
}