using Domain.Models.Models;


namespace Domain.Models.Service
{
    public interface IBoligService
    {
        Task<List<Pictures>> GetAllPictures();
        List<Property> GetAllPropeties();
		Task<IEnumerable<Property>> GetPropertyById(int id);
        Task<List<User>> GetUsers();
        Task<int> CreateAnnonceWithPicturesAsync(Property property, List<string> pictureLinks);
        Task DeleteProperty(int id);
        Task UpdatePropertyAsync(int id, Property property);
    }
}
