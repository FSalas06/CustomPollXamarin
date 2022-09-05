using System;
using System.Collections.Generic;

namespace CustomPollXamarin.Models
{
    public class QuestAnsware
    {
        public int Step { get; set; }
        public int Type { get; set; }
        public string Quest { get; set; }
        public string Answare { get; set; }
        public List<string> AnswareList { get; set; }
    }
}
