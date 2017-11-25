using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Chapter14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            

            Thread t = new Thread(WriteY);
            t.Name = "Y"; 
            t.Start();

            for (int i = 0; i < 300; i++)
            {
                Console.WriteLine("X"+ i.ToString());
            }
        }

        private void WriteY()
        {
            for (int i = 0; i < 300; i++)
            {
                Console.WriteLine("Y" + i.ToString());
            }
        }
    }
}
