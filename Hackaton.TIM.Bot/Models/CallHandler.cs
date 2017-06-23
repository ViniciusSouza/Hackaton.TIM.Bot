using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Hackaton.TIM.Bot.Models
{
    public class CallHandler
    {
        private string _pattern = @"\((.*?)\)";
        
        public string RegexMatcher(string text)
        {
            var regex = new Regex(_pattern);
            var result = regex.Match(text);
            var command = result.Groups[1].Value;

            return command;
        }
    }
}