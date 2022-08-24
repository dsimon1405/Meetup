using MeetupAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.View.ViewModels
{
    public class PersonViewModel : IPerson
    {
        [Required, StringLength(15, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required, StringLength(15, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        [Required, StringLength(40, MinimumLength = 2)]
        public string OrganizationOrTopic { get; set; } = null!;
    }
}