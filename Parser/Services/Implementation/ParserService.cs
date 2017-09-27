using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parser.Models;
using Parser.Services.Contract;
using System.Text;

namespace Parser.Services.Implementation
{
    public class ParserService : IParserService
    {
        public Text GetXMLFormat(string text)
        {
            var parsedText = new Text();
            parsedText.Sentences = GetSentences(text);            
            return parsedText;
        } 
        
        
        public string CSVFormat(string text)
        {
            var parsedText = new StringBuilder(Environment.NewLine);
            var temp = GetSentences(text);
            int maxLength = 0;            
            foreach (var item in temp)
            {
                if(item.Words.Count > maxLength)
                {
                    maxLength = item.Words.Count;
                }
            }

            parsedText.Append("<p>");
            for(int i = 0; i < maxLength; i++)
            {
                parsedText.Append(", Word ").Append(i + 1);
            }
            parsedText.Append("</p>");
            int count = 1;
            foreach(var item in temp)
            {
                parsedText.Append("<p>Sentence ").Append(count);
                count++;
                foreach(var w in item.Words)
                {
                    parsedText.Append(", ").Append(w.Word);
                }
                parsedText.Append("</p>");
            }

            return parsedText.ToString();
        }

        private List<Sentence> GetSentences(string text)
        {            
            var sentences = new List<Sentence>();
            var temp = text.Split(new Char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            int length = temp.Length;

            foreach (var item in temp)
            {
                var sentence = new Sentence
                {
                    Words = GetWords(item)
                };
                sentences.Add(sentence);
            }
            return sentences;
        }

        private List<Words> GetWords(string sentence)
        {
            char[] delimiterChars = { ' ', ',', '?', '!', ':', '\t', '\n', '\r', '\"' };
            var temp = sentence.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries).ToList();
            temp.Sort();
            var words = new List<Words>();
            foreach (var item in temp)
            {
                var word = new Words
                {
                    Word = item
                };
                words.Add(word);  
            }            
            return words;
        }
       
    }
}