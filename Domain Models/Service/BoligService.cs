using Dapper;
using Domain.Models.DB;
using Domain.Models.Models;

namespace Domain.Models.Service
{
    public class BoligService : IBoligService
    {
        private readonly DBService _dbService;

        public BoligService(DBService dbService)
        {
            _dbService = dbService;
        }
        public async Task<List<House>> GetAllHouses()
        {
            //typeid its type House
            using var connection = _dbService.GetConnection();
            var query = @"SELECT *
							FROM ""properties""
                            WHERE ""typeid"" = 1";

            var houses = await connection.QueryAsync<House>(query);
            return houses.ToList();
        }

        public async Task<List<Pictures>> GetAllPictures()
        {
            using var connection = _dbService.GetConnection();
            var query = @"SELECT *
							FROM ""pictures"" ";

            var pictures = await connection.QueryAsync<Pictures>(query);
            return pictures.ToList();
        }
    }
}
