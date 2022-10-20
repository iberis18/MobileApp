using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Content;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;

namespace App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.content_main);


            /*ViewStub stub = FindViewById<ViewStub>(Resource.Id.layout_stub);
            stub.LayoutResource = Resource.Layout.content_main;
            stub.Inflate();*/

            Button button1ContentMain = FindViewById<Button>(Resource.Id.button1ContentMain);
            button1ContentMain.Click += button1ContentMainOnClick;


            //Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);

            //FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //fab.Click += FabOnClick;

        }
        private void button1ContentMainOnClick(object sender, EventArgs eventArgs)
        {
            this.StartActivity(typeof(LoginActivity));
            this.Finish();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
