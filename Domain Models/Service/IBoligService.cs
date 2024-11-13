using Domain.Models.Models;

namespace Domain.Models.Service
{
    public interface IBoligService
    {
        Task<List<House>> GetAllHouses();
    }
}
