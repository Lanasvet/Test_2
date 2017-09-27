using System.ComponentModel.DataAnnotations;

namespace Parser.Models
{
    public class TextModel
    {
        [Required]
        [Display(Name = "Введите текст")]
        public string Text { get; set; }
        
        public bool IsXML { get; set; }        
    }
}