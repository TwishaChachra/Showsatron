using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Showsatron.Models
{
    public class AccountInfo
    {
        public int AccountInfoId { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
