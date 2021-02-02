using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDeneme
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        InnerOperation ınnerOperation = new InnerOperation();

        protected override void OnStart(string[] args)
        {
            ınnerOperation.Start();
        }

        protected override void OnStop()
        {
            ınnerOperation.Stop();
        }
    }
}
