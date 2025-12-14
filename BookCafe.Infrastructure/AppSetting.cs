using BookCafe.Application.Interfaces.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Infrastructure
{
    public class AppSetting : IAppSetting
    {
        public string ConnectionStrings {  get; set; }

        public string SecretKey {  get; set; }

        public string Issuer {  get; set; }

        public string Audience {  get; set; }
    }
}
