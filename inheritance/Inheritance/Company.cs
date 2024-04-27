using System;
using System.Collections.Generic;
using System.Text;


namespace InheritanceTask
{
    
    public class Company
    {
        private Employee[] employees;
        public Company(Employee[] employees)
        {
            this.employees = employees;
        }
        public void GiveEverybodyBonus(decimal companyBonus)
        {
            foreach (Employee employee in employees)
            {
                employee.SetBonus(companyBonus);
            }
        }
        public decimal TotalToPay()
        {
            decimal total = 0;
            foreach (Employee employee in employees)
            {
                total += employee.ToPay();
            }
            return total;
        }
        
        public string NameMaxSalary()
        {
            decimal maxSalary = 0;
            string name = "";
            foreach (Employee employee in employees) {
                if (employee.ToPay() > maxSalary)
                {
                    maxSalary = employee.ToPay();
                    name = employee.Name;
                }
            }
            return name;
        }
    }
    
}
