using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetupAPI.Data.Models
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Item { get; set; } = null!;


        [ForeignKey("MeetupId")]
        public Meetup Meetup { get; set; } = null!;
        public int MeetupId { get; set; }
    }
}