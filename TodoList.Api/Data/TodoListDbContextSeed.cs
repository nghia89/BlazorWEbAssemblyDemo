using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TodoList.Api.Entities;
using BlazorWEbAssemblyDemo.Models.Enums;
using Task = TodoList.Api.Entities.Task;

namespace TodoList.Api.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public void SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    PhoneNumber = "032132131",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123$");
                context.Users.Add(user);
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same tasks 1",
                    CreatedDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open
                });
            }

            context.SaveChanges();
        }
    }
}
