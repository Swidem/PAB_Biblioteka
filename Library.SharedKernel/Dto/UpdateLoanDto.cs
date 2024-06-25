﻿using Library.Domain.Models;

namespace Library.SharedKernel.Dto
{
    public class UpdateLoanDto
    {
        public int LoanId { get; set; }
        public int ClientId { get; set; }
        public int BookId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public LoanStatus LoanStatus { get; set; }
    }
}
