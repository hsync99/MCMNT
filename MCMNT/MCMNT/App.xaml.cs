using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCMNT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTIzNTI0QDMxMzkyZTMzMmUzMFFUWGhxN3VpbFpEcTJJU09NcENZaFV0bGtzWWZJYzQxQVpiOUkraENKTjg9");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
