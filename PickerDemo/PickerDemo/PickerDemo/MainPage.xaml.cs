using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PickerDemo
{
    public class DataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DataItem> MenuItems { get; set; }

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
        public List<DataItem> Picker1Source { get; set; }
        public List<DataItem> Picker2Source { get; set; }
        public MainPage()
        {
            InitializeComponent();

            InitPicker1();
            picker1.ItemsSource = Picker1Source;
        }

        private void InitPicker1()
        {
            Picker1Source = new List<DataItem>();
            for (int i = 0; i < 20; i++)
            {
                Picker1Source.Add(new DataItem()
                {
                    Id = 0,
                    Name = $"大分類名稱 {i}"
                });
            }
        }

        private void picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker1.SelectedItem != null)
            {
                var fooItem = picker1.SelectedItem as DataItem;
                labelMainCat.Text = fooItem.Name;
                labelSubCat.Text = "";
                Picker2Source = new List<DataItem>();
                for (int i = 0; i < 30; i++)
                {
                    Picker2Source.Add(new DataItem()
                    {
                        Id = i,
                        Name = $"{fooItem.Name} - {i}"
                    });
                }
                picker2.ItemsSource = Picker2Source;
                labelSubCat.Text = "";
            }
        }

        private void picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker2.SelectedItem != null)
            {
                var fooItem = picker2.SelectedItem as DataItem;
                labelSubCat.Text = fooItem.Name;
            }
        }

        private void searchbar_SearchButtonPressed(object sender, EventArgs e)
        {
            DisplayAlert("資訊", $"您要搜尋文字 {searchbar.Text}", "確定");
        }
    }
}
