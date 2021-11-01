using System.Collections.Generic;
using ASP.NETCoreWebApplication.Entities;

namespace ASP.NETCoreWebApplication.Models
{
    public class MedarbejderModel
    {
        public int MedarbejderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        
        public virtual ICollection<Vagt> Vagter { get; set; }

    }
}