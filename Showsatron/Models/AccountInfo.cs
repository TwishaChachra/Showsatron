using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Showsatron.Models
{
    public class AccountInfo
    {
        public int AccountInfoId { get; set; }
        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal SubscriptionPrice { get; set; }
        public int PlatformId { get; set; }
      
        public Platform Platform { get; set; }

    }
}
//The values of subscription prices were taken from: https://techdaily.ca/streaming-services-canada/