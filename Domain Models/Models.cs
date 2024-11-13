namespace Domain.Models
{
    public abstract class Base
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Year { get; set; }
        public int SquareMeters { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int RoomsCount { get; set; }
        public int? OwnerId { get; set; }
        public  List<string>? Pictures { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public class House : Base
    {
        public bool HasGarden { get; set; }
        public int NumberOfFloors { get; set; }
        public bool HasGarage { get; set; }
    }

    public class Apartment:Base
    {
        public int? Floor { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasElevator { get; set; }
    }

    public class SummerHouse : Base
    {
        public bool IsSeasonal { get; set; }        
        public int DistanceToBeach { get; set; } 
        public bool HasPrivatePool { get; set; }
    }
}
