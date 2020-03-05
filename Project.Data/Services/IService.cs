using System;

namespace Project.Data.Services
{
  public interface IService<T>
  {
    bool Exist(Func<T, bool> func);

    void Add(T elem);
  }
}
