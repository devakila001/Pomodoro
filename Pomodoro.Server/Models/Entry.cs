using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.Server.Models
{

    [Table(name: "entry_info", Schema = "main")]
    public class Entry
    {
        [Key]
        [Column("entry_id")]
        public int EntryId { get; set; }
        [Column("entry_name")]
        public string? EntryName { get; set; }

        [Column("entry_date")]
        public string? Date { get; set; }

        [Column("start_time")]
        public string? StartTime { get; set; }

        [Column("end_time")]
        public string? EndTime { get; set;}
        [Column("comments")]
        public string? Comments { get; set; }
        [Column("total_time")]
        public string? TotalTime { get; set; }

        [ForeignKey("user")]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("user_name")]
        public string? UserName { get; set; }
    }
}
