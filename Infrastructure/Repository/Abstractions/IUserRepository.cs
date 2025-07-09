using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Abstractions
{
    public interface IUserRepository
    {
        public Task<int> Create(UserEntity user);
        public Task<int> Update(UserEntity user);
        public Task<UserEntity> GetUser(int userId);
        public Task<List<UserEntity>> GetUsers();
        public Task<UserEntity?> GetUserByLogin(string login);
    }
}
