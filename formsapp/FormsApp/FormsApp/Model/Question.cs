using System.Collections.Generic;

namespace FormsApp.Model
{
    //вопрос из теста
    //содержит текст вопроса, и/или картинку, список возможных вариантов ответов

    public class Question
    {
        public string Text { get; set; }
        public string Image { get; set; }
        public List<Answer> Answers { get; set; }
    }
}