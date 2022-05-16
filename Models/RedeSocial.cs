namespace TiAchei_Tcc.Models
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public string UrlRede { get; set; }
        public string  UserId { get; set; }
        public User User { get; set; }
    }
}