using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreRelations.Data.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
