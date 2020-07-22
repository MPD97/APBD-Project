using System.Collections.Generic;

namespace Advert.Database.Entities
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

        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}