using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace VNITLibrary
{
    public static class StringUltil
    {
        /* Get MD5 string */
        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /* Change first character of string to uppercase */
        public static string UCFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        //Extend methods for STRING
        public static string ToUnsigned(this string source)
        {
            var pattern = new string[7];
            pattern[0] = "a|(á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ)";
            pattern[1] = "o|(ó|ỏ|ò|ọ|õ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ)";
            pattern[2] = "e|(é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ)";
            pattern[3] = "u|(ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ)";
            pattern[4] = "i|(í|ì|ỉ|ị|ĩ)";
            pattern[5] = "y|(ý|ỳ|ỷ|ỵ|ỹ)";
            pattern[6] = "d|đ";
            foreach (var t in pattern)
            {
                var replaceChar = t[0];
                var matchs = Regex.Matches(source, t);
                source = matchs.Cast<Match>().Aggregate(source, (current, m) => current.Replace(m.Value[0], replaceChar));
            }
            return source;
        }
        public static string ToSeoString(this string source)
        {
            var c = new List<string> { "[", "~", "#", "%", "&", "*", "{", "}", "(", ")", "/", "<", ">", "?", "|", "\",", "-", "]", "+", ",", "\"", ":", ".", "'", "”", "“", "’", "‘", "–" };
            source = c.Aggregate(source, (current, s) => current.Replace(s, ""));
            return source.ToLower().ToUnsigned().Replace(" ", "-");
        }
        public static string ToKeyword(this string source)
        {
            return ToKeyword(source, true);
        }
        public static string ToDateTimeFormat(this DateTime? source, string format = "HH:mm dd/MM/yyyy")
        {
            return ConvertType.ToDateTime(source).ToString(format);
        }
        public static string ToTimeAgo(this DateTime? source)
        {
            var date = ConvertType.ToDateTime(source);
            TimeSpan timeSince = DateTime.Now.Subtract(date);

            if (timeSince.TotalMilliseconds < 1)
                return "not yet";
            if (timeSince.TotalMinutes < 1)
                return "mới đây";
            if (timeSince.TotalMinutes < 2)
                return "1 phút trước";
            if (timeSince.TotalMinutes < 60)
                return string.Format("{0} phút trước", timeSince.Minutes);
            if (timeSince.TotalMinutes < 120)
                return "1 hour ago";
            if (timeSince.TotalHours < 24)
                return string.Format("{0} giờ trước", timeSince.Hours);
            if (timeSince.TotalDays == 1)
                return "hôm qua";
            if (timeSince.TotalDays < 7)
                return string.Format("{0} ngày trước", timeSince.Days);
            if (timeSince.TotalDays < 14)
                return "tuần trước";
            if (timeSince.TotalDays < 21)
                return "2 tuần trước";
            if (timeSince.TotalDays < 28)
                return "3 tuần trước";
            if (timeSince.TotalDays < 60)
                return "tháng trước";
            if (timeSince.TotalDays < 365)
                return string.Format("{0} tháng trước", Math.Round(timeSince.TotalDays / 30));
            if (timeSince.TotalDays < 730)
                return "năm ngoái";
            return string.Format("{0} năm trước", Math.Round(timeSince.TotalDays / 365));

        }
        public static string ToKeyword(this string source, bool toUnsigned)
        {
            var c = new List<string> { "[", "~", "#", "%", "&", "*", "{", "}", "(", ")", "/", "<", ">", "?", "|", "\",", "-", "]", "+", "\"", ":", ".", "'", "”", "“", "’", "‘", "–" };
            source = source.Replace(",", " ");
            source = c.Aggregate(source, (current, s) => current.Replace(s, ""));
            source = source.Replace("  ", " ");
            return toUnsigned ? source.ToLower().ToUnsigned() : source.ToLower();
        }
        public static string Substringdot(this string source, int strlen)
        {
            if (source.Length > strlen)
                return source.Substring(0, strlen) + "...";
            return source;
        }
        public static string StripHTMLTags(this string source)
        {
            var array = new char[source.Length];
            var arrayIndex = 0;
            var inside = false;

            foreach (var @let in source)
            {
                if (@let == '<')
                {
                    inside = true;
                    continue;
                }
                if (@let == '>')
                {
                    inside = false;
                    continue;
                }
                if (inside) continue;
                array[arrayIndex] = @let;
                arrayIndex++;
            }
            return new string(array, 0, arrayIndex);
        }
        public static string ReplaceLineBreak(this string source)
        {
            const string replaceWith = "<br/>";
            return source.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
        }
        public static string ToThumbnail(this string source)
        {
            source = source ?? "";
            if (string.IsNullOrEmpty(source.Trim()))
                return "Default path here - can get from database";
            if (source.StartsWith("/Uploads/"))
            {
                if (!source.StartsWith("/Uploads/_thumbs/"))
                    return source.Replace("/Uploads/", "/Uploads/_thumbs/");
            }
            return source;
        }
        public static string ToImage(this string source)
        {
            source = source ?? "";
            if (string.IsNullOrEmpty(source.Trim()))
                return "/resources/images/no-image.jpg";
            return source;
        }

        public static bool IsImage(this HttpPostedFile file)
        {
            if (file == null) return false;
            var ext = Path.GetExtension(file.FileName).ToLower();
            if (ext != ".jpg" && ext != ".gif" && ext != ".png" && ext != ".bmp") return false;
            return (Regex.IsMatch(file.ContentType, "image/\\S+") && (file.ContentLength > 0));
        }


        public static bool IsEmail(this string str)
        {
            return Regex.IsMatch(str, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
        }

        public static string HtmlEncode(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
        public static string HtmlDecode(this string str)
        {
            return HttpUtility.HtmlDecode(str);
        }
        public static string UrlEncode(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }
        public static string UrlDecode(this string str)
        {
            return HttpUtility.UrlDecode(str);
        }
    }
}
