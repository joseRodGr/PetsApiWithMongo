using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Data
{
    public interface IPetStoreDataSettings
    {
        string Database { get; set; }
        string ConnectionString { get; set; }
        string Collection { get; set; }

    }
}
