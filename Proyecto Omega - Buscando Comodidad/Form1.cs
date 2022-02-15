using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Omega
{

    public struct Informacion
    {
        public string nombre;
        public string apellido;
        public string cedula;

    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //No sirve es 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
