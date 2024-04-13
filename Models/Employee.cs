using GymSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymSystem.Models



{//Auto-properies
    public class EmployeeGYM
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "You must Full name.")]
        [MinLength(8, ErrorMessage = "Full name mustn't be less than 8 characters.")]
        [MaxLength(30, ErrorMessage = "Full name mustn't be biggerthan  30 characters.")]
        public string FullName { get; set; }

        [DisplayName("Job")]
        [Required(ErrorMessage = "You must Full Job.")]
        [MinLength(2, ErrorMessage = "Position mustn't be less than 2  characters.")]
        [MaxLength(20, ErrorMessage = "Position mustn't be biggerthan  20 characters.")]

        public string Position { get; set; }

        [Range(5000, 50000, ErrorMessage = "Salary must be betweem 5000 and 50000 EGP.")]
        public decimal Salary { get; set; }

        [Range(0, 100, ErrorMessage = "Appraisl must be between 0 and 100 ")]
        public byte Appraisal { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public DateTime JoinDateTime { get; set; }


        [DataType(DataType.Time)]
        public DateTime AttendanceTime { get; set; }


        [DataType(DataType.Time)]
        public DateTime StartDateTime { get; set; }

        [DisplayName("National Number")]
        [RegularExpression("^[0-9]{14}$", ErrorMessage = "Invalid national number. ")]
        public string NationalNumber { get; set; }

        [RegularExpression("^01\\d{9}$", ErrorMessage = "Invalid Phone number. ")]
        public string PhoneNumber { get; set; }

        //[DataType(DataType.Password)]
        public string SecretCode { get; set; }

        [NotMapped]
        [Compare("SecretCode", ErrorMessage = "Secret code and confirm secret code donot match,")]
        // [DataType (DataType.Password)]
        public string ConfirmSecretCode { get; set; }


        public bool IsActive { get; set; }

        [DisplayName("Department")]
        [Range(1, int.MaxValue, ErrorMessage = "Select a department.")]
        public int DepartmentId { get; set; }

        //Navigation Property
        [ValidateNever]
        public Department Department { get; set; }
    }
}
