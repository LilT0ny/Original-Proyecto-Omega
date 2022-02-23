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
        public struct Fecha
        { // no se como poner la estruc fecha 
            public int dia;
            public int mes;
            public int anio;
        };
        public struct Informacion{
            public String nombre;
            public String apellido;
            public String cedula;
            public String numero;
                 
        };
        public struct Hotel
        {
            public string categoria;
            public String provincia;
            public String adicionales;
            public String transporte;
            public int presupuesto;
        };
        public struct Habitaciones
        {
            public int matrimonial;
            public int familiar;
            public int escolar;
        };
        public struct Huespedes
        {
            public int adultos;
            public int ninos;
            public int acompanantes;
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

        public void btComprar_Click(object sender, EventArgs e)
        {
            Informacion clienteuno;
            clienteuno.nombre=txtNombre.Text;
            clienteuno.apellido=txtApellido.Text;
            clienteuno.cedula = txtCedula.Text;
            clienteuno.numero=txtNumero.Text;

            Hotel uno;
            uno.categoria = cmbCategoria.Text;
            uno.provincia = cmbProvincia.Text;
            uno.transporte = txtNombre.Text;
            //falta presupueso;



            
        }
    }
}
