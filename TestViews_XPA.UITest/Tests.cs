using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

/*
 * Description:
 * This constitutes 25 tests for automatically tested the UI views
 *   available for Xamarin.Forms
 * 
 * The list of views is found at: https://developer.xamarin.com/guides/xamarin-forms/user-interface/controls/views/
 * 
 * Guidence to designing of the tests is inspired by the following github repo
 *   https://github.com/brminnick/forms-xtc-guide
 *   
 * Change & Test Log:
 * Jun 20, 2017 - 24 tests pass successfully (in Android - in iOS not run tests)
 *                   3 of them are not completed (refer to TODO Task list)
 *              - The test "SetUrlInWebView" fails with error "URL was NOT changed"
 *              - Created playlist "Android-UITests"
 *              - Created playlist "iOS-UITests"
 *              - App runs perfectly in Android emulators (Marshmallow, Lollipop, Kitkat)
 *              - In iOS simuilator the WebView is not displaying the web page
 */

namespace TestViews_XPA.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //[Test]
        //public void AppLaunches()
        //{
        //    app.Screenshot("First screen.");
        //}

        [Test]
        [Category("Indicators")]
        public void StartAndStopActivityIndicator()
        {
            // Go to ActivityIndicatorPage
            app.Tap("btnActivityIndicator");

            // In Activity Indicator Page
            app.Tap("btnStartActivity");
            app.WaitForElement(x => x.Marked("BusyIndicator"));

            app.Tap("btnStopActivity");
            app.WaitForNoElement(x => x.Marked("BusyIndicator"));
            app.Back();

            // Exit app
            app.Back();
        }

        [Test]
        [Category("Basic Views")]
        [TestCase(1)]
        [TestCase(2)]
        public void ChangeColorOfBoxView(int color_sequence)
        {
            // Go to Box View Page
            app.Tap("btnBoxView");

            if (color_sequence == 1)
                // Change to Color 1 - Green
                app.Tap("btnChangeColor1");
            else
                // Change to Color 2 - Red
                app.Tap("btnChangeColor2");

            // Though there is no Clicked event defined for
            //    BoxView, the following Tap test doesn't
            //    raise an error
            app.Tap(x => x.Marked("bvMyBox"));

            app.Back();

            // Exit app
            app.Back();
        }

        [Test]
        [Category("Pickers")]
        [TestCase(2017,3,8)]
        [TestCase(1950,7,15)]
        public void SelectADateInDatePicker(int y, int m, int d)
        {
            int timeoutSeconds = 50;
            DateTime date = new DateTime(y, m, d);

            // Go to Date Picker View Page
            app.Tap("btnDatePickerView");

            // Activate the datepicker
            app.Tap("dpMyDate");

            if (platform == Platform.Android)
            {
                // Wait for DatePicker animation to complete
                app.WaitForElement(x => x.Marked("dpMyDate"), "Timed out", TimeSpan.FromSeconds(timeoutSeconds));

                // Invoke updateDate native Android method on displayed DatePicker
                /*
                 * In the github project https://github.com/brminnick/forms-xtc-guide
                 *   the parts of the date are used directly as below:
                 *   app.Query(x => x.Class("DatePicker").Invoke("updateDate", date.Year, date.Month, date.Day));
                 *   
                 * But actually that didn't work. I don't know why but the date.Month has to be decremented.
                 */
                app.Query(x => x.Class("DatePicker").Invoke("updateDate", date.Year, date.Month - 1, date.Day));

                // Tap Ok button to close the DatePicker
                app.Tap("button1");
            }
            else
            {
                // Wait for DatePicker animation to complete
                app.WaitForElement(x => x.Class("UIPickerView"));

                // Invoke selectRow native iOS method to set the desired date
                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", date.Month - 1, "inComponent", 0, "animated", true));
                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", date.Day - 1, "inComponent", 1, "animated", true));
                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", date.Year - 1, "inComponent", 2, "animated", true));

                // Tap Done button to close the DatePicker
                app.Tap(x => x.Class("UIToolbarTextButton"));
            }

            // Validate the result
            var appResult = app.Query("dpMyDate").FirstOrDefault().Text == date.ToString("ddd d MMM yyyy");
            Assert.IsTrue(appResult, "Date is NOT set correctly.");

            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();
        }

        [Test]
        [Category("Basic Views")]
        [TestCase("Hello World! Welcome!")]
        [TestCase("Xamarin is a great platform to develop cross-platform apps using C#. Visual Studio makes it very easy to debug apps. UITest makes it much easier to test repeatedly.")]
        public void EnterTextInAnEditorView(string myText)
        {
            // Go to Editor View Page
            app.Tap("btnEditorView");

            // Clear existing text
            app.ClearText("ediMyEditor");
            app.DismissKeyboard();

            // Validate the text is cleared
            var isTextCleared = app.Query("ediMyEditor").FirstOrDefault().Text == "";
            Assert.IsTrue(isTextCleared, "Editor not cleared of text.");

            // Enter the given text
            app.EnterText("ediMyEditor", myText);
            app.DismissKeyboard();

            // Validate the given text is entered
            var isTextEntered = app.Query("ediMyEditor").FirstOrDefault().Text == myText;
            Assert.IsTrue(isTextEntered, "Given text not entered in Editor.");

            // Exit Editor View Page
            app.Back();

            // Exit app
            app.Back();
        }

        [Test]
        [Category("Basic Views")]
        [TestCase("asdfg", "qwerty")]
        [TestCase("zxcvb", "12345")]
        [TestCase("asdfg", "12345")]
        public void EnterTextIntoEntryView(string userName, string password)
        {
            // Go to Entry View Page
            app.Tap("btnEntryView");

            // Enter Username
            app.EnterText("entUserName", userName);
            app.DismissKeyboard();

            // Enter Password
            app.EnterText("entPassword", password);
            app.DismissKeyboard();

            // Check login credentials
            app.Tap("btnLogin");

            // Validate entered values
            var loginResult = app.Query("lblLoginResult").FirstOrDefault().Text != "Login Result Here";
            Assert.IsTrue(loginResult, "Login validation NOT done.");

            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();
        }

        //TODO Check if translated the image view
        [Test]
        [Category("Basic Views")]
        public void TranslateImage()
        {
            // Go to Image View Page
            app.Tap("btnImageView");

            // Translate Image
            app.Tap("btnTranslateImage");

            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();
        }

        [Test]
        [Category("Data Views")]
        [TestCase(0)]
        [TestCase(5)]
        public void SelectListViewItem(int itemIndexToSelect)
        {
            int timeoutSeconds = 50;
            string strMessage = "";
            Func<AppQuery, AppQuery> viewCellInListView;

            // Go to List View Page
            app.Tap("btnListView");

            if (platform == Platform.Android)
                viewCellInListView = x => x.Class("ViewCellRenderer_ViewCellContainer").Index(itemIndexToSelect);
            else
                viewCellInListView = x => x.Marked("lvMyList_ViewCell").Index(itemIndexToSelect);

            app.WaitForElement(viewCellInListView, "Timed out waiting for given item to appear", TimeSpan.FromSeconds(timeoutSeconds));

            // Select the item that displays the MessageAlert to appear
            app.Tap(viewCellInListView);

            // Validate the item selected
            if (itemIndexToSelect == 0)
                strMessage = "Abigail born on Wed Jan 15, 1975";
            else if (itemIndexToSelect == 5)
                strMessage = "Freddie born on Thu Jun 30, 1960";
            else
                strMessage = "";

            app.WaitForElement(x => x.Id("message"));
            var appResult = app.Query("message").FirstOrDefault().Text == strMessage;

            // Tap the Cancel button marked as OK to dismiss the message alert
            app.Tap("button2");

            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();

            Assert.IsTrue(appResult, "Wrong item was selected.");
        }

        //TODO Pick a color and assert if it is selected
        //  Need to know the respective native method to use in Invoke()
        [Test]
        [Category("Pickers")]
        public void SelectColorInPicker()
        {
            // Go to Picker View Page
            app.Tap("btnPickerViewPage");



            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();
        }

        [Test]
        [Category("Indicators")]
        [TestCase(50)]
        [TestCase(75)]
        public void SetProgressOfOperation(int percentProgress)
        {
            // Go to Progress Bar Page
            app.Tap("btnProgressBarPage");

            if (platform == Platform.Android)
            {
                int progressToSet_Android = percentProgress * 100;
                app.Query(x => x.Class("ProgressBar").Invoke("setProgress", progressToSet_Android));
                var appResult_Android = app.Query(x => x.Class("ProgressBar").Invoke("getProgress")).FirstOrDefault().ToString() == progressToSet_Android.ToString();

                Assert.IsTrue(appResult_Android, "Progress NOT set correctly");
            }
            else
            {
                float progressToSet_iOS = percentProgress / 100.0f;
                app.Query(x => x.Class("UIProgressView").Invoke("setProgress:animated", progressToSet_iOS));
                var appResult_iOS = app.Query(x => x.Class("UIProgressView").Invoke("progress")).FirstOrDefault().ToString() == progressToSet_iOS.ToString();

                Assert.IsTrue(appResult_iOS, "Progress NOT set correctlyh");
            }

            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();
        }

        [Test]
        [Category("Web and Search")]
        public void SearchText()
        {
            string strSearchText = "Microsoft";

            // Go to Search Bar Page
            app.Tap("btnSearchBarPage");

            app.EnterText(x => x.Marked("sbMySearchBar"), strSearchText);
            app.PressEnter();
            var appResult = app.Query("lblResults").FirstOrDefault().Text.Contains(strSearchText);
            Assert.IsTrue(appResult, "Search was not successful");

            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();
        }

        [Test]
        [Category("Basic Views")]
        public void ChangeStepperValue()
        {
            // Go to Stepper View Page
            app.Tap("btnStepperViewPage");

            // Increment stepper value
            if (platform == Platform.Android)
                //app.Tap(x => x.Class("android.widget.Button").Text("+"));
                app.Tap("+");
            else
                app.Tap("Increment");

            // Validate incremented value
            var appResult = app.Query("lblStepperValue").FirstOrDefault().Text == "Stepper value is 6.0";
            Assert.IsTrue(appResult, "Stepper value NOT incremented");

            // Decremetn stepper value
            if (platform == Platform.Android)
                //app.Tap(x => x.Class("android.widget.Button").Text("-"));
                app.Tap("-");
            else
                app.Tap("Decrement");

            // Validate incremented value
            appResult = app.Query("lblStepperValue").FirstOrDefault().Text == "Stepper value is 5.0";
            Assert.IsTrue(appResult, "Stepper value NOT decremented");


            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();

        }

        [Test]
        [Category("Basic Views")]
        public void ToggleSwitch()
        {
            // Go to Switch View Page
            app.Tap("btnSwitchViewPage");

            // Get current status from lblSwitchStatus
            var currentSwitchStatus = app.Query("lblSwitchStatus").FirstOrDefault().Text.Contains("True");

            // Tap it once and check status if it is different from current status
            app.Tap("swiMySwitch");
            var statusAfterTap = app.Query("lblSwitchStatus").FirstOrDefault().Text.Contains("True");
            var isSwitchToggled = statusAfterTap != currentSwitchStatus;
            Assert.IsTrue(isSwitchToggled, "Switch NOT Toggled (First time)");

            // Tap once again and check if status changed
            currentSwitchStatus = statusAfterTap;
            app.Tap("swiMySwitch");
            statusAfterTap = app.Query("lblSwitchStatus").FirstOrDefault().Text.Contains("True");
            isSwitchToggled = statusAfterTap != currentSwitchStatus;
            Assert.IsTrue(isSwitchToggled, "Switch NOT Toggled (Second time)");

            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();
        }

        //TODO Check how to test TalbeView
        [Test]
        [Category("Data Views")]
        public void ReadAndSetTableViewCells()
        {
            // Go to TableView Page
            app.Tap("btnTableViewPage");


            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();
        }

        [Test]
        [Category("Pickers")]
        [TestCase(9, 23, 0)]
        [TestCase(10, 42, 1)]
        public void SelectTimeInTimePicker (int timeHour, int timeMinute, int am0pm1)
        {
            // Go to TimePicker View
            app.Tap("btnTimePickerPage");

            // Activate the timepicker
            app.Tap("tpMyTime");

            if (platform == Platform.Android)
            {
                // Wait for time picker animation to complete
                app.WaitForElement(x => x.Marked("tpMyTime"));

                // Invoke setHour & setMinute native Android methods to set time
                app.Query(x => x.Marked("tpMyTime").Invoke("setHour", timeHour));
                app.Query(x => x.Id("tpMyTime").Invoke("setMinute", timeMinute));

                // Tap OK to close the timepicker
                app.Tap("button1");
            }
            else
            {
                // Wait for TimePicker animation to complete
                app.WaitForElement(x => x.Class("UIPickerView"));

                // Invoke selectRow native iOS method to set the desired time
                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", timeHour, "inComponent", 0, "animated", true));
                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", timeMinute, "inComponent", 1, "animated", true));
                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", am0pm1, "inComponent", 2, "animated", true));

                // Tap Done button to close the TimePicker
                app.Tap(x => x.Class("UIToolbarTextButton"));
            }

            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();
        }

        private bool IsLoadedPage()
        {
            int loadingProgress = 0;
            while (loadingProgress < 100)
            {
                if (platform == Platform.Android)
                    loadingProgress = Convert.ToInt32(app.Query(x => x.Marked("wvMyWebView").Invoke("getProgress")).FirstOrDefault().ToString());
                else
                    loadingProgress = Convert.ToInt32(app.Query(x => x.Class("Xamarin_Forms_Platform_iOS_WebViewRenderer").Invoke("isLoading")).ToString());
            }

            return true;
        }

        //TODO Test Fails: URL not changed
        [Test]
        [Category("Web and Search")]
        public void SetUrlInWebView()
        {
            string urlToSet = "http://www.microsoft.com";
            bool appResult = false;

            // Go to WebView Page
            app.Tap("btnWebViewPage");

            if (IsLoadedPage())
            {
                // Set the desired URL
                if (platform == Platform.Android)
                {
                    app.Query(x => x.Marked("wvMyWebView").Invoke("setUrl", urlToSet));
                    if (IsLoadedPage())
                    {
                        appResult = app.Query(x => x.Marked("wvMyWebView").Invoke("getUrl")).FirstOrDefault().ToString() == urlToSet;
                    }
                }
                else
                {
                    app.Query(x => x.Class("Xamarin_Forms_Platform_iOS_WebViewRenderer").Invoke("request", urlToSet));
                    if (IsLoadedPage())
                    {
                        appResult = app.Query(x => x.Class("Xamarin_Forms_Platform_iOS_WebViewRenderer").Invoke("request")).FirstOrDefault().ToString() == urlToSet;
                    }
                }
            }

            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();

            Assert.IsTrue(appResult, "URL was NOT changed");
        }

        [Test]
        [TestCase("Accept")]
        [TestCase("Reject")]
        [Category("Menus and Toolbars")]
        public void PressAToolbarItemButton(string TBI2Press)
        {
            // Go to Toolbar Items Page
            app.Tap("btnToolbarItems");
            
            if (TBI2Press == "Accept")
            {
                if (platform == Platform.Android)
                    app.Tap(x => x.Marked("Accept"));
                else
                    app.Tap(x => x.Id("tbiAccept"));
            }
            else
            {
                if (platform == Platform.Android)
                    app.Tap(x => x.Marked("Cancel"));
                else
                    app.Tap(x => x.Id("tbiCancel"));
            }

            // Verify correct one was pressed
            var appResult = app.Query(x => x.Marked("lblResult")).FirstOrDefault().Text == TBI2Press + "ed";
            Assert.IsTrue(appResult, "Desired Toobar Button NOT pressed");

            // Go back to Home Page
            app.Back();

            // Exit app
            app.Back();
        }

        //[Test]
        //public void Start_REPL()
        //{
        //    app.Repl();
        //}
    }
}

