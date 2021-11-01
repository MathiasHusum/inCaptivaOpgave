using System;
using System.Collections.Generic;
using ASP.NETCoreWebApplication.Entities;

namespace ASP.NETCoreWebApplication.Models
{
    public class VagtModel
    {
        public int VagtId { get; set;}
        public  DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Medarbejder Medarbejder { get; set; }
        public virtual ICollection<Opgave> Opgaver { get; set; }
    }
}