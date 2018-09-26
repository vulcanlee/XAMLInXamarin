using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavigateOP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
	{
		public Page2 ()
		{
			InitializeComponent ();
		}

        private void btnGoback_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void btnGoHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}