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
    public partial class Recibo : Form
    {
        public Recibo()
        {
            InitializeComponent();
        }

        private void Recibo_Load(object sender, EventArgs e){
          
            txtRecibo.Text = "Informacion" + "\r\n" +
                             "Nombre:\t\t\t" + Datos.nombre + "\r\n" +
                             "Apellido:\t\t\t" + Datos.apellido + "\r\n" +
                             "Cedula:\t\t\t" + Datos.cedula + "\r\n" +
                             "Numero:\t\t\t" + Datos.telefono + "\r\n" +
                             "\r\n" +
                             "Hotel" + "\r\n" +
                             "Nombre:\t\t\t" + Hotel.nombre + "\r\n" +
                             "Categoria:\t\t" + Hotel.categoria + "\r\n" +
                             "Provincia:\t\t\t" + Hotel.provincia + "\r\n" +
                             "Fecha de reservacion:\t" + Hotel.fecha + "\r\n" +
                             "Dias de recidencia:\t\t" + Hotel.diasRecidencia + "\r\n" +
                             "Transporte:\t\t" + Hotel.transporte + "\r\n" +
                             "Adicionales:\t\t" + Hotel.desayuno + "\r\n" +
                             "\t\t\t" + Hotel.almuerzo + "\r\n" +
                             "\t\t\t" + Hotel.cena + "\r\n" +
                             "\t\t\t" + Hotel.piscina + "\r\n" +
                             "\r\n" +
                             "Habitaciones" + "\r\n" +
                             "Matrimonial:\t\t" + Habitaciones.matrimonial + "\r\n" +
                             "Familiar:\t\t\t" + Habitaciones.familiar + "\r\n" +
                             "Escolar:\t\t\t" + Habitaciones.escolar + "\r\n" +
                             "\r\n" +
                             "Huespedes" + "\r\n" +
                             "Acompañantes:\t\t" + Huespedes.acompanantes + "\r\n" +
                             "Adultos\t\t\t" + Huespedes.adultos + "\r\n" +
                             "Niños:\t\t\t" + Huespedes.ninos + "\r\n" +
                             "\r\n" +
                             "Precio por habitacion:\t" + Precios.preciosCamas + "\r\n" +
                             "Subtotal:\t\t\t" + Precios.pagoSubtotal + "\r\n" +
                             "Total:\t\t\t" + Precios.pagoTotal + "\r\n";
           
        }

        private void btnConfirmar_Click(object sender, EventArgs e){
            MessageBox.Show("RESERVACION REALIZADA CON EXITO \n ♥ Disfute de sus vacaciones ♥ ", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
