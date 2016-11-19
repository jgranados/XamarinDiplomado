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
    public class EmpleadoAdapter : BaseAdapter<Empleado>
    {
        Empleado[] data;
        public EmpleadoAdapter(Empleado[] data)
        {
            this.data = data;
        }
        public override Empleado this[int position]
        {
            get
            {
                return data[position];
            }
        }

        public override int Count
        {
            get
            {
                return data.Count();
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.EmpleadoItem, parent, false);
            var tvNombre = view.FindViewById<TextView>(Resource.Id.tvNombre);
            var tvcorreo = view.FindViewById<TextView>(Resource.Id.tvCorreo);

            tvNombre.Text = "Nombre Empleado: " + data[position].Nombre;
            tvcorreo.Text = "Correo Empleado: " + data[position].Correo;

            return view;

        }
    }
}