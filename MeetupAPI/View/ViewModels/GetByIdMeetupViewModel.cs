using MeetupAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.View.ViewModels
{
    public class GetByIdMeetupViewModel
    {
        [Required, StringLength(20, MinimumLength =5)]
        public string Title { get; set; } = null!;

        [Required, StringLength(40, MinimumLength = 5)]
        public string Topic { get; set; } = null!;

        [Required, StringLength(100, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        public string DateTime { get; set; } = null!;

        public AddressViewModel Address { get; set; } = null!;

        [Required]
        public List<string> Plan { get; set; } = null!;

        public List<PersonViewModel> Organizers { get; set; } = null!;

        public List<PersonViewModel> Speakers { get; set; } = null!;
    }
}
