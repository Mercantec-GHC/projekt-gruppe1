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

        public async Task<List<Pictures>> GetAllPictures()
        {
            using var connection = _dbService.GetConnection();
            var query = @"SELECT *
						FROM ""pictures"" ";

            var pictures = await connection.QueryAsync<Pictures>(query);
            return pictures.ToList();
        }

		public List<Property> GetAllPropeties()
		{
			using var connection = _dbService.GetConnection();
			var query = @"SELECT * FROM ""properties""";

			var houses = connection.Query<Property>(query);  
			return houses.ToList();
		}


		public async Task<IEnumerable<Property>> GetPropertyById(int id)
        {
            using var connection = _dbService.GetConnection();

            var query = @"SELECT *
                  FROM ""properties""
                  WHERE ""id"" = @Id";

            var properties = await connection.QueryAsync<Property>(query, new { Id = id });
            return properties;
        }

        public async Task<List<User>> GetUsers()
        {
            using var connection = _dbService.GetConnection();

            var query = @"SELECT *
                  FROM ""users""";

            var users = await connection.QueryAsync<User>(query);
            return users.ToList();
        }

    }
}
