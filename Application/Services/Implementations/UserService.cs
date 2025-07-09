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
using Application.Validation;
using FluentValidation;

namespace Application.Services.Implementations
{
    public class UserService(IUserRepository userRepository, IAuth auth, IEncrypt encrypt) : IUserService
    {

        public async Task<int> Create(RegisterModel model)
        {
            if (model.Password != model.RepeatPassword)
                throw new Exception("Пароли не совпадают");
            var validator = new UserValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new ArgumentException(
                    string.Join("; ", result.Errors.Select(e => e.ErrorMessage))
                );
            }
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
            var userModel = new UserModel(userEntity);
            return userModel;
        }

        public async Task<List<UserEntity>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        public async Task<UserModel?> ValidateCredentials(string login, string password)
        {
            var userEntity = await userRepository.GetUserByLogin(login);
            if (userEntity is null)
                return null;
            return new UserModel(userEntity);
        }
    }
}
