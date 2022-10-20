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
    [Activity(Label = "Login")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_window);

            //к тестам
            Button button1LoginWindow = FindViewById<Button>(Resource.Id.button1LoginWindow);
            button1LoginWindow.Click += button1LoginWindowOnClick;

            //напомнить пароль
            Button button2LoginWindow = FindViewById<Button>(Resource.Id.button2LoginWindow);
            button2LoginWindow.Click += button2LoginWindowOnClick;

            //назад
            ImageButton imageButton1LoginWindow = FindViewById<ImageButton>(Resource.Id.imageButton1LoginWindow);
            imageButton1LoginWindow.Click += imageButton1LoginWindowOnClick;
        }

        //вход
        private void button1LoginWindowOnClick(object sender, EventArgs eventArgs)
        {
            this.StartActivity(typeof(MainWindowActivity));
            this.Finish();
        }

        //напомнить пароль
        private void button2LoginWindowOnClick(object sender, EventArgs eventArgs)
        {
            this.StartActivity(typeof(RemindePasswordActivity));
            this.Finish();
        }

        //назад
        private void imageButton1LoginWindowOnClick(object sender, EventArgs eventArgs)
        {
            this.StartActivity(typeof(MainActivity));
            this.Finish();
        }
    }
}