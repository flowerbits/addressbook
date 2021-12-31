using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;
using AddressbookServer.Models;

namespace AddressbookServer.Data
{
    public class BaseProvider<T>: IBaseProvider<T> where T : class,IBaseModel
    {
        protected DataContext dataContext;
        protected ILogger logger;
        protected IHttpContextAccessor contextAccessor;

        public BaseProvider(DataContext context, ILoggerFactory loggerFactory)
        {
            dataContext = context;
            logger = loggerFactory.CreateLogger(typeof(T).Name + "Provider");
        }

        public virtual IQueryable<T> GetAll(bool withChildren = false)
        {
            return dataContext.GetDbSet<T>();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            try
            {
                return dataContext.GetDbSet<T>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error loading " + typeof(T).Name + ":" + e);
                return null;
            }

        }
        public virtual async Task<bool> DeleteById(string id)
        {
            if (Guid.TryParse(id, out Guid guidId))
                return await DeleteById(guidId);
            return false;
        }

        public virtual async Task<bool> DeleteById(Guid id) {
            var toDel = await GetById(id);
            if (toDel == null) return false;

            return await Delete(toDel);
        }
        public virtual async Task<bool> Delete(T toDel)
        {
            dataContext.GetDbSet<T>().Remove(toDel);
            await dataContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task Add(T info)
        {
            dataContext.GetDbSet<T>().Add(info);
            await dataContext.SaveChangesAsync();
        }
        public virtual async Task Update(T info)
        {
            dataContext.GetDbSet<T>().Update(info);
            await dataContext.SaveChangesAsync();
        }
    }
}
