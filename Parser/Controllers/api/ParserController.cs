using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Parser.Models;
using Parser.Services;
using Parser.Services.Contract;
using System.Text;


namespace Parser.Controllers.api
{
   
    public class ParserController : ApiController
    {
        private readonly IParserService parserService;

        public ParserController()
        {
            parserService = ServiseLocator.GetParserService();
        }

        public IHttpActionResult Post([FromBody]TextModel text)
        {
            if (ModelState.IsValid)
            {
                if(text.IsXML)
                {
                    var _text = parserService.GetXMLFormat(text.Text);
                    //var _text = parserService.GetSentences(text.Text);
                    return Ok(_text);
                }
                else
                {
                    var _text = parserService.CSVFormat(text.Text);
                    return Ok(_text);
                }
            }
            else
            {
                throw new System.ArgumentException("From ParserController/Post. Parameter cannot be null!");
            }            
        }
        
    }
}
