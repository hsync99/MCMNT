using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCMNT.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCMNT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        readonly ViewModel vm;
        public ListPage()
        {
            vm = (ViewModel)BindingContext;
            InitializeComponent();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
      {
            try
            {
                vm.Search(e.ToString());
            }
            catch(Exception ex)
            {
                var exception = ex.ToString();
            }
            
        }
    }
}