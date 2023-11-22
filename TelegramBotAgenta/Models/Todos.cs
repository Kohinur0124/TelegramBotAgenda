namespace TelegramBotAgenta.Models
{
    public class Todos
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string Description  { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;

        public Users Users { get; set; }
    }
}
