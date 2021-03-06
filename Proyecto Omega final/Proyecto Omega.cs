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
            numUpDiasRecidencia.Value = 0;
            numUpAcompaniante.Value = 0;
            numUpAdultos.Value = 0;
            numUpNiños.Value = 0;
            btConfirmar.Enabled = false;
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtApellido, "");
            errorProvider1.SetError(txtCedula, "");
            errorProvider1.SetError(txtTelefono, "");
            dtFecha.ResetText();

        }  
        public void btComprar_Click(object sender, EventArgs e) {


            Form recibo = new Recibo();
           


            Datos.nombre = txtNombre.Text.ToUpper();
            Datos.apellido = txtApellido.Text.ToUpper();
            Datos.cedula = txtCedula.Text;
            Datos.telefono = txtTelefono.Text;


            
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

            Provincias();
            Factura();
            recibo.ShowDialog();

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
                precioDesayuno = 2.0 * numeroDiasRecidencia;
            } else
            {
                Hotel.desayuno = "---".ToUpper();
                precioDesayuno = 0;
            }
            
            if(chkbxAlmuerzo.Checked == true)
            {
                Hotel.almuerzo  = chkbxAlmuerzo.Text.ToString().ToUpper();
                precioAlmuerzo = 2.75 * numeroDiasRecidencia;
            }else
            {
                Hotel.almuerzo = "---".ToUpper();
                precioAlmuerzo = 0;
            }

            if (chkbxCena.Checked == true)
            {
                Hotel.cena= chkbxCena.Text.ToString().ToUpper();
                precioCena = 2.50 * numeroDiasRecidencia;
            }
            else
            {
                Hotel.cena = "---".ToUpper();
                precioCena = 0;
            }

            if (chkbxPiscina.Checked == true)
            {
                Hotel.piscina = chkbxPiscina.Text.ToString().ToUpper();
                precioPiscina = 7;
            } else
            {
                Hotel.piscina = "---".ToUpper();
                precioPiscina = 0;
            }

            Precios.precioAdicion = precioDesayuno + precioAlmuerzo + precioCena + precioPiscina;

        }

        //TRANSPORTE 
        public void Transporte() {
        
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
                    Precios.precioTransporte = 10;
                }
                else
                {
                    if (rbtAvion.Checked == true)
                    {
                        Hotel.transporte = rbtAvion.Text.ToUpper();
                        Precios.precioTransporte = 200;
                    }
                    else
                    {
                        Hotel.transporte = "Ninguno".ToUpper();
                        Precios.precioTransporte = 0;
                    }
                }
            }

        }

        //PROVINCIAS CON SUS RESPECTOS HOTELES Y PRECIOS
        public void Provincias() {
            int HabitacionMatrimonial =0;
            int HabitacionFamiliar =0;
            int HabitacionEscolar =0;
            int NumeroHabitacionMatrimonial = Convert.ToInt32(Habitaciones.matrimonial);
            int NumeroHabitacionfamiliar = Convert.ToInt32(Habitaciones.familiar);
            int NumeroHabitacionescolar = Convert.ToInt32(Habitaciones.escolar);
            int numeroDiasRecidencia = Convert.ToInt32(Hotel.diasRecidencia);

            switch (cmbProvincia.Text)
            {
                case "Azuay":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Luxury Danna Plaza Mayor";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Cuenca";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hostal Residencial Perla Cuencana";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Bolívar":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "San Rafael Hotel";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "La Rustica Hotel";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel Colonial";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Cañar":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hostería Santa Ana";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hospedaje El Castillo Ingapirca";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hostal Chasky";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Carchi":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hostería Totoral";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Tunas & Cabras Hotel";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Las Garza Alojamiento";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Chimborazo":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Quindolema Art Hotel And Gallery";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Shalom";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel El Altar";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Cotopaxi":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hotel San Agustín Plaza";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Makroz";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "El Castillo Hotel";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "El Oro":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hotel Oro Verde";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Veuxor";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Machala Chino Casa";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Esmeraldas":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hotel Casa Arnaldo";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Kemarios";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel la Barca";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Galápagos":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Royal Palm Galápagos";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Ikala Galápagos Hotel";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Galápagos verde Azul";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Guayas":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hotel Hilton Colon Guayaquil";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Courtyard by Marriot Guayaquil";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel Murali";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Imbabura":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Tunas & Cabras Hotel";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hostería Totoral";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel Miraflores";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Loja":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Sonesta Hotel Loja";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Libertador";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel Carrion";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Los Ríos":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hotel House Center";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hacienda la Danesa";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel Cachari";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Manabí":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hotel Ceibo Real";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Hamilton";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Casa lolita Hotel";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Morona-Santiago":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hostería Farallon";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Casa NOE";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Casa de la Abuela";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Napo":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Huasquila Amazon Lodge";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Selina Amazon Hotel";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Tres Ríos Jungle";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Orellana":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Gran Hotel De Lago El Coca";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel del Auca";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel Coca Imperial";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Pastaza":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Green House";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hostería Hachacaspi";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Miramelindo Spa Hotel";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Pichincha":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hotel Wyndham Garden";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Hilton Colón";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel Rosas de la Tola";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Santa Elena":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Howard Johnson by Wyndham Montañita";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Colón Salinas";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel Kundalini";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Santo Domingo de los Tsáchilas":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Victoria Suites Hostal";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Zaracay";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hostería Kasadasa";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Sucumbíos":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Gran Hotel de Lago";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Arazá";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel D´Mario";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
                case "Tungurahua":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hotel Florida";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Hotel Ambato";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hotel Emperador";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;

                case "Zamora-Chinchipe":
                    switch (cmbCategoria.Text)
                    {
                        case "★★★★★":
                            Hotel.nombre = "Hotel Samuria";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 75) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 165) * numeroDiasRecidencia;
                            break;
                        case "★★★":
                            Hotel.nombre = "Zamorano Real Hotel";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 60) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 90) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 135) * numeroDiasRecidencia;
                            break;
                        case "★":
                            Hotel.nombre = "Hostería Paraíso";
                            HabitacionMatrimonial = (NumeroHabitacionMatrimonial * 20) * numeroDiasRecidencia;
                            HabitacionFamiliar = (NumeroHabitacionfamiliar * 45) * numeroDiasRecidencia;
                            HabitacionEscolar = (NumeroHabitacionescolar * 90) * numeroDiasRecidencia;
                            break;
                    }
                    break;
            }


            Precios.preciosCamas = HabitacionMatrimonial + HabitacionFamiliar + HabitacionEscolar;
           
            
        }

        //FACTURA ES OBTENER TODOS LOS VALORES PARA EL TOTAL Y SUB TOTAL
        public void Factura() {
            int diasRecidencia = Convert.ToInt32(Hotel.diasRecidencia);
            int numAcompaniantes = Convert.ToInt32(Huespedes.acompanantes);
            int adultos = Convert.ToInt32(Huespedes.adultos);
            int ninios = Convert.ToInt32(Huespedes.ninos);

            subtotal = (Precios.precioTransporte*numAcompaniantes)  + Precios.preciosCamas + Precios.precioAdicion;
            Precios.pagoSubtotal = subtotal ;

            if (adultos > 5 || ninios > 7) {
                Precios.descuentos = subtotal * 0.13;
            }
            else Precios.descuentos = subtotal * 0.05;

            iva = subtotal * 0.12;
            Precios.pagoTotal = iva + subtotal - Precios.descuentos;
        }

       
    }
    }