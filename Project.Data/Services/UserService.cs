using System;
using System.Collections.Generic;
using System.Linq;
using Project.Data.Models;

namespace Project.Data.Services
{
  public class UserService
  {
    private List<User> users;

    public UserService()
    {
      using (EFContext context = new EFContext())
        users = context.Users.ToList();
    }

    public List<User> GetAll() { return users; }

    public bool Exists(Func<User, bool> func)
    {
      foreach (var item in users)
        if (func(item)) return true;
      return false;
    }

    public void Add(User user)
    {
      using (EFContext context = new EFContext())
      {
        context.Users.Add(user);
        context.SaveChanges();
        users = context.Users.ToList();
      }
    }
  }
}