using SQLite;

namespace ScarletDairy.Core.Repository
{
    public class Notes
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public string Location { get; set; }
        public string AudioPath { get; set; }
    }
}