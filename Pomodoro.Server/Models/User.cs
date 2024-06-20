using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.Server.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int Id { get; set; }

        [Column("user_name")]
        public string? UserName { get; set; }

        [Column("password")]
        public string? Password { get; set; }

    }
}
