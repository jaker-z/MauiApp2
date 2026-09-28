using SQLite;

namespace MauiApp2
{
    [Table("character")]
    public class Character
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("character_name")]
        public string CharacterName { get; set; }
        [Column("mobile")]
        public string Mobile {  get; set; }
        [Column("email")]
        public string Email { get; set; }

    }
}
