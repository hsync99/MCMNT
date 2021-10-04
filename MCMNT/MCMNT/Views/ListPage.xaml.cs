using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCMNT.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace MCMNT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ViewModel vm;
        public ListPage()
        {
            
            InitializeComponent();
            vm = (ViewModel)BindingContext;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.OnAppearing();
        }

        public void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
            try
            {

               //vm.Search(e.NewTextValue);
                string srh = e.NewTextValue;
                vm.Search(e.NewTextValue);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }

      
    }
}