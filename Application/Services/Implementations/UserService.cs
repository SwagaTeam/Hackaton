using Application.Dto;
using Application.Services.Abstractions;
using Domain.Entities;
using Infrastructure.Repository.Abstractions;
using Infrastructure.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IAuth auth;
        private readonly IEncrypt encrypt;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<int> Create(RegisterModel model)
        {
            if (model.Password != model.RepeatPassword)
                throw new Exception("Пароли не совпадают");

            var salt = Guid.NewGuid().ToString();
            var user = new UserEntity()
            {
                Login = model.Login,
                Salt = salt,
                Password = encrypt.HashPassword(model.Password, salt),
                IsAdmin = false,
                CurrentLevelNumber = 0,
                FullName = ""
            };

            return await userRepository.Create(user);
        }

        public async Task<UserModel> GetUser(int userId)
        {
            var userEntity = await userRepository.GetUser(userId);
            var userModel = new UserModel()
            {
                IsAdmin = userEntity.IsAdmin,
                CurrentLevelNumber = userEntity.CurrentLevelNumber,
                Login = userEntity.Login,
                Password = userEntity.Password,
                FullName = userEntity.FullName,
                Salt = userEntity.Salt
            };
            return userModel;
        }

        public async Task<UserModel?> ValidateCredentials(string login, string password)
        {
            var userEntity = await userRepository.GetUserByLogin(login);
            if (userEntity is null)
                return null;
            return new UserModel()
            {
                IsAdmin = userEntity.IsAdmin,
                CurrentLevelNumber = userEntity.CurrentLevelNumber,
                Login = userEntity.Login,
                Password = userEntity.Password,
                FullName = userEntity.FullName,
                Salt = userEntity.Salt
            };
        }
    }
}
