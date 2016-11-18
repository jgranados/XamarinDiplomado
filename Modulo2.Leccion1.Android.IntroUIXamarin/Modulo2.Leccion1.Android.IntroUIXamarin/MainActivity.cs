using Android.App;
using Android.Widget;
using Android.OS;

namespace Modulo2.Leccion1.Android.IntroUIXamarin
{
    [Activity(Label = "Convertidor Xamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            Button btnConvertir = FindViewById<Button>
                (Resource.Id.tbnConvertir);
            EditText txtDolares = FindViewById<EditText>
                (Resource.Id.txtDolares);
            EditText txtSoles = FindViewById<EditText>
                (Resource.Id.txtSoles);

            double soles, dolares;
            double tipoCambio = 3.5;

            btnConvertir.Click += delegate
             {
                 try
                 {
                     dolares = double.Parse(txtDolares.Text);
                     soles = dolares * tipoCambio;
                     txtSoles.Text = soles.ToString();
                 }
                 catch (System.Exception ex)
                 {
                     Toast.MakeText(this, ex.Message,ToastLength.Short).Show();
                 }
             };
        }
    }
}

