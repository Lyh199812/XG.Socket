using Prism.Commands;
using Prism.Mvvm;
using SocketTest.Common;
using SocketTest.Servieces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SocketTest.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        public MainWindowViewModel()
        {
            OpenCommand=new DelegateCommand(Open,CanOpen);
            SendCommand = new DelegateCommand<object>(Send);
            addr = ipEntry.AddressList;
            IPAddress = "192.168.1.5";
            SocketServerServices=new SocketServerServices();
            SocketServerServices.RaiseAction = RaisePropertyChangedDelegate;
        }
        IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress[] addr;


        private string _sendMsg {  get; set; }
        public string SendMsg
        {
            get
            {
                return _sendMsg;
            }
            set
            {
                _sendMsg = value;
                RaisePropertyChanged();
            }
        }

        private string _returnInfo;
        public string ReturnInfo
        {
            get 
            {
                return _returnInfo;
            }
            set 
            {
                _returnInfo = value;
                RaisePropertyChanged();
            }
        }

        private string _iPAddress;
        public string IPAddress

        {
            get
            {
                return _iPAddress;
            }
            set
            {
                _iPAddress = value;
                RaisePropertyChanged();
                OpenCommand.RaiseCanExecuteChanged();

            }
        } 

        private string _port;
        public string Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
                RaisePropertyChanged();
                OpenCommand.RaiseCanExecuteChanged();
            }
        }

        public SocketServerServices SocketServerServices { get; set; }

        public DelegateCommand OpenCommand { get; set; }
        public DelegateCommand<object> SendCommand { get; set; }

        public  void Open()
        {
            if(SocketServerServices.IsOpen)
            {
                RaisePropertyChanged("SocketServerServices");
                return;
            }
           var rst= SocketServerServices.Open(IPAddress, int.Parse(Port));
           if(rst.IsSuccess)
            {
                ReturnInfo = "打开成功";
            }
            else
            {
                ReturnInfo = "打开失败   " + rst.Message;

            }
            OpenCommand.RaiseCanExecuteChanged();
        }
        public bool CanOpen()
        {
            if(SocketServerServices.IsOpen)
            {
                return false;
            }
            else
            {
                bool canOpen = !(string.IsNullOrEmpty(_port) || string.IsNullOrEmpty(_iPAddress));
                if (!canOpen)
                {
                    ReturnInfo = "IP地址或端口号为空";
                }
                return canOpen;
            }
           
        }
        
        public void Send(object list)
        {
            IList items = (IList)list;
            List<string> collection = items.Cast<string>().ToList();
            SocketServerServices.Send(SendMsg, collection);
        }
        public bool CanSend(object list)
        {
            return SocketServerServices.IsOpen;
        }
        public void RaisePropertyChangedDelegate(string Name)
        {
            RaisePropertyChanged(Name);
      
        }

    }
}
