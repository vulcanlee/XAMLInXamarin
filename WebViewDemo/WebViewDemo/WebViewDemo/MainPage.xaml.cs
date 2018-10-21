using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WebViewDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var htmlWebViewSource = new HtmlWebViewSource();
            htmlWebViewSource.Html = @"<html><body><h1>Xamarin.Forms</h1> <p>Welcome to WebView.</p>  </body></html>";
            webview.Source = htmlWebViewSource;
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            labelNavigating.Text = $"Navigating time {DateTime.Now}";
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            labelNavigated.Text = $"Navigated time {DateTime.Now}";
        }

        private void btnNavi_Clicked(object sender, EventArgs e)
        {
            webviewOnline.Source = (new Uri( entryUrl.Text));
        }

        private void btnNaviF_Clicked(object sender, EventArgs e)
        {
            if(webviewOnline.CanGoForward)
            {
                webviewOnline.GoForward();
            }
        }

        private void btnNaviB_Clicked(object sender, EventArgs e)
        {
            if (webviewOnline.CanGoBack)
            {
                webviewOnline.GoBack();
            }
        }
    }
}
