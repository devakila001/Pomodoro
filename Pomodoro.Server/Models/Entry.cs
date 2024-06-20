using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.Server.Models
{
    [Table("entry")]
    public class Entry
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("entry_name")]
        public string? Name { get; set; }

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
                
    }
}
