using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackaton.TIM.Bot.Models
{
    [Serializable]
    public class AnswerResponse
    {
        public string Answer { get; set; }
        public List<string> Questions { get; set; }
        public double Score { get; set; }
    }
}