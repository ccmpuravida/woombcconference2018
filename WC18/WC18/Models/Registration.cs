using System.ComponentModel.DataAnnotations;

namespace WC18.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(MainResources),
            ErrorMessageResourceName = "IdTypeRequired")]
        public int IdType { get; set; }

        [Required(ErrorMessageResourceType = typeof(MainResources),
    ErrorMessageResourceName = "IdNumberRequired")]
        [StringLength(20, ErrorMessageResourceType = typeof(MainResources),
    ErrorMessageResourceName = "IdNumberStringLength", MinimumLength = 5)]
        public string IdNumber { get; set; }

        public string Name { get; set; }

        [EmailAddress()]
        public string Email { get; set; }

        public string Country { get; set; }

        public string Telephone { get; set; }

        public string IsInstructor { get; set; }

        public string IsUser { get; set; }

        public string IsHealth { get; set; }

        public string ToConference { get; set; }

        public string ToTraining { get; set; }

        public string ToDinning { get; set; }

        public string ToTour { get; set; }

        public string ToHost { get; set; }

        [Range(1, 15)]
        public int ToHostDays { get; set; }

        public string Comments { get; set; }
    }
}