using Prism.Mvvm;
using SocketTest.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SocketTest.Servieces
{
    public  class SocketServerServices
    {
        public SocketServerServices()
        {
            threadListen = new Thread(ListenConnecting);
            threadListen.IsBackground = true;
            myAddOnLine = AddOnLine;

        }
        public string ReceivedMsg { get;set; }


        public bool IsOpen { get; set; } = false;

        //创建URL与Socket的字典集合
        public  Dictionary<string ,Socket> DicSocket = new Dictionary<string, Socket>();

        public  Socket socket { get; set; } = null;

        public List<string> socketClientsURL { get; set; } = new List<string>();

        //创建负责监听客户端连线的线程
        private  Thread threadListen;

        //声明委托
        delegate  void AddOnLineDelegate(Socket sockClient,bool bl);
          AddOnLineDelegate myAddOnLine;
        public Action<string> RaiseAction;



        public  OperateResult Open(string iPAddress,int port)
        {

            try
            {
                //创建负责监听的套接字 注意其中参数：IPV4 字节流 TCP
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress address = IPAddress.Parse(iPAddress);

                //根据IPAddress以及端口号创建IPE对象
                IPEndPoint endPoint = new IPEndPoint(address, port);
                socket.Bind(endPoint);
            }
            catch (Exception ex)
            {

                return new OperateResult() { IsSuccess=false ,Message=ex.Message};
            }
            socket.Listen(10);
            threadListen.Start() ;
            IsOpen=true;
            return OperateResult.CreateSuccessResult();
        }

        public OperateResult Send(string strSend,List<string> arrClients)
        {
            byte[] arrMsg = Encoding.UTF8.GetBytes(strSend);

            foreach (var item in arrClients)
            {
                DicSocket[item].Send(arrMsg);
                string Msg = "[发送]" + item + "  " + strSend + "\r\n";
                AddMsg(Msg);
            }
            RaiseAction.Invoke("SocketServerServices");
            return OperateResult.CreateSuccessResult();
        }

        private  void ListenConnecting()
        {

            while (true)
            {
                //一旦监听到客户端的连接，将会创建一个与该客户端连接的套接字
                Socket sockClient = socket.Accept();
                myAddOnLine.Invoke(sockClient,true);
                string client = sockClient.RemoteEndPoint.ToString();
                AddMsg(client + "上线了");
                DicSocket.Add(client, sockClient);
                //开启接收线程
                Thread thr = new Thread(ReceiveMeg);
                thr.IsBackground = true;
                thr.Start(sockClient);
            };

        }

        private void ReceiveMeg(Object socketClient)
        {
           Socket socket = socketClient as Socket;
           while (true)
            {
                if(socket.RemoteEndPoint.ToString().Contains("54922"))
                {

                }
                //定义一个2M的缓冲区
                byte[] buffer = new byte[1024*1024*2];
                int length = -1;
                length = socket.Receive(buffer);
                if(length == 0)
                {
                    string str =socket.RemoteEndPoint.ToString();
                    //从列表中移除URL
                    myAddOnLine.Invoke(socket, false);
                    AddMsg(socket.RemoteEndPoint.ToString() + "下线了");
                    break;

                }
                else
                {
                    string str =$"[接收]_{socket.RemoteEndPoint.ToString()}\r\n {Encoding.UTF8.GetString(buffer, 0, length)}";
                    AddMsg(str);
                    RaiseAction.Invoke("SocketServerServices");
                }
            }
        }

        public  void AddOnLine(Socket sockClient,bool bl)
        {
            if (bl)
            {
                socketClientsURL.Add(sockClient.RemoteEndPoint.ToString());
            }
            else
            {
                socketClientsURL.Remove(sockClient.RemoteEndPoint.ToString());
            }
            socketClientsURL = new List<string>(socketClientsURL);
            RaiseAction.Invoke("SocketServerServices");

        }

        public void AddMsg(string Info)
        {
            ReceivedMsg += Info + "\r\n";
        }
    }
}
