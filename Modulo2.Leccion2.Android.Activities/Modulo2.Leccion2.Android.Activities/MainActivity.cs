using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Modulo2.Leccion2.Android.Activities
{
    [Activity(Label = "Xamarin Activities Paso Variables", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double ingPE, egrPE, ingMX, egrMX, CapitalPE, CapitalMX;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
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
}

