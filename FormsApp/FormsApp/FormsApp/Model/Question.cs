using System.Collections.Generic;

namespace FormsApp.Model
{
    public class Question
    {
        public string Text { get; set; }
        public string Image { get; set; }
        public List<Answer> Answers { get; set; }
    }
}