using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MCMNT.ViewModels;
namespace MCMNT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : Popup
    {
        public ViewModel vm;
        public Page1()
        {
            InitializeComponent();
            vm = (ViewModel)BindingContext;
        }
       

        

        private void Popup_SizeChanged(object sender, EventArgs e)
        {
            OnSizeAllocated(300,300);
        }
    }
}