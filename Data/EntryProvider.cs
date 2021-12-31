using AddressbookServer.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AddressbookServer.Data
{
    public class EntryProvider : BaseProvider<EntryModel>
    {
        public EntryProvider(DataContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
