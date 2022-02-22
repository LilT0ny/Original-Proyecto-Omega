using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Omega_final {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        struct Informacion{
            String nombre;
            String apellido;
            String cedula;
            String numero;
            String provincia;
            String categoria;
            String desayuno;
            String almuerzo;
            String cena;
            String piscina;
            String alquilerAuto;
            String bus;
            String avion;
            int adultos;
            int ninos;
            int acompanantes;
            int matrimonial;
            int familiar;
            int escolar;
            
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
        };
        struct Huespedes{
            int adultos;
            int ninos;
            int acompanantes;
        };

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtNumero.Text = "";
            txtPresupuesto.Text = "";
            cmbCategoria.Text = "";
            cmbProvincia.Text = "";
            // aqui va lo de btngroup

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbtDesayunos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtPiscina_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
