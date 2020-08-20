using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QnABots.Models
{
    public class Answer
    {
        public QnAreceivedAnswer [] answers { get; set; }
    }
    public class QnAreceivedAnswer 
    { 
        public string[] questions { get; set; }
        public string answer { get; set; }
        public double score { get; set; }
        public int id { get; set; }
        public string sourse { get; set; }
        public object[] metadata { get; set; }
    }
}
