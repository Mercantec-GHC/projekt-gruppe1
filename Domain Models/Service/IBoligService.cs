using Domain.Models.Models;


namespace Domain.Models.Service
{
    public interface IBoligService
    {
        Task<List<Pictures>> GetAllPictures();
        Task<List<Property>> GetAllPropeties();
        Task<IEnumerable<Property>> GetPropertyById(int id);
        Task<List<User>> GetUsers();
    }
}
