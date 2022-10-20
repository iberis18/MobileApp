using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    [Activity(Label = "TestsListActivity")]
    public class TestsListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.testsList_window);   

            //назад
            ImageButton imageButton1 = FindViewById<ImageButton>(Resource.Id.imageButton1);
            imageButton1.Click += imageButton1OnClick;
            // Create your application here
        }
        //назад
        private void imageButton1OnClick(object sender, EventArgs eventArgs)
        {
            this.StartActivity(typeof(MainWindowActivity));
            this.Finish();
        }
    }
}