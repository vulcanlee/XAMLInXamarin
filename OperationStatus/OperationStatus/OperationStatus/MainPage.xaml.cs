using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OperationStatus
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void buttonIsVisable_Clicked(object sender, EventArgs e)
        {
            boxview1.IsVisible = !boxview1.IsVisible;
        }
    }
}
