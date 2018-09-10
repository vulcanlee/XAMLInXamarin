using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XAMLElementTree
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnOK_Clicked(object sender, EventArgs e)
        {
            var app = this.Parent;
            string appParentStatus = "???";
            if (app.Parent == null) appParentStatus = "不存在";
            var appClassName = app.GetType().Name;
            Debug.WriteLine($"物件 {appClassName} (父類別 {appParentStatus})");

            RetriveAllChildren(this, 1);
        }

        void RetriveAllChildren(VisualElement retriveElement, int level)
        {
            var elementAllRuntimeProperties = retriveElement.GetType().GetRuntimeProperties();
            var elementContentProperty = elementAllRuntimeProperties.FirstOrDefault(w => w.Name == "Content");
            var elementChildrenProperty = elementAllRuntimeProperties.FirstOrDefault(w => w.Name == "Children");

            LogElement(retriveElement, level++);

            if (elementChildrenProperty == null)
            {
                if (elementContentProperty != null)
                {
                    // 取得這個 內容屬性 (Content Property) 指向的 項目 Element
                    var contentElementObject = elementContentProperty.GetValue(retriveElement) as VisualElement;
                    // 若這個 內容屬性 有指向其他 XAML 項目，則繼續往下找下去
                    if (contentElementObject != null)
                        RetriveAllChildren(contentElementObject, level);
                }
                return;
            }

            // 此時的 內容屬性 指向的是一群 集合的項目
            IEnumerable enumerableElement = elementChildrenProperty.GetValue(retriveElement) as IEnumerable;
            foreach (var currentElement in enumerableElement)
            {
                if (currentElement is VisualElement)
                    RetriveAllChildren(currentElement as VisualElement, level);
            }
        }

        void LogElement(VisualElement retriveElement, int level)
        {
            string beginSpace = new string(' ', level * 4);
            // 取得父項目的類別資訊
            string parentElement = "不存在";
            if (retriveElement.Parent != null)
                parentElement = retriveElement.Parent.GetType().Name;

            // 取得現在項目的類別資訊
            var elementName = retriveElement.GetType().Name;
            Debug.WriteLine($"{beginSpace}項目 {elementName} (父類別 {parentElement})");
        }
    }
}
