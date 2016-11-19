using Android.App;
using controlesUI = Android.Widget;
using recursosUI = Android.Resource;
using Android.OS;

namespace Modulo2.Leccion4.Android.ListView
{
    [Activity(Label = "Modulo2.Leccion4.Android.ListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            EmpleadoList listaEmpleados = new EmpleadoList();
            var empleados = listaEmpleados.getEmpleados(20);

            controlesUI.ListView lvEmpleados = FindViewById<controlesUI.ListView>(Resource.Id.lvEmpleados);

            //usando adaptador del sistema
            //controlesUI.ArrayAdapter<Empleado> adaptador = new controlesUI.ArrayAdapter<Empleado>(this, recursosUI.Layout.SimpleListItem1, empleados);
            //lvEmpleados.Adapter = adaptador;

            // usando adaptador personalizado
            EmpleadoAdapter adaptador = new EmpleadoAdapter(empleados);
            lvEmpleados.Adapter = adaptador;

        }
    }
}

