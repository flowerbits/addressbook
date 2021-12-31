using AddressbookServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AddressbookServer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<EntryModel> Entries { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            var getter = typeof(DataContext)
                .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .First(x => x.PropertyType == typeof(DbSet<T>));
            return (DbSet<T>)getter.GetValue(this);

        }
    }
}
