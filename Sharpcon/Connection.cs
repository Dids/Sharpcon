using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Sharpcon
{
    class Connection
    {
        #region Members

        public static WebSocket webSocket;

        public static Form2 form2;

        #endregion

        #region Methods

        public static string ConnectionString(string address, string port, string password)
            => $"ws://{address}:{port}/{password}";

        public static void Initialise(string url)
        {
            try
            {
                webSocket = new WebSocket(url);

                webSocket.OnOpen += OnOpen;
                webSocket.OnMessage += OnMessage;
                webSocket.OnError += OnError;
                webSocket.OnClose += OnClose;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                form2?.Close();
            }
        }

        public static void Connect()
        {
            if (webSocket == null)
            {
                Console.WriteLine("Can't connect, WebSocket is null");
                return;
            }

            Console.WriteLine("WebSocket connecting");
            webSocket.ConnectAsync();

            form2 = new Form2();
            form2.ShowDialog();
        }

        public static void Disconnect() => webSocket.CloseAsync();

        public static void Send(string packet)
        {
            if (webSocket.ReadyState == WebSocketState.Open)
            {
                webSocket.SendAsync(packet, null);
                Console.WriteLine("Packet sent: " + packet);
            }
            else
            {
                Console.WriteLine("WebSocket connection not ready, not sending packet");
            }
        }

        #endregion

        #region Events

        private static void OnClose(object sender, CloseEventArgs e)
        {
            Console.WriteLine("WebSocket connection closed: " + e.Reason);
        }

        private static void OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Packet received: " + e.Data);
        }

        private static void OnOpen(object sender, EventArgs e)
        {
            Console.WriteLine("WebSocket connection opened");
        }

        #endregion
    }
}
