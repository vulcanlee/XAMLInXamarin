using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MDPageCust
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGotoPage1_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page1());
            IsPresented = false;
        }

        private void btnGotoPage2_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page2());
            IsPresented = false;
        }

        private void btnGotoPage3_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page3());
            IsPresented = false;
        }
    }
}
