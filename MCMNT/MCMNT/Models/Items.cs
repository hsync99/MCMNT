using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace MCMNT.Models
{
   public class Items:RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }
        public double Summ { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        
       
    }
}
