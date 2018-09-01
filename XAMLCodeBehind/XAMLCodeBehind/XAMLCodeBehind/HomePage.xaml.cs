using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAMLCodeBehind
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        int index = 0;
        public HomePage ()
		{
			InitializeComponent ();
		}

        private void button_Clicked(object sender, EventArgs e)
        {
            label.Text = $"點選按鈕次數 {++index}";
        }
    }
}