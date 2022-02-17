using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Omega_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        struct Informacion{
            String nombre;
            String apellido;
            String cedula;
            String numero;
        };
        struct Fecha{ // no se como poner la estruc fecha 
            
        };
        struct Hotel{
            char categoria;
            String provincia;
            String adicionales;
            String transporte;
            int presupuesto;

        };
        struct Habitaciones{
            int matrimonial;
            int familiar;
            int escolar;
        }
        struct Huespedes{
            int adultos;
            int ninos;
            int acompanantes;
        };
    }
}
