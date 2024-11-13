namespace Domain.Models.Models
{
    public class Apartment:Base
    {
        public int? floor { get; set; }
        public bool hasbalcony { get; set; }
        public bool haselevator { get; set; }
    }
}
