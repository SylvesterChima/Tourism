using System;
using System.Collections.Generic;
using System.Text;

namespace Tourism.Constants
{
    public static class PageConstants
    {
        public static readonly string PrimaryColor = "#1e9f79";
        public static readonly string HintColor = "#BBBBBB";
        public static readonly string HintColorDark = "#777777";
        public static readonly string White = "#FFFFFF";
        public static readonly string Black = "#000000";
        public static readonly string Transparent = "#00000000";

        public static readonly string YOUTUBE_CHANNEL_ID = "UCtY1q-2V5TvVDmCCXaVyjgQ";



#if ReleaseProd
        public const string APPCENTER_IOS_KEY = "9314c883-fc6f-4cec-81d8-b1aa3449e655";
        public const string APPCENTER_ANDROID_KEY = "2f311185-24f3-45fa-9bea-466922070fc2";
#else
        public const string APPCENTER_IOS_KEY = "9314c883-fc6f-4cec-81d8-b1aa3449e655";
        public const string APPCENTER_ANDROID_KEY = "2f311185-24f3-45fa-9bea-466922070fc2";
#endif
    }
}
