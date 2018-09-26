using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavigateOP
{
    public class NavigationBarModel : INotifyPropertyChanged
    {
        private bool _PhysicalBackButtonEnable = true;

        public bool PhysicalBackButtonEnable
        {
            get { return _PhysicalBackButtonEnable; }
            set
            {
                _PhysicalBackButtonEnable = value;
                OnPropertyChanged("PhysicalBackButtonEnable");
            }
        }

        private bool _BackButtonVisible = true;

        public bool BackButtonVisible
        {
            get { return _BackButtonVisible; }
            set
            {
                _BackButtonVisible = value;
                OnPropertyChanged("BackButtonVisible");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        NavigationBarModel _NavigationBarModel;
        public Page1 ()
		{
			InitializeComponent ();

            _NavigationBarModel = new NavigationBarModel()
            {
                BackButtonVisible = true
            };
            BindingContext = _NavigationBarModel;
		}

        private void btnGoPage2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }

        private void btnGoback_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void btnHiddenBack_Clicked(object sender, EventArgs e)
        {
            _NavigationBarModel.BackButtonVisible = !_NavigationBarModel.BackButtonVisible;
        }

        private void btnHiddenPhysicalBack_Clicked(object sender, EventArgs e)
        {
            _NavigationBarModel.PhysicalBackButtonEnable = !_NavigationBarModel.PhysicalBackButtonEnable;
        }

        protected override bool OnBackButtonPressed()
        {
            if (_NavigationBarModel.PhysicalBackButtonEnable == false)
            {
                return true;
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }
    }
}