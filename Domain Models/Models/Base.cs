namespace Domain.Models.Models
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
        public decimal? Price {  get; set; }

        public IEnumerable<Pictures> Pictures { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
