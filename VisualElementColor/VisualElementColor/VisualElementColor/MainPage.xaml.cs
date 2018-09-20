using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VisualElementColor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            labelDefault.Text = $"預設背景顏色，檢測 Background 屬性值是否可以繼承 {this.BackgroundColor.ToString()}";
        }
    }
}
