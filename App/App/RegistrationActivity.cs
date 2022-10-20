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
    [Activity(Label = "RegistrationActivity")]
    public class RegistrationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.registration_window);

            //регистрация
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += button1OnClick;

            //назад
            ImageButton imageButton1 = FindViewById<ImageButton>(Resource.Id.imageButton1);
            imageButton1.Click += imageButton1OnClick;

        }

        //регистрация
        private void button1OnClick(object sender, EventArgs eventArgs)
        {
            this.StartActivity(typeof(MainActivity));
            this.Finish();
        }

        //назад
        private void imageButton1OnClick(object sender, EventArgs eventArgs)
        {
            this.StartActivity(typeof(MainActivity));
            this.Finish();
        }
    }
}