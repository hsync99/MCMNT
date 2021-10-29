using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCMNT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NumPadView : ContentPage
    {
        public NumPadView()
        {
            InitializeComponent();
            
            
        }
          

        

        private void x1_Clicked(object sender, EventArgs e)
        {
            xEntry.Text += "1";
        }

        private void x2_Clicked(object sender, EventArgs e)
        {
            xEntry.Text += "2";
        }

        private void x3_Clicked(object sender, EventArgs e)
        {
             xEntry.Text += "3";
        }

        private void x4_Clicked(object sender, EventArgs e)
        {
            xEntry.Text += "4";
        }

        private void x5_Clicked(object sender, EventArgs e)
        {
            xEntry.Text += "5";
        }

        private void x6_Clicked(object sender, EventArgs e)
        {
            xEntry.Text += "6";
        }

        private void x7_Clicked(object sender, EventArgs e)
        {
            xEntry.Text += "7";
        }

        private void x8_Clicked(object sender, EventArgs e)
        {
            xEntry.Text += "8";
        }

        private void x9_Clicked(object sender, EventArgs e)
        {
            xEntry.Text += "9";
        }

        private void xBack_Clicked(object sender, EventArgs e)
        {
            xEntry.Text = xEntry.Text.Substring(0, xEntry.Text.Length - 1);
            if (xEntry.Text.Length == 0)
            {
                xEntry.Text = "0";
            }
        }

        private void x0_Clicked(object sender, EventArgs e)
        {
            xEntry.Text += "0";
        }

        private void xClear_Clicked(object sender, EventArgs e)
        {
            xEntry.Text = "0";
        }
    }
}