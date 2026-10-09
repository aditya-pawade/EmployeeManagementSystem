using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem_CodeFirstApproach_.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string EmployeeName { get; set; }

        [StringLength(12)]
        [Display(Name = "Aadhaar Number")]
        public string EmployeeAadharId { get; set; }

        [StringLength(10)]
        [Display(Name = "PAN Number")]
        public string EmployeePancard { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeDesignation { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Department")]
        public string EmployeeDepatment { get; set; }

        [Range(0, 100000000)]
        public decimal EmployeeSalary { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string EmployeeEmail { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Contact Number")]
        public string EmployeeContact { get; set; }

        [StringLength(500)]
        public string EmployeeAddress { get; set; }

    }
}