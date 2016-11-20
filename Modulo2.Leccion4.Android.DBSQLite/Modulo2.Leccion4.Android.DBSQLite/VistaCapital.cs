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
using SQLite;
using System.IO;

namespace Modulo2.Leccion4.Android.DBSQLite
{
    [Activity(Label = "VistaCapital")]
    public class VistaCapital : Activity
    {
        double defaultValue;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VistaCapital);

            Button btnSalir = FindViewById<Button>
                            (Resource.Id.btnSalir);
            EditText txtCapitalPeru = FindViewById<EditText>
                (Resource.Id.txtCapitalPeru);
            EditText txtCapitalMexico = FindViewById<EditText>
                (Resource.Id.txtCapitalMexico);
            ImageView imgPeru = FindViewById<ImageView>
                (Resource.Id.imgPeru);
            ImageView imgMexico = FindViewById<ImageView>
                (Resource.Id.imgMexico);

            try
            {
                txtCapitalPeru.Text = Intent.GetDoubleExtra("CapitalPE", defaultValue).ToString();
                txtCapitalMexico.Text = Intent.GetDoubleExtra("CapitalMX", defaultValue).ToString();
                imgMexico.SetImageResource(Resource.Drawable.mexico);
                imgPeru.SetImageResource(Resource.Drawable.peru3d);

                //
                var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                ruta = Path.Combine(ruta, "base.db3");

                var coneccion = new SQLiteConnection(ruta);

                var elementos = from s in coneccion.Table<Informacion>()
                                select s;

                foreach (var fila in elementos)
                {
                    Toast.MakeText(this, fila.IngresosPE.ToString(), ToastLength.Short).Show();
                    Toast.MakeText(this, fila.IngresosMX.ToString(), ToastLength.Short).Show();
                    Toast.MakeText(this, fila.EgresosPE.ToString(), ToastLength.Short).Show();
                    Toast.MakeText(this, fila.EgresosMX.ToString(), ToastLength.Short).Show();

                }


            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }

            btnSalir.Click += delegate
            {
                try
                {
                    Process.KillProcess(Process.MyPid());
                }
                catch (System.Exception ex)
                {

                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }


            };
        }
    }
}
