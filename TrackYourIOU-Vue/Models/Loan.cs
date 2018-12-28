
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackYourIOU.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        
        // ADD PROPERTIES HERE
        public double LoanAmount { get; set; }
        public string NameOfBorrower { get; set; }
        public DateTime LoanedDate { get; set; }

        public DateTime? RepaymentDate { get; set; }

        [NotMapped]
        public bool IsLoanRepaid {
            get {
                return RepaymentDate != null;
            }
        }
    }
}
            