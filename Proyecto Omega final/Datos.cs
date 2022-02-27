using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Omega_final
{
     static class Datos{
       static public String nombre;
       static public String apellido;
       static public String cedula;
       static public String telefono;
    }
    static class Hotel{
        static public String categoria;
        static public String provincia;
        static public String fecha;
        static public String adiciones;
        static public String transporte;
    }
    static class Habitaciones {
        static public String matrimonial;
        static public String familiar;
        static public String escolar;
    }
    static class Huespedes{
        static public String acompanantes;
        static public String adultos;
        static public String ninos;
    }

    static class Precios
    {
        static int hotel = 0;
        static int habitacion = 0;
        static int adicional=0;
        static int niños=0;
        static int adulto=0;
        static int trasporte =0;

    }
}
