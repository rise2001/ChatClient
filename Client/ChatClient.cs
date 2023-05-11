using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Threading;

namespace Client
{
    internal class ChatClient
    {
        private Socket _socket;
        private Action<byte[]> _textAction;

        private const int BUFFER_SIZE = 600;
        private static readonly byte[] _buffer = new byte[BUFFER_SIZE];

        public ChatClient(Action<byte[]> textAction)
        {
            _textAction = textAction;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Connect(string adress, int port)
        {
            try
            {
                IPEndPoint remoteIP = new IPEndPoint(IPAddress.Parse(adress), port);
                _socket.Connect(remoteIP);
                _socket.BeginReceive(_buffer, 0, BUFFER_SIZE, SocketFlags.None, new AsyncCallback(ReceiveCallback), _socket);

                return true;
            } catch(Exception ex)
            {
                return false;
            }
        }

        void ReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int received = socket.EndReceive(ar); //количество принятых байт по средствам EndReceive
            byte[] dataBuf = new byte[received]; //запись принятых байтов в массив 
            Array.Copy(_buffer, dataBuf, received);
            string text = Encoding.UTF8.GetString(dataBuf); //запись массива в строку
            Console.WriteLine("Message received: " + text);

            _textAction.Invoke(dataBuf);

            socket.BeginReceive(_buffer, 0, BUFFER_SIZE, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        }

        public bool Disconnect()
        {
            try
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SendMessage(byte[] data)
        {
            try
            {
                _socket.Send(data);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
