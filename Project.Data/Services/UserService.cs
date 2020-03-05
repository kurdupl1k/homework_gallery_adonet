﻿using System;
using System.Linq;
using Project.Data.Models;

namespace Project.Data.Services
{
  public class UserService : IService<User>
  {
    public UserService() { }

    public bool Exist(Func<User, bool> func)
    {
      using (EFContext context = new EFContext())
        return context.Users.Any(func);
    }

    public void Add(User user)
    {
      using (EFContext context = new EFContext())
      {
        context.Users.Add(user);
        context.SaveChanges();
      }
    }
  }
}