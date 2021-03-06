﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace TestViews_XPA
{
    public class PickerViewPage : ContentPage
    {
        // Dictionary to get Color from color name.
        Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
        {
            { "Aqua", Color.Aqua }, { "Black", Color.Black },
            { "Blue", Color.Blue }, { "Fucshia", Color.Fuchsia },
            { "Gray", Color.Gray }, { "Green", Color.Green },
            { "Lime", Color.Lime }, { "Maroon", Color.Maroon },
            { "Navy", Color.Navy }, { "Olive", Color.Olive },
            { "Purple", Color.Purple }, { "Red", Color.Red },
            { "Silver", Color.Silver }, { "Teal", Color.Teal },
            { "White", Color.White }, { "Yellow", Color.Yellow }
        };

        public PickerViewPage()
        {
            Label pageHeading = new Label
            {
                Text = "Picker View",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Xamarin.Forms.Picker pkrMyPicker = new Xamarin.Forms.Picker
            {
                AutomationId = "pkrMyPicker",
                Title = "Color",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Codes as per http://blog.pieeatingninjas.be/2017/07/06/bind-to-xamarin-picker-but-only-update-value-after-hitting-done-on-ios/
            //   This is to change the bound control only when the Done button is pressed only in iOS.
            //   The "using Xamarin.Forms.PlatformConfiguration.iOSSpecific;" is also need to be added.
            //   This makes the Picker an ambiguous object. So it is addressed explicitly as
            //   Xamarin.Forms.Picker just above.
            pkrMyPicker.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUpdateMode(UpdateMode.WhenFinished);

            foreach (string colorName in nameToColor.Keys)
            {
                pkrMyPicker.Items.Add(colorName);
            }

            // Create BoxView for displaying picked Color
            BoxView bvColorSelected = new BoxView
            {
                AutomationId = "bvColorSelected",
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            pkrMyPicker.SelectedIndexChanged += (sender, args) =>
            {
                if (pkrMyPicker.SelectedIndex == -1)
                {
                    bvColorSelected.Color = Color.Default;
                }
                else
                {
                    string colorName = pkrMyPicker.Items[pkrMyPicker.SelectedIndex];
                    bvColorSelected.Color = nameToColor[colorName];
                }
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    pageHeading,
                    pkrMyPicker,
                    bvColorSelected
                }
            };

        }
    }
}