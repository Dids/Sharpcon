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

        public static string ConnectionString(string address, string port, string password) => $"ws://{address}:{port}/{password}";

        public static void Initialise(string url)
        {
            webSocket = new WebSocket(url);

            webSocket.OnOpen += OnOpen;
            webSocket.OnMessage += OnMessage;
            webSocket.OnError += OnError;
            webSocket.OnClose += OnClose;
        }

        public static void Connect()
        {
            form2 = new Form2();
            form2.ShowDialog();

            webSocket.Connect();
        }

        public static void Disconnect() => webSocket.Close();

        public static void Send(string packet)
        {
            webSocket.Send(packet);
            MessageBox.Show("Packet sent!");
        }

        #endregion

        #region Events

        private static void OnClose(object sender, CloseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnError(object sender, ErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnMessage(object sender, MessageEventArgs e)
        {

        }

        private static void OnOpen(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
