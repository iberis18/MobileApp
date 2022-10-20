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
    public class MainWindowActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_window);

            //к тестам
            Button button1MainWindow = FindViewById<Button>(Resource.Id.button1MainWindow);
            button1MainWindow.Click += button1MainWindowOnClick;

            //результаты
            Button button2MainWindow = FindViewById<Button>(Resource.Id.button2MainWindow);
            button2MainWindow.Click += button2MainWindowOnClick;

            //упражнения
            Button button3MainWindow = FindViewById<Button>(Resource.Id.button3MainWindow);
            button3MainWindow.Click += button3MainWindowOnClick;

            //помощь
            Button button4MainWindow = FindViewById<Button>(Resource.Id.button4MainWindow);
            button4MainWindow.Click += button4MainWindowOnClick;

            //выйти
            Button button5MainWindow = FindViewById<Button>(Resource.Id.button5MainWindow);
            button5MainWindow.Click += button5MainWindowOnClick;

            // Create your application here
        }

        //к тестам
        private void button1MainWindowOnClick(object sender, EventArgs eventArgs)
        {
            this.StartActivity(typeof(TestsListActivity));
            this.Finish();
        }

        //результаты
        private void button2MainWindowOnClick(object sender, EventArgs eventArgs)
        {
            //this.StartActivity(typeof(LoginActivity));
            //this.Finish();

        }

        //упражнения
        private void button3MainWindowOnClick(object sender, EventArgs eventArgs)
        {
            //this.StartActivity(typeof(MainActivity));
            //this.Finish();
        }
        //помощь
        private void button4MainWindowOnClick(object sender, EventArgs eventArgs)
        {
            //this.StartActivity(typeof(LoginActivity));
            //this.Finish();
        }

        //выйти
        private void button5MainWindowOnClick(object sender, EventArgs eventArgs)
        {
            this.StartActivity(typeof(MainActivity));
            this.Finish();
        }
    }
}