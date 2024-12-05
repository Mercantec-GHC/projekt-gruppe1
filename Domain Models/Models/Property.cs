using Domain.Models.Enum;

namespace Domain.Models.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int SquareMeters { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; } 
        public int TypeId { get; set; }

        public bool HasGarden { get; set; }
        public int NumberOfFloors { get; set; }
        public bool HasGarage { get; set; }
        public int Floor { get; set; }
        public int RoomsCount { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasElevator { get; set; }
        public bool IsSeasonal { get; set; }
        public int DistanceToBeach { get; set; } 
        public bool HasPrivatePool { get; set; }
        public IEnumerable<Pictures> Pictures { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string TypeName => ((PropertyType)TypeId).ToString();
    }
}
