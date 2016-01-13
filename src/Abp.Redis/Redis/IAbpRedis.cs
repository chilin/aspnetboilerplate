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
    }
}
