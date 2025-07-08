using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Middleware
{
    public interface IBlacklistService
    {
        bool IsTokenBlacklisted(string token);
        void AddTokenToBlacklist(string token);
    }
}
