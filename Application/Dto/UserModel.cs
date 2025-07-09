using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Dto
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsAdmin { get; set; }
        public int CurrentLevelNumber { get; set; }

        public UserModel(UserEntity entity)
        {
            FullName = entity.FullName;
            IsAdmin = entity.IsAdmin;
            Id = entity.Id;
            Login = entity.Login;
            Password = entity.Password;
            Salt = entity.Salt;
            CurrentLevelNumber = entity.CurrentLevelNumber;
        }
    }
}
