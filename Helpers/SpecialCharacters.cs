using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorQuiz.Helpers
{
    public class SpecialCharactersCheck
    {
        public string CharacterCheck(string content)
        {
            content = content.Replace("&quot;", "'");
            content = content.Replace("&#039;", "'");
            content = content.Replace("&shy;", "-");
            content = content.Replace("&amp;", "&");
            content = content.Replace("&iacute;", "i");
            content = content.Replace("&auml;", "ä");
            content = content.Replace("&ouml;", "ö");
            content = content.Replace("&oacute;", "ó");
            content = content.Replace("&ndash;", "-");
            content = content.Replace("&Ograve;", "ò");
            content = content.Replace("&euml;", "ë");
            content = content.Replace("&rsquo;", "’");
            content = content.Replace("&ldquo;", "“");
            content = content.Replace("&rdquo;", "”");
            content = content.Replace("&deg;", "°");
            content = content.Replace("&lrm;", "");
            content = content.Replace("&ecirc;", "ê");
            content = content.Replace("&eacute;", "é");
            content = content.Replace("&amp;", "&");
            
            return content;
        }
    }
}
