using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parser.Services.Contract;
using Parser.Services.Implementation;

namespace Parser.Services
{
    public class ServiseLocator
    {
        public static IParserService GetParserService()
        {
            return new ParserService();
        }
    }
}