using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;

namespace XFElement
{
    public class DataItem
    {
        public string Name { get; set; }
        public string StackLayoutClassId { get; set; }
        public string ButtonClassId { get; set; }
        public string LabelClassId { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<DataItem> Items { get; set; } = new ObservableCollection<DataItem>();
        Label dyanmicLabel;
        public MainPage()
        {
            InitializeComponent();

            stacklayout.ChildAdded += (s, e) =>
            {
                Console.WriteLine($"有一筆紀錄新增進來了");
            };
            stacklayout.ChildRemoved += (s, e) =>
            {
                Console.WriteLine($"有一筆紀錄移除進來了");
            };

            for (int i = 0; i < 10; i++)
            {
                Items.Add(new DataItem()
                {
                    Name = $"Name{i}",
                    StackLayoutClassId = $"ClassID{i}",
                    ButtonClassId = $"ClassID{i}",
                    LabelClassId = $"LabelClassID{i}"
                });
            }

            lv.ItemsSource = Items;
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            Element element = lv as Element;
            Console.WriteLine($"ListView.ClassId={element.ClassId}");
            Console.WriteLine($"ListView.Id={element.Id}");
            Console.WriteLine($"ListView.StyleId={element.StyleId}");
            Console.WriteLine($"ListView.Parent={element.Parent}");
            Console.WriteLine($"   StackLayout.ClassId={element.Parent.ClassId}");
            Console.WriteLine($"   StackLayout.Id={element.Parent.Id}");
            Console.WriteLine($"   StackLayout.StyleId={element.Parent.StyleId}");
        }

        private void buttonChildAdd_Clicked(object sender, EventArgs e)
        {
            dyanmicLabel = new Label()
            {
                Text = "動態產生的文字標籤"
            };
            stacklayout.Children.Insert(0, dyanmicLabel);
        }

        private void buttonChildRemove_Clicked(object sender, EventArgs e)
        {
            stacklayout.Children.Remove(dyanmicLabel);
        }

        private void buttonFindByName_Clicked(object sender, EventArgs e)
        {
            Label label = this.FindByName<Label>("label2");
            Console.WriteLine($"變更前的文字標籤的文字內容 : {label.Text}");
            label.Text = "透過 FindByName 取得控制項來變更文字";
            Console.WriteLine($"變更後的文字標籤的文字內容 : {label.Text}");

            ViewCell viewcell = this.FindByName<ViewCell>("viewCell");
            var fooViewCellObject = viewcell == null ? "空值" : viewcell.ToString();
            Console.WriteLine($"ViewCell 的物件 {fooViewCellObject}");
        }

        private void btnChangeText_Clicked(object sender, EventArgs e)
        {
            if( (int.Parse((sender as Button).ClassId.Replace("ClassID", "")) % 2)==0)
            {
                #region 方法一：使用 Parent 屬性找出 StackLayout 物件，接著使用 FindByName 來搜尋
                StackLayout stacklayout = ((sender as Button).Parent as StackLayout);
                Label label = stacklayout.FindByName<Label>("labelChange");
                Console.WriteLine($"變更前的文字標籤的文字內容 : {label.Text}");
                label.Text = "使用者已經按下按鈕";
                Console.WriteLine($"變更後的文字標籤的文字內容 : {label.Text}");
                #endregion
            }
            else
            {
                #region 使用 Reflection API，找出 ListView 的所有集合項目物件，接著透過 ClassId 來比對
                string fooIndex = (sender as Button).ClassId.Replace("ClassID", "LabelClassID");
                IEnumerable<PropertyInfo> pInfos = (lv as ItemsView<Cell>).GetType().GetRuntimeProperties();
                var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");
                if (templatedItems != null)
                {
                    var cells = templatedItems.GetValue(lv);
                    foreach (ViewCell cell in cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>)
                    {
                        StackLayout stacklayoutByClassId = cell.View as StackLayout;
                        Label fooLabel = stacklayoutByClassId.Children.FirstOrDefault<Element>(x => x.ClassId == fooIndex) as Label;
                        if (fooLabel == null) continue;
                        Console.WriteLine($"@@變更前的文字標籤的文字內容 : {fooLabel.Text}");
                        fooLabel.Text = "@@使用者已經按下按鈕";
                        Console.WriteLine($"@@變更後的文字標籤的文字內容 : {fooLabel.Text}");
                    }
                }
                #endregion
            }


        }
    }
}
