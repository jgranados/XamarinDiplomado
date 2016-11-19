using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Modulo2.Leccion4.Android.ListView
{
   public class Empleado
    {
        public override string ToString()
        {
            return Nombre; 
        }
        private string nombre;
        private string puesto;
        private string correo;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        public string Puesto { get { return puesto; } set { puesto = value; } }

        public string Correo { get { return correo; } set { correo = value; } }

        public Empleado(string nombre, string puesto, string correo)
        {
            Nombre = nombre;
            Puesto = puesto;
            Correo = correo;
        }
    }
    public class EmpleadoList
    {
        public Empleado[] getEmpleados(int cantidadEmpleados)
        {
            
            Empleado[] empleados = new Empleado[cantidadEmpleados];
            string[] puestos = { "jefe", "gerente", "supervisor", "Director" };
            Random random = new Random();
            for (int i = 0; i < cantidadEmpleados; i++)
            {
                var nombreEmpleado = Guid.NewGuid().ToString().Substring(0, 10);

                var nuevoEmpleado = new Empleado(nombreEmpleado, puestos[random.Next(0, 3)],
                    nombreEmpleado + "@microsoft.com");
                empleados[i] = nuevoEmpleado;

            }
            return empleados;
        }
    }
}