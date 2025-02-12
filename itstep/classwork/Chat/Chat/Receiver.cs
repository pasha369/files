﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class Receiver
    {
        private IPHostEntry ipHost;
        private IPAddress ipAddress;
        private IPEndPoint ipEndPoint;

        private Socket socket;

        private object state;
        private byte[] buffer;
        private string content;
        public delegate void ReceiveData (String msg);

        public event ReceiveData onReseive;

        public Receiver(string ip, int port)
        {
            
            ipAddress = IPAddress.Parse(ip);
            ipEndPoint = new IPEndPoint(ipAddress, port);

            buffer = new byte[1024];
            socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        public void BeginListen()
        {
            Debug.WriteLine("BeginListen");
            try
            {
                socket.Bind(ipEndPoint);
                socket.Listen(25);

           
                socket.BeginAccept(new AsyncCallback(OnAccept), socket);
            }
            catch (Exception ex)
            {
                
                var msg = ex.Message;
                throw;
            }
        }

        private void OnAccept(IAsyncResult ar)
        {
            Debug.WriteLine("OnAccept");

            Socket listener = (Socket) ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            listener.BeginAccept(new AsyncCallback(OnAccept), listener);

            handler.BeginReceive(buffer, 0, 1024, 0, new AsyncCallback(OnReceive), handler);
            
        }

        private void OnReceive(IAsyncResult ar)
        {
            Debug.WriteLine("OnReceive");
            Socket handler= (Socket) ar.AsyncState;

            int bytes = handler.EndReceive(ar);

            content = Encoding.ASCII.GetString(buffer, 0, bytes);
            if (onReseive != null)
            {
                onReseive(content);
            }
            if (content.IndexOf("<EOF>") > 0)
            {

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            if (bytes == 1024)
            {

                   handler.BeginReceive(buffer, 0, 1024, 0, new AsyncCallback(OnReceive), handler);
            }


        }




    }
}
