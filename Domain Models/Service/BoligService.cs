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

		public async Task<List<AllHouses>> GetAll()
		{
			using var connection = _dbService.GetConnection();

			var query = @"
                    SELECT ""id"", ""title"", ""year"", ""squaremeters"", ""location"", ""description"", ""roomscount"", ""price"", ""createdat"", ""typeid""
                    FROM ""properties""";

			var houses = await connection.QueryAsync<AllHouses>(query);

			return houses.ToList();
		}


		public async Task<List<House>> GetAllHouses()
        {
            using var connection = _dbService.GetConnection();
            var query = @"SELECT *
                          FROM ""properties""
                          WHERE ""typeid"" = 1";

            var houses = await connection.QueryAsync<House>(query);
            return houses.ToList();
        }

        public async Task<List<Apartment>> GetAllApartments()
        {
            using var connection = _dbService.GetConnection();
            var query = @"SELECT *
                          FROM ""properties""
                          WHERE ""typeid"" = 2"; 

            var apartments = await connection.QueryAsync<Apartment>(query);
            return apartments.ToList();
        }

        public async Task<List<SummerHouse>> GetAllSummerHouses()
        {
            using var connection = _dbService.GetConnection();
            var query = @"SELECT *
                          FROM ""properties""
                          WHERE ""typeid"" = 3"; 

            var summerhouses = await connection.QueryAsync<SummerHouse>(query);
            return summerhouses.ToList();
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
