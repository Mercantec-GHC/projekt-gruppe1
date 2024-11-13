namespace Domain.Models.Models
{
    public class House:Base
    {
        public bool HasGarden { get; set; }
        public int NumberOfFloors { get; set; }
        public bool HasGarage { get; set; }
    }
}
