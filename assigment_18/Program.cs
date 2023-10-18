using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assigment_18
{
    public class Employee
    {
        private int EmpNo;

        public int EmployeNo
        {
            get { return EmpNo; }
            set
            {
                if(value == 0)
                {
                    throw new ArgumentException("EmpNo can't be zero");
                }
                EmpNo = value;             
           }
        }

        private string name;

        public string Ename
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Employee name can't be null");
                }
                name = value;
            }
        }
        public double sal;

        public double Salary
        {
            get { return sal; }
            set { sal = value; }
        }
        public int deptno;

        public int DeptNo
        {
            get { return deptno; }
            set 
            {
                if(value == 0)
                {
                    throw new ArgumentException("Department no. can't be zero");
                }
                deptno = value; 
            }
        }
        public static void GetEmployeeData()
        {
            Employee emp = new Employee();
            try
            {
                Console.WriteLine("Enter Employee No. ");
                emp.EmployeNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Name : ");
                emp.Ename = Console.ReadLine();
                Console.WriteLine("Enter Salary : ");
                emp.Salary = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Dept no. : ");
                emp.DeptNo = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
     
        static void Main(string[] args)
        {
          
           GetEmployeeData();

            Console.ReadLine(); 
        }
    }
    
}
