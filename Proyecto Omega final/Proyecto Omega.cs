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

        int verificarnombre = 0;
        int verificarCedula = 0;
        int verificarApellido=0;
        int verificarNumero=0;
        
        public void verificacionNombre() {
            if (txtNombre.Text.Trim() != String.Empty && txtNombre.Text.All(Char.IsLetter)) {
                verificarnombre++;
                errorProvider1.SetError(txtNombre, "");
            } else {
                if (!(txtNombre.Text.All(Char.IsLetter))) {
                    errorProvider1.SetError(txtNombre, "El nombre solo debe contener letras");
                } else {
                    errorProvider1.SetError(txtNombre, "Debe incluir su nombre");
                }
                btConfirmar.Enabled = false;
                txtNombre.Focus();
            }
        }
        public void verificacionApellido() {
            if (txtApellido.Text.Trim() != String.Empty && txtApellido.Text.All(Char.IsLetter)) {
                verificarApellido   ++;
                errorProvider1.SetError(txtApellido, "");
            } else {
                if (!(txtApellido.Text.All(Char.IsLetter))) {
                    errorProvider1.SetError(txtApellido, "El apellido solo debe contener letras");
                } else {
                    errorProvider1.SetError(txtApellido, "Debe incluir su apellido");
                }
                btConfirmar.Enabled = false;
                txtApellido.Focus();
            }
        }
        public void verificacionCedula() {
            if (txtCedula.Text.Trim() != String.Empty && txtCedula.Text.All(Char.IsNumber)) {
                verificarCedula ++;
                errorProvider1.SetError(txtCedula, "");
            } else {
                if (!(txtCedula.Text.All(Char.IsNumber))) {
                    errorProvider1.SetError(txtCedula, "La cedula solo debe contener numeros");
                } else {
                    errorProvider1.SetError(txtCedula, "Debe incluir su cedula");
                }
                btConfirmar.Enabled = false;
                txtCedula.Focus();
            }
        }
        public void verificacionTelefono() {
            if (txtTelefono.Text.Trim() != String.Empty && txtTelefono.Text.All(Char.IsNumber)) {
               verificarNumero++;
                errorProvider1.SetError(txtTelefono, "");
            } else {
                if (!(txtTelefono.Text.All(Char.IsNumber))) {
                    errorProvider1.SetError(txtTelefono, "El telefono solo debe contener numeros");
                } else {
                    errorProvider1.SetError(txtTelefono, "Debe incluir su telefono");
                }
                btConfirmar.Enabled = false;
                txtTelefono.Focus();
            }
            if (verificarnombre > 0 || verificarApellido > 0 || verificarCedula > 0 || verificarNumero > 0)
            {
                btConfirmar.Enabled = true;


            }
            else { btConfirmar.Enabled = false; }
        }
        
        private void btnLimpiar_Click(object sender, EventArgs e) {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            numUpMatrimonial.Value =0;
            numUpFamiliar.Value = 0;
            numUpEscolar.Value = 0;
            cmbCategoria.Text = "";
            cmbProvincia.Text = "";
            rbtCarro.Checked = false;
            rbtBus.Checked = false;
            rbtAvion.Checked = false;
            rbtDesayunos.Checked = false;
            rbtAlmuerzo.Checked = false;
            rbtCena.Checked = false;
            rbtPiscina.Checked = false;
            numUpAcompaniante.Value = 0;
            numUpAdultos.Value = 0;
            numUpNiños.Value = 0;
        }
        private void btnSalir_Click(object sender, EventArgs e){
            this.Close();
        }
        public void btComprar_Click(object sender, EventArgs e) {
            
            Form recibo = new Recibo();
            recibo.Show();
            Datos.nombre = txtNombre.Text.ToUpper();  
            Datos.apellido = txtApellido.Text.ToUpper();
            Datos.cedula = txtCedula.Text;
            Datos.telefono = txtTelefono.Text;

            Hotel.categoria = cmbCategoria.Text;
            Hotel.provincia = cmbProvincia.Text.ToUpper();
            Hotel.fecha = dtFecha.Value.ToString("dd-MM-yyyy");
            Hotel.adiciones =  // esta pendienbte porque es radio button 
            Hotel.transporte = // x2 lo que dije arriba

            Habitaciones.matrimonial = numUpMatrimonial.Value.ToString();
            Habitaciones.familiar = numUpFamiliar.Value.ToString();
            Habitaciones.escolar = numUpEscolar.Value.ToString();

            Huespedes.acompanantes = numUpAcompaniante.Value.ToString();
            Huespedes.adultos = numUpAdultos.Value.ToString();
            Huespedes.ninos = numUpNiños.Value.ToString();

        }
        int precio;
        public void provincias()
        {
            if (Hotel.provincia == "Pichincha")
            {
                
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            btConfirmar.Enabled = false;
            
        }
        private void txtNombre_TextChanged(object sender, EventArgs e){
            verificacionNombre();
        }
        private void txtApellido_TextChanged(object sender, EventArgs e) {
            verificacionApellido();
        }
        private void txtCedula_TextChanged(object sender, EventArgs e) {
            verificacionCedula();
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e) {
            verificacionTelefono();
        }

        
        }
    }

