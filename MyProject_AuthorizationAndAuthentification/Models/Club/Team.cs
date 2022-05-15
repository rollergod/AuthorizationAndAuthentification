using System;

namespace MyProject_AuthorizationAndAuthentification.Models.Club
{
    public partial class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Uri CrestUrl { get; set; }
    }
}
