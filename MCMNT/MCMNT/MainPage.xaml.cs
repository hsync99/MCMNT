using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MCMNT.ViewModels;

namespace MCMNT
{
    public partial class MainPage : ContentPage
    {


        public ViewModel vm;
        private Size pagesize;
        public Size PageSize { get => pagesize; set => vm.SetProperty(ref pagesize, value); }
        public MainPage()
        {
            InitializeComponent();
            vm = (ViewModel)BindingContext;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.OnAppearing();
        }
        protected override void OnSizeAllocated(double width, double height)
        {



            base.OnSizeAllocated(width, height);
            
            
            vm.PageSize = new Size(width, height);


            //SizeRequest sizeRequest = OrderFrontePlate.Measure(width, height);

            //conteinerHeigh = sizeRequest.Request.Height;



        }
       
    }


}
