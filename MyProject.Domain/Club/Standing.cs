using System.Collections.Generic;

namespace MyProject.Domain.Club
{
    public partial class Standing
    {
        public string Stage { get; set; }
        public string Type { get; set; }
        public object Group { get; set; }
        public List<Table> Table { get; set; }
    }
}
