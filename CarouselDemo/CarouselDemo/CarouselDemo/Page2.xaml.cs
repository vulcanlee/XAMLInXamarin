using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarouselDemo
{
    public class MyItem 
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public string ImageUrl { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : CarouselPage
    {
        List<MyItem> myItemsSource;

        public Page2 ()
		{
			InitializeComponent ();

            myItemsSource = new List<MyItem>();
            Init();
            this.ItemsSource = myItemsSource;
        }

        public void Init()
        {
            myItemsSource.Add(new MyItem()
            {
                Name = "LightBlue",
                Color = Color.LightBlue,
                ImageUrl = "https://avatars2.githubusercontent.com/u/790012?s=200&v=4",
            });
            myItemsSource.Add(new MyItem()
            {
                Name = "LightCoral",
                Color = Color.LightCoral,
                ImageUrl = "http://icons.iconarchive.com/icons/graphicloads/100-flat/256/home-icon.png",
            });
            myItemsSource.Add(new MyItem()
            {
                Name = "LightCyan",
                Color = Color.LightCyan,
                ImageUrl = "http://icons.iconarchive.com/icons/graphicloads/100-flat-2/256/mobile-2-icon.png",
            });
            myItemsSource.Add(new MyItem()
            {
                Name = "LightGoldenrodYellow",
                Color = Color.LightGoldenrodYellow,
                ImageUrl = "http://files.softicons.com/download/game-icons/super-mario-icons-by-sandro-pereira/png/256/Mushroom%20-%20Super.png",
            });
            myItemsSource.Add(new MyItem()
            {
                Name = "LightGreen",
                Color = Color.LightGreen,
                ImageUrl = "http://images.all-free-download.com/images/graphiclarge/harry_potter_icon_6825007.jpg",
            });
            myItemsSource.Add(new MyItem()
            {
                Name = "LightSlateGray",
                Color = Color.LightSlateGray,
                ImageUrl = "http://www.icosky.com/icon/png/Movie%20%26%20TV/Doraemon/smile.png",
            });
            myItemsSource.Add(new MyItem()
            {
                Name = "LimeGreen",
                Color = Color.LimeGreen,
                ImageUrl = "http://images.pocketgamer.co.uk/artwork/imgthumbs/na-owuz/10_mario_facts11.jpg",
            });
            myItemsSource.Add(new MyItem()
            {
                Name = "LightSalmon",
                Color = Color.LightSalmon,
                ImageUrl = "https://rocketdock.com/images/screenshots/thumbnails/Awesome_small.png",
            });
            myItemsSource.Add(new MyItem()
            {
                Name = "LightGray",
                Color = Color.LightGray,
                ImageUrl = "http://wikiclipart.com/wp-content/uploads/2018/01/Pig-face-cute-face-finance-happy-hog-pig-piggy-icon-icon-search-engine-clip-art.png",
            });
        }
	}
}