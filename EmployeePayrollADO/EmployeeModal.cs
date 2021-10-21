using System;
using System.Collections.Generic;
using System.Text;


namespace EmployeePayrollADO
{
    class EmployeeModal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public float BasicPay { get; set; }
        public float Deduction { get; set; }
        public float TaxablePay { get; set; }
        public float IncomeTax { get; set; }
        public float NetPay { get; set; }
        public DateTime StartDate { get; set; }
    }
}
