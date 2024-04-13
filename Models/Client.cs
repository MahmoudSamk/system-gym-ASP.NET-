using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GymSystem.Models
{
    public class Client
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "You must Full name.")]
        [MinLength(8, ErrorMessage = "Full name mustn't be less than 8 characters.")]
        [MaxLength(30, ErrorMessage = "Full name mustn't be biggerthan  30 characters.")]
        public string FullName { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public DateTime JoinDateTime { get; set; }//////////////////////////////////
        public DateTime SubscriptionEndDate { get; set; }


        [DisplayName("National Number")]
        [RegularExpression("^[0-9]{14}$", ErrorMessage = "Invalid national number. ")]
        public string NationalNumber { get; set; }

        [RegularExpression("^01\\d{9}$", ErrorMessage = "Invalid Phone number. ")]
        public string PhoneNumber { get; set; }




    }
}
