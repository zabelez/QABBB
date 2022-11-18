using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Games = new HashSet<Game>();
            PublisherEmployees = new HashSet<PublisherEmployee>();
        }

        public int IdPublisher { get; set; }
        public int IdCompany { get; set; }

        public virtual Company IdCompanyNavigation { get; set; } = null!;
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<PublisherEmployee> PublisherEmployees { get; set; }
    }
}
