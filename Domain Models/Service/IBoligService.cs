using Domain.Models.Models;


namespace Domain.Models.Service
{
    public interface IBoligService
    {
        Task<List<Pictures>> GetAllPictures();
        List<Property> GetAllPropeties();
		Task<IEnumerable<Property>> GetPropertyById(int id);
        Task<List<User>> GetUsers();
        Task<int> CreateAnnonceAsync(Property property);
        Task AddPicturesAsync(int propertyId, List<Pictures> pictures);
        Task<List<Pictures>> GetPicturesByPropertyIdAsync(int propertyId);
        Task<int> CreateAnnonceWithPicturesAsync(Property property, List<string> pictureLinks);
    }
}
