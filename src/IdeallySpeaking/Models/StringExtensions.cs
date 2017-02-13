using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{
    public static class StringExtensions
    {
        public static string ArticleShortener(this string str, int length)
        {
            if (String.IsNullOrEmpty(str))
                throw new ArgumentNullException(str);
            var words = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words[0].Length > length)
                return words[0];

            var sb = new StringBuilder();
            foreach (var word in words)
            {
                if ((sb + word).Length > length)
                    return string.Format("{0}...", sb.ToString().TrimEnd(' '));
                sb.Append(word + " ");
            }
            return string.Format("{0}...", sb.ToString().TrimEnd(' '));
        }
    }
}
