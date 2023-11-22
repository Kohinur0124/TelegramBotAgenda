namespace TelegramBotAgenta.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ChatId { get; set; }

        public ICollection<Todos> Todos { get; set; }
   
    }
}
