using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Models;

namespace Parser.Services.Contract
{
    public interface IParserService
    {
        Text GetXMLFormat(string text);
        string CSVFormat(string text);
    }
}
