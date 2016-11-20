using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using SQLite;
using System.IO;

namespace Modulo2.Leccion4.Android.DBSQLite
{
    [Activity(Label = "Modulo2.Leccion4.Android.DBSQLite", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double ingPE, egrPE, ingMX, egrMX, CapitalPE, CapitalMX;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            ruta = Path.Combine(ruta, "base.db3");

            var coneccion = new SQLiteConnection(ruta);

            coneccion.CreateTable<Informacion>();
            //

            Button btnCalcular = FindViewById<Button>
                (Resource.Id.btnCalcular);
            EditText txtIngresosPeru = FindViewById<EditText>
                (Resource.Id.txtIngresosPeru);
            EditText txtEgresosPeru = FindViewById<EditText>
                (Resource.Id.txtEgresosPeru);
            EditText txtIngresosMexico = FindViewById<EditText>
                (Resource.Id.txtIngresosMexico);
            EditText txtEgresosMexico = FindViewById<EditText>
                (Resource.Id.txtEgresosMexico);

            btnCalcular.Click += delegate
            {
                try
                {
                    ingPE = double.Parse(txtIngresosPeru.Text);
                    ingMX = double.Parse(txtIngresosMexico.Text);
                    egrPE = double.Parse(txtEgresosPeru.Text);
                    egrMX = double.Parse(txtEgresosMexico.Text);
                    CapitalPE = ingPE - egrPE;
                    CapitalMX = ingMX - egrMX;
                    //
                    var Insertar = new Informacion();
                    Insertar.IngresosPE = ingPE;
                    Insertar.IngresosMX = ingMX;
                    Insertar.EgresosPE = egrPE;
                    Insertar.EgresosMX = egrMX;
                    coneccion.Insert(Insertar);
                    Toast.MakeText(this, "Guardado en SQLite", ToastLength.Short).Show();
                    //
                    Cargar();
                }
                catch (System.Exception ex)
                {

                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }


            };
        }

        public void Cargar()
        {
            Intent objIntent = new Intent(this, typeof(VistaCapital));

            objIntent.PutExtra("CapitalPE", CapitalPE);
            objIntent.PutExtra("CapitalMX", CapitalMX);
            StartActivity(objIntent);
        }
    }
    public class Informacion
    {
        public double IngresosPE { get; set; }

        public double EgresosPE { get; set; }

        public double IngresosMX { get; set; }
        public double EgresosMX { get; set; }
    }

}

