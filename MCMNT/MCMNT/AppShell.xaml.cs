using MCMNT.ViewModels;
using MCMNT.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MCMNT
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
       
        public AppShell()
        {
            InitializeComponent();
            //  Routing.RegisterRoute($"//{nameof(MainPage)}/{nameof(CreateView)}", typeof(CreateView));
            //Routing.RegisterRoute($"//{nameof(MainPage)}/{nameof(CreateView)}", typeof(CreateView));
            // Routing.RegisterRoute($"{nameof(MainPage)}", typeof(MainPage));
            Routing.RegisterRoute("CreateView", typeof(CreateView));
        }

    }
}
