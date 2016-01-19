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
        ISubscriber Subscriber { get; }
        string Name { get; set; }

        object GetOrDefault(string key);
        void Set(string key, object value, TimeSpan? slidingExpireTime = null);
        void Remove(string key);
        void Clear();
        void RPush(string key, object value, CommandFlags flags = CommandFlags.None);
        Task RPushAsync(string key, object value, CommandFlags flags = CommandFlags.None);
        object LPop(string key, CommandFlags flags = CommandFlags.None);
        Task<object> LPopAsync(string key, CommandFlags flags = CommandFlags.None);
        void ZAdd(string key, double score, object value, CommandFlags flags = CommandFlags.None);
        Task ZAddAsync(string key, double score, object value, CommandFlags flags = CommandFlags.None);
        List<object> ZRangeByScore(string key, double start = -1.0/0.0, double stop = 1.0/0.0, CommandFlags flags = CommandFlags.None);
        Task<List<object>> ZRangeByScoreAsync(string key, double start = -1.0/0.0, double stop = 1.0/0.0, CommandFlags flags = CommandFlags.None);
        void ZRem(string key, object value, CommandFlags flags = CommandFlags.None);
        Task ZRemAsync(string key, object value, CommandFlags flags = CommandFlags.None);
        void Subscribe(string channel, Action<RedisChannel, RedisValue> handler, CommandFlags flags = CommandFlags.None);
        Task SubscribeAsync(string channel, Action<RedisChannel, RedisValue> handler, CommandFlags flags = CommandFlags.None);
        void Publish(string channel, object message, CommandFlags flags = CommandFlags.None);
        Task PublishAsync(string channel, object message, CommandFlags flags = CommandFlags.None);
    }
}
