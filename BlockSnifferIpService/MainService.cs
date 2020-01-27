using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO.Pipes;
using System.Text;
using System.Threading;

namespace BlockSnifferIpService
{
    public partial class MainService : ServiceBase
    {
        private NamedPipeServerStream pipeServer;
        private bool bReceiverThreadLoop;
        private string sReceiverPipeName = "BlockSnifferIpServiceReceiverPipe";
        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            bReceiverThreadLoop = true;
            new Thread(new ThreadStart(ReceiverThread)).Start();
        }

        protected override void OnStop()
        {
            bReceiverThreadLoop = false;
            if(!pipeServer.IsConnected)
            {
                NamedPipeClientStream pipeClient = new NamedPipeClientStream(sReceiverPipeName);
                pipeClient.Connect();
            }
            pipeServer.Close();
            pipeServer.Dispose();
            pipeServer = null;
        }

        void ReceiverThread()
        {
            try
            {
                pipeServer = new NamedPipeServerStream(sReceiverPipeName);
                pipeServer.WaitForConnection();
                while (bReceiverThreadLoop)
                {
                    pipeServer.Close();
                }
            }catch (Exception ex)
            {

            }
        }

        void ReceiverHandlerThread()
        {

        }
    }
}
