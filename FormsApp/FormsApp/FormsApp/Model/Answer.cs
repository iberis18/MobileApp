namespace FormsApp.Model
{
    //один вариант ответа на вопрос. 
    //содержит строку с текстом либо изображение, другое поле остается пустым
    public class Answer
    {
        public string Text { get; set; }
        public string Image { get; set; }

    }
}