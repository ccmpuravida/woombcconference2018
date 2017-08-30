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

        [Required]
        public string Name { get; set; }

        [EmailAddress()]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        public bool IsInstructor { get; set; }

        public bool IsUser { get; set; }

        public bool IsHealth { get; set; }

        public bool ToConference { get; set; }

        public bool ToTraining { get; set; }

        public bool ToDinner { get; set; }

        public bool ToTour { get; set; }

        public bool ToHost { get; set; }

        [Range(1, 15)]
        public int ToHostDays { get; set; }

        public string Comments { get; set; }
    }
}