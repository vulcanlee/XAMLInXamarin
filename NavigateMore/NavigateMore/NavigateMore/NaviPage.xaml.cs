using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavigateMore
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NaviPage : NavigationPage
    {
		public NaviPage ()
		{
			InitializeComponent ();
		}
        public NaviPage(Page page) : base(page)
        {
            InitializeComponent();
        }
    }
}