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

        //VARIABLES PARA EL FORM DE PROYECTO OMEGA
        int verificarnombre = 0;
        int verificarCedula = 0;
        int verificarApellido = 0;
        int verificarTelefono = 0;
        double iva = 0;
        double subtotal = 0;

        //FUNCION PARA OBJETOS CUANDO SE ABRE EL PROGRAMA
        private void Form1_Load(object sender, EventArgs e) {
            btConfirmar.Enabled = false;
        }

        //BOTONES
        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void btnLimpiar_Click(object sender, EventArgs e) {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            numUpMatrimonial.Value = 0;
            numUpFamiliar.Value = 0;
            numUpEscolar.Value = 0;
            cmbCategoria.Text = "";
            cmbProvincia.Text = "";
            rbtCarro.Checked = false;
            rbtBus.Checked = false;
            rbtAvion.Checked = false;
            chkbxDesayuno.Checked = false;
            chkbxAlmuerzo.Checked = false;
            chkbxCena.Checked = false;
            chkbxPiscina.Checked = false;
            numUpAdultos.Value = 0;
            numUpNiños.Value = 0;
        }  
        public void btComprar_Click(object sender, EventArgs e) {


            Form recibo = new Recibo();
            recibo.Show();


            Datos.nombre = txtNombre.Text.ToUpper();
            Datos.apellido = txtApellido.Text.ToUpper();
            Datos.cedula = txtCedula.Text;
            Datos.telefono = txtTelefono.Text;


            Provincias();
            Hotel.categoria = cmbCategoria.Text;
            Hotel.provincia = cmbProvincia.Text.ToUpper();
            Hotel.fecha = dtFecha.Value.ToString("dd-MM-yyyy");
            Hotel.diasRecidencia = numUpDiasRecidencia.Value.ToString();
            Adiciones();
            Transporte();


            Habitaciones.matrimonial = numUpMatrimonial.Value.ToString();
            Habitaciones.familiar = numUpFamiliar.Value.ToString();
            Habitaciones.escolar = numUpEscolar.Value.ToString();


            Huespedes.acompanantes = numUpAcompaniante.Value.ToString();
            Huespedes.adultos = numUpAdultos.Value.ToString();
            Huespedes.ninos = numUpNiños.Value.ToString();

            Factura();

        }
        // FUNCIONES A LLAMAR EN LAS TXTBOX PARA LA VALIDACION DE LOS DATOS
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            verificacionNombre();
            validacion();
        }
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            verificacionApellido();
            validacion();
        }
        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            verificacionCedula();
            validacion();
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            verificacionTelefono();
            validacion();
        }

        //VALLIDACION DE DATOS EN TXTBOX
        public void verificacionNombre()
        {
            if (txtNombre.Text.Trim() != String.Empty && txtNombre.Text.All(Char.IsLetter))
            {
                verificarnombre++;
                errorProvider1.SetError(txtNombre, "");
            }
            else
            {
                if (!(txtNombre.Text.All(Char.IsLetter)))
                {
                    errorProvider1.SetError(txtNombre, "El nombre solo debe contener letras");
                }
                else
                {
                    errorProvider1.SetError(txtNombre, "Debe incluir su nombre");
                }
                btConfirmar.Enabled = false;
                txtNombre.Focus();
            }
        }
        public void verificacionApellido()
        {
            if (txtApellido.Text.Trim() != String.Empty && txtApellido.Text.All(Char.IsLetter))
            {
                verificarApellido++;
                errorProvider1.SetError(txtApellido, "");
            }
            else
            {
                if (!(txtApellido.Text.All(Char.IsLetter)))
                {
                    errorProvider1.SetError(txtApellido, "El apellido solo debe contener letras");
                }
                else
                {
                    errorProvider1.SetError(txtApellido, "Debe incluir su apellido");
                }
                btConfirmar.Enabled = false;
                txtApellido.Focus();
            }
        }
        public void verificacionCedula()
        {
            if (txtCedula.Text.Trim() != String.Empty && txtCedula.Text.All(Char.IsNumber))
            {
                verificarCedula++;
                errorProvider1.SetError(txtCedula, "");
            }
            else
            {
                if (!(txtCedula.Text.All(Char.IsNumber)))
                {
                    errorProvider1.SetError(txtCedula, "La cedula solo debe contener numeros");
                }
                else
                {
                    errorProvider1.SetError(txtCedula, "Debe incluir su cedula");
                }
                btConfirmar.Enabled = false;
                txtCedula.Focus();
            }
        }
        public void verificacionTelefono()
        {
            if (txtTelefono.Text.Trim() != String.Empty && txtTelefono.Text.All(Char.IsNumber))
            {
                verificarTelefono++;
                errorProvider1.SetError(txtTelefono, "");
            }
            else
            {
                if (!(txtTelefono.Text.All(Char.IsNumber)))
                {
                    errorProvider1.SetError(txtTelefono, "El telefono solo debe contener numeros");
                }
                else
                {
                    errorProvider1.SetError(txtTelefono, "Debe incluir su telefono");
                }
                btConfirmar.Enabled = false;
                txtTelefono.Focus();
            }
        }
        public void validacion()
        {
            if (verificarnombre > 0)
            {
                if (verificarApellido > 0)
                {
                    if (verificarCedula > 0)
                    {
                        if (verificarTelefono > 0)
                        {
                            btConfirmar.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                btConfirmar.Enabled = false;
            }
        }




        //ADICIONES
        public void Adiciones() {
            double precioDesayuno;
            double precioAlmuerzo;
            double precioCena;
            double precioPiscina;
            int numeroDiasRecidencia = Convert.ToInt32(Hotel.diasRecidencia);

            if (chkbxDesayuno.Checked == true)
            {
                Hotel.desayuno = chkbxDesayuno.Text.ToString().ToUpper();
                precioDesayuno = 2.50 * numeroDiasRecidencia;
            } else
            {
                Hotel.piscina = "ninguno".ToUpper();
                precioDesayuno = 0;
            }
            
            if(chkbxAlmuerzo.Checked == true)
            {
                Hotel.almuerzo  = chkbxAlmuerzo.Text.ToString().ToUpper();
                precioAlmuerzo = 3.50 * numeroDiasRecidencia;
            }else
            {
                Hotel.piscina = "ninguno".ToUpper();
                precioAlmuerzo = 0;
            }

            if (chkbxCena.Checked == true)
            {
                Hotel.cena= chkbxCena.Text.ToString().ToUpper();
                precioCena = 2.50 * numeroDiasRecidencia;
            }
            else
            {
                Hotel.piscina = "ninguno".ToUpper();
                precioCena = 0;
            }

            if (chkbxPiscina.Checked == true)
            {
                Hotel.piscina = chkbxPiscina.Text.ToString().ToUpper();
                precioPiscina = 10;
            } else
            {
                Hotel.piscina = "ninguno".ToUpper();
                precioPiscina = 0;
            }

            Precios.precioAdicion = precioDesayuno + precioAlmuerzo + precioCena + precioPiscina;

        }

        //TRANSPORTE 
        //PROVINCIAS CON SUS RESPECTOS HOTELES Y PRECIOS
        public void Transporte()
        {

            if (rbtCarro.Checked == true)
            {
                Hotel.transporte = "Alquiler Automovil".ToUpper();
                Precios.precioTransporte = 100;
            }
            else
            {
                if (rbtBus.Checked == true)
                {
                    Hotel.transporte = rbtBus.Text.ToUpper();
                    Precios.precioTransporte = 15;
                }
                else
                {
                    if (rbtAvion.Checked == true)
                    {
                        Hotel.transporte = rbtAvion.Text.ToUpper();
                        Precios.precioTransporte = 300;
                    }
                    else
                    {
                        Hotel.transporte = "Ninguno".ToUpper();
                        Precios.precioTransporte = 0;
                    }
                }
            }

        }
        public void Provincias() {
            int NumeroHabitacionMatrimonial = Convert.ToInt32(Habitaciones.matrimonial);
            int NumeroHabitacionfamiliar = Convert.ToInt32(Habitaciones.familiar);
            int NumeroHabitacionescolar = Convert.ToInt32(Habitaciones.escolar);

            if (cmbProvincia.Text == "Pichincha")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }

            }
            if (cmbProvincia.Text == "Cotopaxi")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Hotel San Agustín Plaza";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Hotel Makroz";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "El Castillo Hotel";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }

            }
            if (cmbProvincia.Text == "Azuay")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Luxury Danna Plaza Mayor";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Hotel Cuenca";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Hostal Residencial Perla Cuencana";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Bolivar")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "San Rafael Hotel";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "La Rustica Hotel";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Hotel Colonial";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Cañar")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Hostería Santa Ana";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Hospedaje El Castillo Ingapirca";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Hostal Chasky";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Carchi")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Hostería Totoral";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Tunas & Cabras Hotel";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Las Garza Alojamiento";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Chimborazo")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Quindolema Art Hotel And Gallery";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Hotel Shalom";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Hotel El Altar";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "El Oro")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Hotel Oro Verde";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Hotel Veuxor";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Machala Chino Casa";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Esmeraldas")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Hotel Casa Arnaldo";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Hotel Kemarios";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Hotel la Barca";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Galapagos")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Royal Palm Galápagos";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Ikala Galápagos Hotel";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Galápagos verde Azul";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Guayas")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Hotel Hilton Colon Guayaquil";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Courtyard by Marriot Guayaquil";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Hotel Murali";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Imbabura")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "loja")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Los Ríos")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Manabí")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Morona-Santiago")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Napo")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Orellana")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Pastaza")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Santa Elena")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Santo Domingo")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Sucumbíos")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Tungurahua")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            if (cmbProvincia.Text == "Zamora-Chinchipe")
            {
                if (cmbCategoria.Text == "★★★★★")
                {
                    Hotel.nombre = "Prueba 5";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 80;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 100;
                    Precios.precioEscolar = NumeroHabitacionescolar * 165;
                }
                if (cmbCategoria.Text == "★★★")
                {
                    Hotel.nombre = "Prueba 3";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 60;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 90;
                    Precios.precioEscolar = NumeroHabitacionescolar * 135;

                }
                if (cmbCategoria.Text == "★")
                {
                    Hotel.nombre = "Prueba 1";
                    Precios.precioMatrimonial = NumeroHabitacionMatrimonial * 20;
                    Precios.precioFamiliar = NumeroHabitacionfamiliar * 50;
                    Precios.precioEscolar = NumeroHabitacionescolar * 90;

                }
            }
            Precios.preciosCamas = Precios.precioMatrimonial + Precios.precioFamiliar + Precios.precioEscolar;
        }
        //FACTURA ES OBTENER TODOS LOS VALORES PARA EL TOTAL Y SUB TOTAL
        public void Factura() {
            int diasRecidencia = Convert.ToInt32(Hotel.diasRecidencia);
            int numAcompaniantes = Convert.ToInt32(Huespedes.acompanantes);
            int adultos = Convert.ToInt32(Huespedes.adultos);
            int ninios = Convert.ToInt32(Huespedes.ninos);

            
            subtotal = (Precios.precioTransporte*numAcompaniantes)  + (Precios.preciosCamas*diasRecidencia) ;
            Precios.pagoSubtotal = subtotal ;

            if (adultos > 5 || ninios > 3)
            {
                Precios.descuentos = subtotal * 0.13;
            }
            else Precios.descuentos = subtotal * 0.05;

            
            iva = subtotal * 0.12;
            Precios.pagoTotal = iva + subtotal - Precios.descuentos;
        }
            
         

        
    }
    }