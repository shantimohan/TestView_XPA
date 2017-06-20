using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestViews_XPA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnActivityIndicator_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ActivityIndicatorPage());
        }

        private void btnBoxView_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new BoxViewPage());
        }

        private void btnDatePickerView_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new DatePickerPage());
        }

        private void btnEditorView_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new EditorViewPage());
        }

        private void btnEntryView_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new EntryViewPage());
        }

        private void btnImageView_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ImageViewPage());
        }

        private void btnListView_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ListViewPage());
        }

        private void btnPickerViewPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new PickerViewPage());
        }

        private void btnProgressBarPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ProgressBarPage());
        }

        private void btnSearchBarPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SearchBarPage());
        }

        private void btnStepperViewPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new StepperViewPage());
        }

        private void btnSwitchViewPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SwitchViewPage());
        }

        private void btnTableViewPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new TableViewPage());
        }

        private void btnTimePickerPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new TimePickerPage());
        }

        private void btnWebViewPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new WebViewPage());
        }

        private void btnToolbarItems_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ToolbarItemsPage());
        }
    }
}
