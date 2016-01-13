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
    }
}
