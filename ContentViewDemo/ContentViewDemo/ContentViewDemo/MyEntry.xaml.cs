using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContentViewDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyEntry : ContentView
	{
        MyEntryViewModel _MyEntryViewModel;
        public MyEntry ()
		{
			InitializeComponent ();

            this.BindingContextChanged += (s, e) =>
            {
                _MyEntryViewModel = BindingContext as MyEntryViewModel;
            };
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_MyEntryViewModel != null)
            {
                if (string.IsNullOrEmpty(_MyEntryViewModel.Input))
                {
                    _MyEntryViewModel.ShowTitle = false;
                }
                else
                {
                    _MyEntryViewModel.ShowTitle = true;
                }
            }
        }
    }
}