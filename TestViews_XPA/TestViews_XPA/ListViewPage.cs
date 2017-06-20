using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TestViews_XPA
{
    public class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            Label header = new Label
            {
                Text = "ListView",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Define some data.
            List<Person> people = new List<Person>
            {
                new Person("Abigail", new DateTime(1975, 1, 15), Color.Aqua),
                new Person("Bob", new DateTime(1976, 2,20), Color.Black),
                new Person("Cathy", new DateTime(1977, 3, 10), Color.Violet),
                new Person("David", new DateTime(1978, 4, 25), Color.Magenta),
                new Person("Eugenie", new DateTime(1979, 6, 5), Color.Olive),
                new Person("Freddie", new DateTime(1960, 6, 30), Color.Green),
                new Person("Greta", new DateTime(1961, 7, 15), Color.Red),
                new Person("Harold", new DateTime(1962, 6, 10), Color.Brown),
                new Person("Irene", new DateTime(1963, 9, 25), Color.Blue),
                new Person("Yvonne", new DateTime(1987, 1, 10), Color.Purple),
                new Person("Zachary", new DateTime(1988, 2, 5), Color.Red),
            };

            // Create the ListView.
            ListView lvMyList = new ListView
            {
                AutomationId = "lvMyList",

                // Source of data items.
                ItemsSource = people,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "PersonName");

                    Label birthdayLabel = new Label();
                    birthdayLabel.SetBinding(Label.TextProperty,
                        new Binding("BirthDay", BindingMode.OneWay, null, null, "Born {0:d}"));

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "FavColor");

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        AutomationId = "lvMyList_ViewCell",

                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel
                                        }
                                    }
                            }
                        }
                    };
                })
            };

            lvMyList.ItemSelected += lvMyList_ItemSelected;

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    lvMyList
                }
            };
        }

        private async void lvMyList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Deselect the item
            ((ListView)sender).SelectedItem = null;

            if (e.SelectedItem != null)
            {
                Person item = (Person)e.SelectedItem;

                string personDetails = item.PersonName + " born on " + item.BirthDay.ToString("ddd MMM d, yyyy");

                await this.DisplayAlert("Person Details", personDetails, "OK");
            }
        }
    }
}