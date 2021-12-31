using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressbookServer.Models;


namespace AddressbookServer.Data
{
    public interface IBaseProvider<T> where T : IBaseModel
    {
        Task<T> GetById(Guid id);
        IQueryable<T> GetAll(bool withChildren = false);
        Task Update(T info);
        Task<bool> DeleteById(Guid id);
        Task<bool> DeleteById(string id);
        Task Add(T info);
    }
}
