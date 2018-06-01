using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDde;
using NDde.Client;

namespace dde
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DdeClient client = new DdeClient("MMSDDE", "FUSA");
            client.Connect();

            client.Advise += client_Advise;
            client.StartAdvise("B1YM&.101", 1, true, 60000);
            client.StartAdvise("B1YM&.184", 1, true, 60000);
            
        }

        void client_Advise(object sender, DdeAdviseEventArgs e)
        {
            Console.Write(e.Text);
        }

    }
}
