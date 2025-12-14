using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Interfaces.Infra
{
    public interface IAppSetting
    {
        string ConnectionStrings { get; }
        string SecretKey { get; }
        string Issuer { get; }
        string Audience { get; }
    }
}
