using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class FM_BizTenant
    {
        public string  F_Account { get; set; }
        public string RealName { get; set; }
        public Sex F_Sex { get; set; }
        public string F_MobilePhone { get; set; }
        public string F_BizTenantPassword { get; set; }
        public string F_BizTenantSecretkey { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
}
