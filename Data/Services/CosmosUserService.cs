using Microsoft.Azure.Cosmos;
using System.Net;
using AutoMapper;
using CrushApp.Data.DTOs;
using AppUser = CrushApp.Data.Models.User;

namespace CrushApp.Data.Services
{
    public class CosmosUserService : IUserService
    {
        private readonly Container _container;
        private readonly IMapper _mapper;

        public CosmosUserService(CosmosClient cosmosClient, IMapper mapper)
        {
            var database = cosmosClient.GetDatabase("CrushAppDb");
            _container = database.GetContainer("Users");
            _mapper = mapper;
        }

        public async Task<UserReadDto?> GetUserByIdAsync(int id)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.NumericId = @id")
                .WithParameter("@id", id);

            var iterator = _container.GetItemQueryIterator<AppUser>(query);
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                var user = response.FirstOrDefault();
                return user == null ? null : _mapper.Map<UserReadDto>(user);
            }

            return null;
        }

        public async Task<bool> UpdateUserAsync(int id, UserUpdateDto dto)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.NumericId = @id")
                .WithParameter("@id", id);

            var iterator = _container.GetItemQueryIterator<AppUser>(query);
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                var user = response.FirstOrDefault();
                if (user != null)
                {
                    // Apply updates
                    _mapper.Map(dto, user); // Map values onto the existing user
                    await _container.ReplaceItemAsync(user, user.Id, new PartitionKey(user.Id));
                    return true;
                }
            }

            return false;
        }

        public async Task<UserReadDto?> RegisterUserAsync(UserCreateDto dto)
        {
            var user = _mapper.Map<AppUser>(dto);
            user.Id = Guid.NewGuid().ToString();
            user.CreatedAt = DateTime.UtcNow;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            user.NumericId = new Random().Next(1000, 9999); // Simple demo ID

            await _container.CreateItemAsync(user, new PartitionKey(user.Id));

            return _mapper.Map<UserReadDto>(user);
        }
        

        public async Task<AppUser?> GetUserByUsernameAsync(string username)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.Username = @username")
                .WithParameter("@username", username);

            var iterator = _container.GetItemQueryIterator<AppUser>(query);
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                return response.FirstOrDefault();
            }

            return null;
        }









    }
}
