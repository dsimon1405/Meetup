using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.View.ViewModels
{
    public class AddressViewModel
    {
        [Required, StringLength(15)]
        public string City { get; set; } = null!;

        [Required, StringLength(15)]
        public string Street { get; set; } = null!;

        [Required, Range(1, 1000)]
        public int House { get; set; }
    }
}