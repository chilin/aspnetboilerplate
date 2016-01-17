using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Redis
{
    public interface IAbpRedis
    {
        IDatabase Database { get; }
        string Name { get; set; }

        object GetOrDefault(string key);
        void Set(string key, object value, TimeSpan? slidingExpireTime = null);
        void Remove(string key);
        void Clear();
        void RPush(string key, object value);
        Task RPushAsync(string key, object value);
        object LPop(string key);
        Task<object> LPopAsync(string key);
        void ZAdd(string key, double score, object value);
        Task ZAddAsync(string key, double score, object value);
        List<object> ZRangeByScore(string key, double start = -1.0/0.0, double stop = 1.0/0.0);
        Task<List<object>> ZRangeByScoreAsync(string key, double start = -1.0/0.0, double stop = 1.0/0.0);
    }
}
