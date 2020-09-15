using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Globalization;
using System.Linq.Expressions;

namespace TestEmployee
{
    class Program
    {
        static void Main(string[] args)
        {


                CRUD MyListObj = new CRUD(); 
       

               //load elements in file
               
                var list = MyListObj.Load();
               {
                   foreach (Employee line in list)
                {
                    string dt = line.date.ToString("dd.MM.yyyy");
                    Console.WriteLine("ID:" + line.id + "\tName:" + line.name + "\tAge:" + line.age + "\tSalary:" + line.salary + "\tDate:" + dt+ "\tPassPort:" + line.passport +"\tPhone:"+ line.phoneNumber + "\tEmail:"+ line.email);     
                }
                
               }

               //create the element 
               MyListObj.CreateEmployee(18, "Narine", 152000 , new DateTime(2015,12,25) , "077192427" , "sona.arshakyan.00@mail.ru" , "AS7859");
               var emp2 = MyListObj.CreateEmployee(38, "Karine", 142000 , new DateTime(2017, 12, 28) ,"077182427", "Shush.arshakyan.00@mail.ru", "AS7759");
               var emp3 = MyListObj.CreateEmployee(45, "Hermine", 142000, new DateTime(2016, 12, 30) ,"093568475" , "vahan.arshakyan.00@mail.ru", "AS6759");
               var emp4 = MyListObj.CreateEmployee(58, "Lusine", 87000 , new DateTime(2012, 10, 25) , "098754142" , "lala.arshakyan.00@mail.ru", "AS7659");
               var emp5 = MyListObj.CreateEmployee(18, "Lusine", 25000 , new DateTime(2019, 11, 30) , "055323436" , "kala.arshakyan.00@mail.ru", "AB7859");
               var emp6 = MyListObj.CreateEmployee(69, "Lusine", 98000 , new DateTime(2011, 08, 14) , "043585654" , "alla.arshakyan.00@mail.ru", "bS7859");
               var emp7 = MyListObj.CreateEmployee(18, "Marine", 142000 , new DateTime(2013, 09, 02) , "098757476", "bala.arshakyan.00@mail.ru", "AS3659");
               var emp8 = MyListObj.CreateEmployee(69, "Narek", 1482000 , new DateTime(2017, 12, 25), "093656862" , "lava.arshakyan.00@mail.ru", "AS1459");
              


                //read the element 
               Console.WriteLine();
               MyListObj.ReadEmployee(emp3.id);
               Console.WriteLine();

               //delete the element
               MyListObj.DeleteEmploye(emp3.id);
               Console.WriteLine();

               //see all elements
               MyListObj.AllEmployee();
               Console.WriteLine();

               //update the element 
               emp7.name = "Lianna";             
               MyListObj.UpdateEmploye(emp7);
               Console.WriteLine();

            //Searchmodel

            SearchModel searcElem = new SearchModel();
            searcElem.SearchBy = "Name";
            searcElem.Search = "Lusine";
            searcElem.OrderBy = "Date";
            searcElem.sort = SortDirection.Asc;
            var listSearch=  MyListObj.SearchMethod(searcElem);
            foreach (Employee line in listSearch)
            {
            string dt = line.date.ToString("dd.MM.yyyy");
            Console.WriteLine("ID:" + line.id + "\tName:" + line.name + "\tAge:" + line.age + "\tSalary:" + line.salary + "\tDate:" + dt + "\tPassPort:" + line.passport + "\tPhone:" + line.phoneNumber + "\tEmail:" + line.email);
            }





            //get the list of all element and write in txt file
            var Lists = MyListObj.GetList();

            string docPath = @"c:\";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
            {
                foreach (Employee line in  Lists)
                {
                    try 
                    { 
                      string dt = line.date.ToString("dd.MM.yyyy");
                      if (string.IsNullOrEmpty(dt))
                      throw new Exception("Your String Is not Valid Form");
                      outputFile.WriteLine(  line.id  +"\t"+  line.name + "\t"+ line.age + "\t" + line.salary + "\t"+ dt+ "\t"+ line.email + "\t" + line.phoneNumber+ "\t"+ line.passport);       
                    } 
                     catch (Exception e) 
                    {
                      Console.WriteLine(e);
                    }

                }
                              
            }











        }

}



}
