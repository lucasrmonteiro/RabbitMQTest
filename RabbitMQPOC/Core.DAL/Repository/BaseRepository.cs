using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        private ConnectionMultiplexer _redis;
        private IDatabase _db;

        public BaseRepository(IConfiguration configuration)
        {
            _redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
            _db = _redis.GetDatabase();
        }

        public void AddData(TEntity entity)
        {
            string value = JsonConvert.SerializeObject(entity);
            _db.StringSet(typeof(TEntity).Name, value);
        }

        public TEntity SelectData(TEntity entity)
        {
            var str = _db.StringGet(typeof(TEntity).Name);

            return JsonConvert.DeserializeObject<TEntity>(str);
        }
    }
}
