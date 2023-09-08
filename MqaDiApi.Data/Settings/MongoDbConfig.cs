using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MqaDiApi.Data.Settings
{
    public class MongoDbConfig
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string MqadiCollectionName { get; set; } = null;

        public string Host { get; set; }
        public string Port { get; set; }

        public string LocalConnectionString => $"mongodb://{Host}:{Port}";
    }
}
