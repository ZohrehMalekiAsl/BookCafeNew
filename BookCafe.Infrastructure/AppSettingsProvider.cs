using BookCafe.Application.Interfaces.Infra;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Infrastructure
{
    public class AppSettingsProvider : IAppSetting
    {
        private readonly IOptionsMonitor<AppSetting> _optionsMonitor;

        public AppSettingsProvider(IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor;
        }
        public string ConnectionStrings => _optionsMonitor.CurrentValue.ConnectionStrings;

        public string SecretKey => _optionsMonitor.CurrentValue.SecretKey;

        public string Issuer => _optionsMonitor.CurrentValue.Issuer;

        public string Audience => _optionsMonitor.CurrentValue.Audience;
    }
}
