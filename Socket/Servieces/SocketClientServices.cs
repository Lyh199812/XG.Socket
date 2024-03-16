using Prism.Commands;
using Prism.Mvvm;
using SocketTest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketTeest.Servieces
{
    public class SocketClientServices:BindableBase
    {
        public SocketClientServices() 
        {
            ConnectionCommand = new DelegateCommand(Connect);
        }
        #region 成员变量
        //1、创建一个Socket
        Socket socketClient=null;
        //2、创建一个线程处理从服务端接收到的数据
        Thread thrClient = null;

        #endregion


        #region 视图属性
        private bool isConnect;
        public bool IsConnect { get { return isConnect; } set { isConnect = value; RaisePropertyChanged(); } }
        private string communicationRecord;
        public string CommunicationRecord { get { return communicationRecord; } set { communicationRecord = value;RaisePropertyChanged(); } }

        private string serverIPAddress;
        public string ServerIPAddress {  get { return serverIPAddress; } set { serverIPAddress = value; RaisePropertyChanged(); } }

        private string port;
        public string Port { get { return port; } set { port = value; RaisePropertyChanged(); }}

        private string clientName;
        public string ClientName { get {  return clientName; } set { clientName = value; RaisePropertyChanged(); } }
        #endregion


        #region 方法
        public Action<string, int> AddLog;
        #region 连接
        public DelegateCommand ConnectionCommand { get; set; }
        private void Connect()
        {
            IPAddress address=IPAddress.Parse(ServerIPAddress);
            IPEndPoint ipe = new IPEndPoint(address, int.Parse(Port));
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                AddLog?.Invoke($"{ServerIPAddress}:{Port} 与服务器连接中.......", 0);
                socketClient.Connect(ipe);
                AddLog?.Invoke($"{ServerIPAddress}:{Port} 连接成功", 0);
                thrClient = new Thread(ReceiceMeg);
                thrClient.IsBackground = true;
                thrClient.Start();
            }
            catch (Exception ex)
            {
                AddLog?.Invoke($"{ServerIPAddress}:{Port} 连接失败"+ex.Message, 1);
            }

        }

        #endregion

        private void ReceiceMeg()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
