using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DatePickerDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            labelDate.Text = datepicker.Date.ToShortDateString();
        }
    }
}
