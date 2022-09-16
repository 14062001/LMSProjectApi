using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSProjectApi.Models
{
    public class ManagerModel
    {
        [Key]
        public int Manager_Id { get; set; }
        [Required]
        public string Manager_Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Manager_Email { get; set; }
        [Required]
        public int Manager_Mobileno { get; set; }
        [Required]
        public string Manager_Address{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Manager_Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Manager_Password")]
        public string Manager_Repassword { get; set; }
        [ForeignKey("EmployeeModel")]
        [Display(Name = "Emp_Id")]
        public int Emp_id { get; set; }
        [Display(Name = "Department_id")]
      public virtual EmployeeModel Employee { get; set; }

    }
}
