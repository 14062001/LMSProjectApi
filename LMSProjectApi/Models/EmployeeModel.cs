using System;
using System.ComponentModel.DataAnnotations;

namespace LMSProjectApi.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Emp_Id { get; set; }
        [Required]
        public string Emp_Name { get; set; }
        [Required]
        public string Emp_Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Emp_Email { get; set; }
        [Required]
        public int Emp_Mobileno { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Emp_Doj { get; set; }
        [Required]
        public string Emp_Dept { get; set; }
        [Required]
        public int Avail_Leave_Bal { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Emp_Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Emp_Password")]
        public string Emp_Repassword { get; set; }
    }
}
