﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertDatabaseCL.Entities
{
    public class Client
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }

        public string Hash { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
