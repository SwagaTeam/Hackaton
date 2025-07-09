using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IUserService
    {
        public Task<int> Create(RegisterModel model);
        public Task<UserModel> GetUser(int userId);
        public Task<List<UserEntity>> GetUsers();
        public Task<int> Update(UserEntity user);
        Task<UserModel> ValidateCredentials(string login, string password);
    }
}
