using System;

namespace Project.Data.Services
{
  public interface IService<T>
  {
    bool Exists(Func<T, bool> func);
    T Find(Func<T, bool> func);
    void Add(T elem);
  }
}