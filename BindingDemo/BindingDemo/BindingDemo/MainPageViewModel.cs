using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace BindingDemo
{
    public class MyItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public MySubItem MySubItemData { get; set; }
    }

    public class MySubItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _Title = "";

        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private MyItem _MyItemObject;

        public MyItem MyItemObject
        {
            get { return _MyItemObject; }
            set
            {
                _MyItemObject = value;
                OnPropertyChanged(nameof(MyItemObject));
            }
        }


        private ObservableCollection<MyItem> myItemList;
        /// <summary>
        /// MyItemList
        /// </summary>
        public ObservableCollection<MyItem> MyItemList
        {
            get { return myItemList; }
            set
            {
                myItemList = value;
                OnPropertyChanged(nameof(MyItemList));
            }
        }

        public Dictionary<string, int> Dict { get; set; }

        public MainPageViewModel(string action)
        {
            MyItemObject = new MyItem
            {
                FirstName = "Main Vulcan",
                MySubItemData = new MySubItem
                {
                    FirstName = "Sub Lee",
                }
            };
        }

        public MainPageViewModel()
        {
            Title = "各種資料綁定語法 使用範例";

            MyItemObject = new MyItem
            {
                FirstName = "Main FirstName",
                MySubItemData = new MySubItem
                {
                    FirstName = "Sub Firstname",
                }
            };

            MyItemList = new ObservableCollection<MyItem>();
            MyItemList.Add(new MyItem() { FirstName = "FN1", LastName = "LN1" });
            MyItemList.Add(new MyItem() { FirstName = "FN2", LastName = "LN2" });
            MyItemList.Add(new MyItem() { FirstName = "FN3", LastName = "LN3" });

            Dict = new Dictionary<string, int>();
            Dict.Add("item1", 100);
            Dict.Add("item2", 120);
            Dict.Add("item3", 140);
            Dict.Add("item4", 160);

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
