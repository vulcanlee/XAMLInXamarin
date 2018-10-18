using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EntryDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}

        private void btnMoreText_Clicked(object sender, EventArgs e)
        {
            editor.Text += "Xamarin.Forms 會公開適用於 .NET 開發人員"+
                "的完整跨平台 UI 工具組。 在 Visual Studio 中使用 C#"+"" +
                " 建置完整的原生 Android、iOS 與通用 Windows 平台應用程式。";
        }

        private void btnGoMain_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        private void btnLessText_Clicked(object sender, EventArgs e)
        {
            editor.Text = "自動調整大小的文字編輯器";
        }
    }
}