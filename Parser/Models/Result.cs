using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser.Models
{
    public class Result
    {
        public List<string>AllWords { get; set; }

        public Dictionary<int, List<string>> Sentences { get; set; } 
    }
}