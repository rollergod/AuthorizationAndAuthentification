namespace MyProject.Domain.Club
{
    public partial class Table
    {
        public long Position { get; set; }
        public Team Team { get; set; }
        public long PlayedGames { get; set; }
        public object Form { get; set; }
        public long Won { get; set; }
        public long Draw { get; set; }
        public long Lost { get; set; }
        public long Points { get; set; }
        public long GoalsFor { get; set; }
        public long GoalsAgainst { get; set; }
        public long GoalDifference { get; set; }
    }
}
