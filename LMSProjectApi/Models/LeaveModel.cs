using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSProjectApi.Models
{
    public class LeaveModel
    {
        [Key]
        public int Leave_Id { get; set; }
        [Required]
        public int NoOfDays { get; set; }
        [Required]
        public DateTime Start_date { get; set; }
        [Required]
        public DateTime End_date { get; set; }
        [Required]
        public string Leave_Type { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Reason { get; set;}
        [DataType(DataType.DateTime)]
        public DateTime Applied_On { get; set; }
        public string Manager_Comment { get; set; }

        [ForeignKey("EmployeeModel")]
        [Display(Name = "Emp_Id")]
        public int Emp_id { get; set; }
        public EmployeeModel EmployeeModel { get; set; }

        [ForeignKey("ManagerModel")]
        [Display(Name = "Manager_Id")]
        public int Manager_id { get; set; }
        public ManagerModel ManagerModel { get; set; }
    }
}
