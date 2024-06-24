using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.Server.Models
{
    [Table(name:"user_detail", Schema="main")]
  
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("user_name")]
        public string? UserName { get; set; }= string.Empty;

        public required ICollection<Entry> Entries { get; set; }

        //[Column("password")]
        //public string? Password { get; set; }

    }
}
