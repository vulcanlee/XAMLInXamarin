using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;

namespace ColorName
{
    public class ColorItem
    {
        public Color Color { get; set; }
        public Color BackgroundColor { get; set; }
        public string Name { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ColorItem> AllColors { get; set; } = new ObservableCollection<ColorItem>();
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = this;

            Type colorType = typeof(Color);
            IEnumerable<FieldInfo> allFileds = colorType.GetRuntimeFields();
            foreach (var item in allFileds)
            {
                if (item.GetCustomAttribute<ObsoleteAttribute>() != null) continue;
                if (item.IsPublic && item.IsStatic && item.FieldType == typeof(Color))
                {
                    AllColors.Add(
                        new ColorItem
                        {
                            Color = (Color)item.GetValue(null),
                            BackgroundColor = GenerateBackgroundColor((Color)item.GetValue(null)),
                            Name = item.Name
                        });
                }
            }
            IEnumerable<PropertyInfo> allProperties = colorType.GetRuntimeProperties();
            foreach (var item in allProperties)
            {
                MethodInfo methodInfo = item.GetMethod;
                if (methodInfo.IsPublic && methodInfo.IsStatic && methodInfo.ReturnType == typeof(Color))
                {
                    AllColors.Add(
                        new ColorItem
                        {
                            Color = (Color)item.GetValue(null),
                            BackgroundColor = GenerateBackgroundColor((Color)item.GetValue(null)),
                            Name = item.Name
                        });
                }
            }
        }

        public Color GenerateBackgroundColor(Color color)
        {
            Color backgroundColor = Color.Default;

            if (color != Color.Default)
            {
                double luminance =
                    0.30 * color.R +
                    0.59 * color.G +
                    0.11 * color.B;
                backgroundColor = luminance > 0.5 ? Color.Black : Color.White;
            }

            return backgroundColor;
        }
    }
}
