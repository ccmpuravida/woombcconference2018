using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC18.Models
{
    [Table("Registration")]
    public class Registration
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "IdTypeRequired")]
        public int IdType { get; set; }

        [Required(ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "IdNumberRequired")]
        [StringLength(20, MinimumLength = 5, ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "IdNumberStringLength")]
        public string IdNumber { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "NameRequired")]
        [StringLength(64, MinimumLength = 2, ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "NameStringLength")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "EmailAddressFormat")]
        [Required(ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "EmailRequired")]
        [StringLength(32, MinimumLength = 5, ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "EmailStringLength")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "CountryRequired")]
        [StringLength(16, MinimumLength = 2, ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "CountryStringLength")]
        public string Country { get; set; }

        [Phone(ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "PhoneFormat")]
        [Required(ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "PhoneRequired")]
        [StringLength(16, MinimumLength = 8, ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "PhoneStringLength")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required]
        public bool IsInstructor { get; set; }

        [Required]
        public bool IsUser { get; set; }

        [Required]
        public bool IsHealth { get; set; }

        [Required]
        public bool ToConference { get; set; }

        [Required]
        public bool ToTraining { get; set; }

        [Required]
        public bool ToDinner { get; set; }

        [Required]
        public bool ToTour { get; set; }

        [Required]
        public bool ToHost { get; set; }

        [Range(1, 15, ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "ToHostDaysRange")]
        public int? ToHostDays { get; set; }

        [StringLength(1024, MinimumLength = 3, ErrorMessageResourceType = typeof(MainResources), ErrorMessageResourceName = "CommentsStringLength")]
        public string Comments { get; set; }
    }
}