using System;

namespace MyProject.Domain.Club
{
    public partial class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Uri CrestUrl { get; set; }
    }
}
