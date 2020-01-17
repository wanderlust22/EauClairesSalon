namespace Salon.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public int SylistId { get; set; }
        public virtual Stylist Stylist { get; set; }
    }
}