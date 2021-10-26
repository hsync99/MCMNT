using System;
using System.Collections.Generic;
using System.Text;
using Realms;
namespace MCMNT.Models
{
    public class MyCash:RealmObject
    {
     
        public string id { get; set; }
        public double Cash { get; set; }
        public double CashLost { get; set; }


       
        public MyCash()
        {
            id = "1";
        }

    }
    
}
