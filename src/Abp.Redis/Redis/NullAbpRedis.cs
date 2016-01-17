using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Redis
{
    public class NullAbpRedis : IAbpRedis
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static NullAbpRedis Instance { get { return SingletonInstance; } }
        private static readonly NullAbpRedis SingletonInstance = new NullAbpRedis();

        public IDatabase Database { get { return null; } }
        public string Name { get { return string.Empty; } set { this.Name = value; } }


        public object GetOrDefault(string key)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object value, TimeSpan? slidingExpireTime = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void RPush(string key, object value)
        {
            throw new NotImplementedException();
        }

        public Task RPushAsync(string key, object value)
        {
            throw new NotImplementedException();
        }

        public object LPop(string key)
        {
            throw new NotImplementedException();
        }

        public Task<object> LPopAsync(string key)
        {
            throw new NotImplementedException();
        }


        public void ZAdd(string key, double score, object value)
        {
            throw new NotImplementedException();
        }

        public Task ZAddAsync(string key, double score, object value)
        {
            throw new NotImplementedException();
        }

        public List<object> ZRangeByScore(string key, double start = -1.0/0.0, double stop = 1.0/0.0)
        {
            throw new NotImplementedException();
        }

        public Task<List<object>> ZRangeByScoreAsync(string key, double start = -1.0/0.0, double stop = 1.0/0.0)
        {
            throw new NotImplementedException();
        }
    }
}
