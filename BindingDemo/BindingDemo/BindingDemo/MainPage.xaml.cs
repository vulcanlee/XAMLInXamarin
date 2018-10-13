using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BindingDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnChangeBindingContext_Clicked(object sender, EventArgs e)
        {
            BindingContext = new MainPageViewModel()
            {
                Title = "Code-Behind 使用範例",

                MyItemObject = new MyItem
                {
                    FirstName = "Main Code-Behind",
                    MySubItemData = new MySubItem
                    {
                        FirstName = "Sub Code-Behind",
                    }
                },

                MyItemList = new ObservableCollection<MyItem>()
                {
                    new MyItem() { FirstName = "A_FN1", LastName = "A_LN1" },
                    new MyItem() { FirstName = "A_FN2", LastName = "A_LN2" },
                    new MyItem() { FirstName = "A_FN3", LastName = "A_LN3" }
                },

                Dict = new Dictionary<string, int>()
                {
                    {"A_item1", 9100 },
                    {"A_item2", 9120 },
                    {"item3", 9140 },
                    {"A_item4", 9160 },
                },
        };
    }
}
}
