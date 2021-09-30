using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OceanKisBahcesi.DataAccess.Helper
{
    public static class StringExtensions
    {
       
        static internal string UrlToEmbedCode(this string url)
        {
            var YoutubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)");
            Match youtubeMatch = YoutubeVideoRegex.Match(url);
            return youtubeMatch.Success ? "http://www.youtube.com/embed/" + youtubeMatch.Groups[1].Value : string.Empty;
        }

    }
}
