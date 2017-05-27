using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{
    public class UserTextInput
    {
        public string BoldButton(string buttonContent)
        {            
            string boldTagFront = "<b>";
            string boldTagBack = "</b>";
            string completedString = boldTagFront + buttonContent + boldTagBack;
            return completedString;                  
        }        
       
        public static string ReplaceBold(string strIn)
        {
            // Replace [B] with <b> tags
            try
            {
                strIn = Regex.Replace(strIn, @"[B]", "<strong>",
                                        RegexOptions.None, TimeSpan.FromSeconds(1.5));
                strIn += Regex.Replace(strIn, @"[/B]", "</strong>",
                                        RegexOptions.None, TimeSpan.FromSeconds(1.5));
                return strIn;
            }
            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        public static string SanitizeScript(string str)
        {
            try
            {
                return Regex.Replace(str, @"<script>", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException) // If timeout occurs
            {
                return String.Empty;
            }
        }

        

        //public italicButton(){}
        //public underlineButton(){}
        //public linkButton(){}
        //public colorButton(){}


    }
}
