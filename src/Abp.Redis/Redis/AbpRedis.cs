using Abp.Dependency;
using Abp.Redis.Configuration;
using StackExchange.Redis;
using Abp.Redis.Impl;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Abp.Redis
{
    public class AbpRedis : IAbpRedis, ISingletonDependency
    {
        private readonly IAbpRedisModuleConfiguration _configuration;
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public IDatabase Database
        {
            get
            {
                return _connectionMultiplexer.GetDatabase();
            }
        }

        public string Name { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AbpRedis(
            IAbpRedisConnectionProvider redisConnectionProvider, 
            IAbpRedisModuleConfiguration configuration)
        {
            _configuration = configuration;
            var connectionString = redisConnectionProvider.GetConnectionString(_configuration.ConnectionNameOrString);
            _connectionMultiplexer = redisConnectionProvider.GetConnection(connectionString);
            Name = string.Empty;
        }

        public object GetOrDefault(string key)
        {
            var objbyte = Database.StringGet(GetLocalizedKey(key));
            return objbyte.HasValue
                ? JsonConvert.DeserializeObject(objbyte)
                : null;
        }

        public void Set(string key, object value, TimeSpan? slidingExpireTime = null)
        {
            if (value == null)
            {
                throw new AbpException("Can not insert null values to the redis!");
            }

            Database.StringSet(
                GetLocalizedKey(key),
                JsonConvert.SerializeObject(value),
                slidingExpireTime
                );
        }

        public void Remove(string key)
        {
            Database.KeyDelete(GetLocalizedKey(key));
        }

        public void Clear()
        {
            Database.KeyDeleteWithPrefix(GetLocalizedKey("*"));
        }

        public void RPush(string key, object value)
        {
            if (value == null)
            {
                throw new AbpException("Can not insert null values to the redis!");
            }
            Database.ListRightPush(
                GetLocalizedKey(key),
                JsonConvert.SerializeObject(value)
                );
        }

        public async Task RPushAsync(string key, object value)
        {
            if (value == null)
            {
                throw new AbpException("Can not insert null values to the redis!");
            }
            await Database.ListRightPushAsync(
                GetLocalizedKey(key),
                JsonConvert.SerializeObject(value)
                );
        }

        public object LPop(string key)
        {
            var objbyte = Database.ListLeftPop(GetLocalizedKey(key));
            return objbyte.HasValue
                ? JsonConvert.DeserializeObject(objbyte)
                : null;
        }

        public async Task<object> LPopAsync(string key)
        {
            var objbyte = await Database.ListLeftPopAsync(GetLocalizedKey(key));
            return objbyte.HasValue
                ? JsonConvert.DeserializeObject(objbyte)
                : null;
        }

        public void ZAdd(string key, double score, object value)
        {
            if (value == null)
            {
                throw new AbpException("Can not insert null values to the redis!");
            }
            Database.SortedSetAdd(
                GetLocalizedKey(key),
                new SortedSetEntry[] {
                     new SortedSetEntry(
                         JsonConvert.SerializeObject(value),
                         score
                         )
                }
                );
        }

        public async Task ZAddAsync(string key, double score, object value)
        {
            if (value == null)
            {
                throw new AbpException("Can not insert null values to the redis!");
            }
            await Database.SortedSetAddAsync(
                GetLocalizedKey(key),
                new SortedSetEntry[] {
                     new SortedSetEntry(
                         JsonConvert.SerializeObject(value),
                         score
                         )
                }
                );
        }

        public List<object> ZRangeByScore(string key, double start = -1.0/0.0, double stop = 1.0/0.0)
        {
            var objbytes = Database.SortedSetRangeByScore(GetLocalizedKey(key), start, stop);
            if (objbytes.Length == 0) return null;
            var retval = new List<object>();
            foreach (var objbyte in objbytes)
            {
                if (objbyte.HasValue)
                {
                    retval.Add(JsonConvert.DeserializeObject(objbyte));
                }
            }
            return retval;
        }

        public async Task<List<object>> ZRangeByScoreAsync(string key, double start = -1.0/0.0, double stop = 1.0/0.0)
        {
            var objbytes = await Database.SortedSetRangeByScoreAsync(GetLocalizedKey(key), start, stop);
            if (objbytes.Length == 0) return null;
            var retval = new List<object>();
            foreach (var objbyte in objbytes)
            {
                if (objbyte.HasValue)
                {
                    retval.Add(JsonConvert.DeserializeObject(objbyte));
                }
            }
            return retval;
        }

        public void ZRem(string key, object value)
        {
            Database.SortedSetRemove(GetLocalizedKey(key), JsonConvert.SerializeObject(value));
        }

        public async Task ZRemAsync(string key, object value)
        {
            await Database.SortedSetRemoveAsync(GetLocalizedKey(key), JsonConvert.SerializeObject(value));
        }

        private string GetLocalizedKey(string key)
        {
            return string.Format("n:{0},k:{1}", Name, key);
        }
    }
}
