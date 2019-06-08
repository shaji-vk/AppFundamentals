using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart() - Method");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep() - Method");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume() - Method");
        }
    }
}
