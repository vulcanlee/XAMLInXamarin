using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BindableObjectSample
{
    class CustomLabel : Label
    {
        #region CustomText 可綁定屬性 BindableProperty
        public static readonly BindableProperty CustomTextProperty =
            BindableProperty.Create("CustomText", // 屬性名稱 
                typeof(string), // 回傳類型 
                typeof(CustomLabel), // 宣告類型 
                "", // 預設值 
                //defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: OnCustomTextChanged  // 屬性值異動時，要執行的事件委派方法
            );

        public string CustomText
        {
            set
            {
                SetValue(CustomTextProperty, value);
            }
            get
            {
                return (string)GetValue(CustomTextProperty);
            }
        }

        private static void OnCustomTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        #endregion

    }
}
