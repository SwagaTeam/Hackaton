using Domain;
using Domain.Entities;
using Infrastructure.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        public UserRepository(AppDbContext context)
        {
            this.context = context; 
        }

        public async Task<int> Create(UserEntity user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> Update(UserEntity user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<UserEntity> GetUser(int userId)
        {
            return await context.Users.FindAsync(userId);
        }

        public async Task<UserEntity?> GetUserByLogin(string login)
        {
            return context.Users.FirstOrDefault(x => x.Login == login);
        }

        public async Task<List<UserEntity>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }
    }
}
