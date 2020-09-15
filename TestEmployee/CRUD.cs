using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TestEmployee
{
    class CRUD
    {

        protected List<Employee> Employers;

        public CRUD()
        {
            Employers = new List<Employee>();


        }

        public List<Employee> Load()
        {
            List<Employee> listOfPersons = new List<Employee>();
            Employee.Staticid = 0;
            foreach (string line in File.ReadLines(@"c:\WriteLines.txt", Encoding.UTF8))
            {


                Employee newobj = new Employee();
                string[] words = line.Split();
                newobj.name = words[1];
                newobj.age = Int32.Parse(words[2]);
                newobj.salary = Int32.Parse(words[3]);
                newobj.date = Convert.ToDateTime(words[4]);
                newobj.email = words[5];
                newobj.phoneNumber = words[6];
                newobj.passport = words[7];
                // newobj.id = Int32.Parse(words[0]);
                listOfPersons.Add(newobj);
            }
            return listOfPersons;
        }

        public Employee CreateEmployee(int age, string name, int salary, DateTime data , string phone , string emailElem , string passportElem)
        {

            if (Employers.Any(i => i.phoneNumber == phone))
            {
                throw new Exception("You Already have this Number");
            }
            else if (Employers.Any(i => i.email == emailElem))
            {
                throw new Exception("You Already have this Email");
            }
            else if (Employers.Any(i => i.passport == passportElem))
            {
                throw new Exception("You Already have this Passport");
            }

            else
            {
            Employers.Add(new Employee { age = age, name = name, salary = salary, date = data  , phoneNumber = phone , email = emailElem, passport = passportElem });
            return (Employee)Employers[Employers.Count - 1].Clone();
            }


        }

        public void ReadEmployee(int id)
        {

            Employee employ = Employers.Find(x => x.id == id);
         //   Console.WriteLine("The Specific Model you are looking at!!");
            string dt = employ.date.ToString("dd.MM.yyyy");
          //  Console.WriteLine(employ.name + " " + employ.age + " " + employ.id + " " + employ.salary + " " + dt + employ.passport+ " "+ employ.phoneNumber+ " "+ employ.email);

        }

        public void AllEmployee()
        {
            Console.WriteLine();
            Console.WriteLine("The Result of our List ");
            Console.WriteLine();

            foreach (Employee employ in Employers)
            {
                string dt = employ.date.ToString("dd.MM.yyyy");

                Console.WriteLine(employ.name + " " + employ.age + " " + employ.id + " " + employ.salary + " " + dt + employ.passport + " " + employ.phoneNumber + " " + employ.email);
            }
        }

        public void DeleteEmploye(int id)
        {
            Employee employ = Employers.Find(x => x.id == id);
            Employers.Remove(employ);
            Console.WriteLine("You Deleted the Object Succesfully");
        }

        public void UpdateEmploye(Employee obj)
        {
            int id = obj.id;
            Employee employ = Employers.Find(x => x.id == id);
            employ.name = obj.name;
            employ.age = obj.age;
            employ.salary = obj.salary;
            employ.id = obj.id;
            Console.WriteLine("The Specific Model that you updated!!");
            string dt = employ.date.ToString("dd.MM.yyyy");
            Console.WriteLine("ID:" + employ.id + "\tName:" + employ.name + "\tAge:" + employ.age + "\tSalary:" + employ.salary + "\tDate:" + dt + "\tPassPort:" + employ.passport + "\tPhone:" + employ.phoneNumber + "\tEmail:" + employ.email);
        }
        public List<Employee> GetList()
        {
            return Employers.Clone<Employee>();
        }

        public List<Employee> SearchMethod(SearchModel searchElem)
        {
            List<Employee> listOfResult = new List<Employee>();


            //Search  With name 
                if (searchElem.SearchBy == "Name")
                 {                 
                 listOfResult = Employers.FindAll(x => x.name == searchElem.Search );
                if(searchElem.OrderBy == "Salary"  )
                {
                    if (searchElem.sort == SortDirection.Asc)
                        listOfResult.OrderBy(emp => emp.salary).ToList();
                    else
                        listOfResult.OrderByDescending(emp => emp.salary).ToList();   

                }

                else if (searchElem.OrderBy == "Age" )
                {
                    if (searchElem.sort == SortDirection.Asc)
                        listOfResult.OrderBy(emp => emp.age).ToList();
                    else
                        listOfResult.OrderByDescending(emp => emp.age).ToList();

                }
                else if (searchElem.OrderBy == "Date" )
                {
                    if (searchElem.sort == SortDirection.Asc)
                         listOfResult.OrderBy(emp => emp.date).ToList();
                    else
                        listOfResult.OrderByDescending(emp => emp.date).ToList();

                }

                }


            //Search with Age 

            if (searchElem.SearchBy == "Age")
            {
                listOfResult = Employers.FindAll(x => x.age == Convert.ToInt32(searchElem.Search));
                if (searchElem.OrderBy == "Salary")
                {
                    if (searchElem.sort == SortDirection.Asc)
                         listOfResult.OrderBy(emp => emp.salary).ToList();
                    else
                        listOfResult.OrderByDescending(emp => emp.salary).ToList();

                }

                else if (searchElem.OrderBy == "Name" )
                {
                    if (searchElem.sort == SortDirection.Asc)
                        listOfResult.OrderBy(emp => emp.name).ToList();
                    else
                        listOfResult.OrderByDescending(emp => emp.name).ToList();

                }
                else if (searchElem.OrderBy == "Date" )
                {
                    if (searchElem.sort == SortDirection.Asc)
                         listOfResult.OrderBy(emp => emp.date).ToList();
                    else
                        listOfResult.OrderByDescending(emp => emp.date).ToList();

                }

            }

            //Search With Salary 

            if (searchElem.SearchBy == "Salary")
            {
                listOfResult = Employers.FindAll(x => x.salary == Convert.ToInt32(searchElem.Search));
                if (searchElem.OrderBy == "Age")
                {
                    if (searchElem.sort == SortDirection.Asc)
                         listOfResult.OrderBy(emp => emp.age).ToList();
                    else
                        listOfResult.OrderByDescending(emp => emp.age).ToList();

                }

                else if (searchElem.OrderBy == "Name")
                {
                    if (searchElem.sort == SortDirection.Asc)
                         listOfResult.OrderBy(emp => emp.name).ToList();
                    else
                        listOfResult.OrderByDescending(emp => emp.name).ToList();
                }
                else if (searchElem.OrderBy == "Date")
                {
                    if (searchElem.sort == SortDirection.Asc)
                        listOfResult.OrderBy(emp => emp.date).ToList();
                    else
                        listOfResult.OrderByDescending(emp => emp.date).ToList();
                }

            }


            return listOfResult;

        }

    }


    static class Extensions
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }


    public enum SortDirection {Asc , Desc}
    public class SearchModel{
        public string SearchBy;
        public string Search;
        public string OrderBy;
        public SortDirection sort;
        }






}
