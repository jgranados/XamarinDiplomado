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

namespace Modulo2.Leccion2.Android.Activities
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