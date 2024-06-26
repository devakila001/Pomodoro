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
        
        [Column("entry_date")]
        public DateTime EntryDate { get; set; }

        [Column("start_time")]
        public string StartTime { get; set; } = string.Empty;

        [Column("end_time")]
        public string EndTime { get; set;} = string.Empty;

        [Column("total_time")]
        public string TotalTime { get; set; } = string.Empty;

        [Column("comments")]
        public string Comments { get; set; } = string.Empty;
       

        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("user_name")]
        public string UserName { get; set; } = string.Empty;
    }
}
