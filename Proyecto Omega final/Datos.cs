using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Omega_final {

    // DATOS
    static class Datos {
        static public String nombre;
        static public String apellido;
        static public String cedula;
        static public String telefono;
    }

    //HOTEL
    static class Hotel {
        static public String nombre;
        static public String categoria;
        static public String provincia;
        static public String fecha;
        static public String desayuno;
        static public String almuerzo;
        static public String cena;
        static public String piscina;
        static public String transporte;
        static public String diasRecidencia;
        }

    //HABITACIONES
    static class Habitaciones{
        static public String matrimonial;
        static public String familiar;
        static public String escolar;
    }

    //HUESPEDES
    static class Huespedes {
        static public String acompanantes;
        static public String adultos;
        static public String ninos;
    }

    //PRECIOS 
    static class Precios {
        static public double  preciosCamas;
        static public int precioTransporte = 0;
        static public double precioAdicion = 0;
        static public double pagoTotal = 0;
        static public double pagoSubtotal = 0;
        static public double descuentos;
    }

}