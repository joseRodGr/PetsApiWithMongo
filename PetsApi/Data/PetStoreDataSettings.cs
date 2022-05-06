using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Data
{
    public class PetStoreDataSettings : IPetStoreDataSettings
    {
        public string Database { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string Collection { get; set; } = string.Empty;
    }
}
