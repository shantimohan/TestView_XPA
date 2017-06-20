using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TestViews_XPA.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile("../../../TestViews_XPA/TestViews_XPA.Android/bin/Debug/TestViews_XPA.Android.apk")
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .AppBundle("../../../TestViews_XPA/TestViews_XPA.iOS/bin/iPhoneSimulator/Debug/TestViews_XPA.iOS.exe")
                .EnableLocalScreenshots()
                .StartApp();
        }
    }
}

