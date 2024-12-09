using Dapper;
using Domain.Models.DB;
using Domain.Models.Models;
using Microsoft.Extensions.Logging;

namespace Domain.Models.Service
{
    // Implement the IBoligService interface
    public class BoligService : IBoligService
    {
        // Inject the DBService and ILogger
        private readonly DBService _dbService;
        private readonly ILogger<BoligService> _logger;


        // Constructor to inject the DBService and ILogger
        public BoligService(DBService dbService, ILogger<BoligService> logger)
        {
            // Assign the injected services to the private fields
            _dbService = dbService;
            _logger = logger;
        }

        // Asynchronous method to get all pictures
        public async Task<List<Pictures>> GetAllPictures()
        {
            using var connection = _dbService.GetConnection();
            var query = @"SELECT *
						FROM ""pictures"" ";

            var pictures = await connection.QueryAsync<Pictures>(query);
            return pictures.ToList();
        }

        // Asynchronous method to get all properties
        public List<Property> GetAllPropeties()
        {
            using var connection = _dbService.GetConnection();
            var query = @"SELECT * FROM ""properties""";

            var houses = connection.Query<Property>(query);
            return houses.ToList();
        }

        // Asynchronous method to get a property by ID
        public async Task<IEnumerable<Property>> GetPropertyById(int id)
        {
            using var connection = _dbService.GetConnection();

            var query = @"SELECT *
                  FROM ""properties""
                  WHERE ""id"" = @Id";

            var properties = await connection.QueryAsync<Property>(query, new { Id = id });
            return properties;
        }

        // New method to get all users
        public async Task<List<User>> GetUsers()
        {
            using var connection = _dbService.GetConnection();

            var query = @"SELECT *
                  FROM ""users""";

            var users = await connection.QueryAsync<User>(query);
            return users.ToList();
        }

        // New method to create a property with pictures
        public async Task<int> CreateAnnonceWithPicturesAsync(Property property, List<string> pictureLinks)
        {
            // Query to insert a property
            const string insertPropertyQuery = @"INSERT INTO Properties (Title, Year, Price, SquareMeters, Location, Description, OwnerId, TypeId, CreatedAt, UpdatedAt, HasGarden, NumberOfFloors, HasGarage, Floor, RoomsCount, HasBalcony, HasElevator, IsSeasonal, DistanceToBeach, HasPrivatePool) 
                VALUES (@Title, @Year, @Price, @SquareMeters, @Location, @Description, @OwnerId, @TypeId, @CreatedAt, @UpdatedAt, @HasGarden, @NumberOfFloors, @HasGarage, @Floor, @RoomsCount, @HasBalcony, @HasElevator, @IsSeasonal, @DistanceToBeach, @HasPrivatePool) 
                RETURNING Id";

            try 
            {
                using var connection = _dbService.GetConnection();

                // Insert the property and get the generated Id
                var propertyId = await connection.ExecuteScalarAsync<int>(insertPropertyQuery, property);

                // Insert the pictures for the newly created property
                const string insertPictureQuery = @"INSERT INTO Pictures (PropertyId, PictureLink, CreatedAt) 
                                                  VALUES (@PropertyId, @PictureLink, @CreatedAt)";

                // Loop through each picture link and insert it for the property
                foreach (var pictureLink in pictureLinks)
                {
                    await connection.ExecuteAsync(insertPictureQuery, new
                    {
                        // Assign the propertyId, picture link, and the current date
                        PropertyId = propertyId,
                        PictureLink = pictureLink,
                        CreatedAt = DateTime.UtcNow
                    });
                }
                _logger.LogInformation("Property with pictures created successfully. PropertyId: {PropertyId}", propertyId);
                return propertyId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating property with pictures");
                throw;
            }
        }
    }
}
