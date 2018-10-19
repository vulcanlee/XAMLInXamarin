using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewDemo
{
    public class DataItem : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        private double _Price ;

        public double Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public partial class MainPage : ContentPage
    {
        public List<DataItem> MyListSource { get; set; }
        public MainPage()
        {
            InitializeComponent();

            Init();
            listview1.ItemsSource = MyListSource;
            listview2.ItemsSource = MyListSource;
        }

        private void Init()
        {
            MyListSource = new List<DataItem>()
            {
                new DataItem()
                {
                    Id = 1,
                    Title="LG Gram 15.6吋八代Core i7窄邊極緻輕薄筆電",
                    Description = "處理器：Intel Core i7-8550U"+Environment.NewLine+
                    "作業系統：Windows 10 Pro"+Environment.NewLine+
                    "顯示晶片：Intel UHD Graphic 620"+Environment.NewLine,
                    Color = Color.LightBlue,
                    Price = 29000
                },
                new DataItem()
                {
                    Id = 2,
                    Title="ASUS VivoBook Pro 15 N580GD 冰柱金",
                    Description = "處理器：Intel® Core™ i7-8750H 2.2 GHz"+Environment.NewLine+
                    "作業系統：64 Bits Windows 10 Home"+Environment.NewLine+
                    "顯卡：NVIDIA GTX 1050 4G獨顯 ",
                    Color = Color.LightGreen,
                    Price = 41900
                },
                new DataItem()
                {
                    Id = 3,
                    Title="HP ENVY 13-ah0013TU 璀燦金輕薄筆電",
                    Description = "處理器：8th Gen Intel Core i5-8250U Quad Core"+Environment.NewLine+
                    "作業系統：Windows 10 Pro"+Environment.NewLine+
                    "顯示晶片：13.3\" FHD UWVA LED (1920x1080) 超廣角螢幕",
                    Color = Color.LightBlue,
                    Price = 33900
                },
                new DataItem()
                {
                    Id = 4,
                    Title="Lenovo ThinkPad X280 20KFA011TW",
                    Description = "處理器：Intel Core i5-8250U (1.6GHz to 3.4GHz) "+Environment.NewLine+
                    "作業系統：Windows 10"+Environment.NewLine+
                    "顯示晶片：12.5 HD ",
                    Color = Color.LightGreen,
                    Price = 35990
                },
                new DataItem()
                {
                    Id = 5,
                    Title="MSI微星GP62 8RD-078TW電競筆電",
                    Description = "處理器：Intel 第8代 Core i7-8750H 六核心處理器"+Environment.NewLine+
                    "作業系統：Windows 10 Pro"+Environment.NewLine+
                    "顯示晶片規格：GeForce GTX1050Ti GDDR5 4GB獨顯",
                    Color = Color.LightBlue,
                    Price = 29000
                },
            };
        }

        private void listview1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var fooItem = e.Item as DataItem;
            DisplayAlert("通知", $"您選取了 {fooItem.Title}", "確定");
        }

        private void listview2_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var fooItem = e.Item as DataItem;
            DisplayAlert("通知", $"您確定要購買 {fooItem.Title} ?", "確定");
        }

        private void listview2_Refreshing(object sender, EventArgs e)
        {
            listview2.IsRefreshing = true;
            foreach (var item in MyListSource)
            {
                item.Price += 100;
            }
            listview2.IsRefreshing = false;
        }
    }
}
