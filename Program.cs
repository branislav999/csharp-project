using System;
using System.Collections.Generic;
using System.IO;

namespace csharp_project
{
    class Program {
    
    static void Main(string[] args) {
        List<Employee> employees = new List<Employee>();
        Program program = new Program();
        
        bool continueMenu = true;
        
        while (continueMenu) {
            Console.WriteLine("\nEmployee Management Menu: ");
            Console.WriteLine("1. Add an Employee");
            Console.WriteLine("2. Print all Employees");
            Console.WriteLine("3. Update Employee Information");
            Console.WriteLine("4. Search Employee by Name");
            Console.WriteLine("5. Search Employee by ID");
            Console.WriteLine("6. Write Employees to an external database");
            Console.WriteLine("7. Display Employees from an external database");
            Console.WriteLine("0. Quit the program");
            
            Console.WriteLine("Enter your choice (0-5): ");
            string input = Console.ReadLine();
            int choice = int.Parse(input);
            
            switch (choice) {
                case 1:
                    program.AddEmployee(employees);
                    break;
                
                case 2:
                    program.PrintEmployees(employees);
                    break;
                
                case 3:
                    program.UpdateEmployee(employees);
                    break;
                
                case 4:
                    program.SearchEmployeeByName(employees);
                    break;
                
                case 5:
                    program.SearchEmployeeById(employees);
                    break;
                
                case 6:
                    program.WriteFile(employees);
                    break;

                case 7:
                    program.ReadFile();
                    break;
                
                case 0:
                    continueMenu = false;
                    break;
                
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 0 to 5.");
                    break;
            }
        }
    }

    public void AddEmployee(List<Employee> employees) {
        Employee newEmployee = new Employee();
        
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());
        newEmployee.setId(id);

        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();
        newEmployee.setName(name);

        Console.Write("Enter Employee Job Title: ");
        string jobTitle = Console.ReadLine();
        newEmployee.setJobTitle(jobTitle);

        Console.Write("Enter Employee Department: ");
        string department = Console.ReadLine();
        newEmployee.setDepartment(department);

        Console.Write("Enter Employee Phone Number: ");
        string phoneNumber = Console.ReadLine();
        newEmployee.setPhoneNumber(phoneNumber);

        employees.Add(newEmployee);
        
        Console.WriteLine("Employee added successfully.");
    }

    public void PrintEmployees(List<Employee> employees) {
        foreach (Employee employee in employees) {
            employee.DisplayDetails();
        }
    }

    public void UpdateEmployee(List<Employee> employees) {
        Console.Write("Enter Employee ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Employee employeeToUpdate = employees.Find(e => e.getId() == id);

        if (employeeToUpdate != null) {
            Console.WriteLine("Enter updated information:");

            Console.Write("New Employee Name: ");
            string newName = Console.ReadLine();
            employeeToUpdate.setName(newName);

            Console.Write("New Job Title: ");
            string newJobTitle = Console.ReadLine();
            employeeToUpdate.setJobTitle(newJobTitle);

            Console.Write("New Department: ");
            string newDepartment = Console.ReadLine();
            employeeToUpdate.setDepartment(newDepartment);

            Console.Write("New Phone Number: ");
            string newPhoneNumber = Console.ReadLine();
            employeeToUpdate.setPhoneNumber(newPhoneNumber);

            Console.WriteLine("Employee information updated successfully.");
        } else {
            Console.WriteLine($"Employee with ID {id} not found.");
        }
    }

    public void SearchEmployeeByName(List<Employee> employees) {
        Console.Write("Enter Employee Name to search: ");
        string name = Console.ReadLine();

        List<Employee> foundEmployees = employees.FindAll(e => e.getName().Equals(name, StringComparison.OrdinalIgnoreCase));

        if (foundEmployees.Count > 0) {
            Console.WriteLine($"Found {foundEmployees.Count} employee(s) with name '{name}':");
            foreach (Employee employee in foundEmployees) {
                employee.DisplayDetails();
            }
        } else {
            Console.WriteLine($"No employees found with name '{name}'.");
        }
    }

    public void SearchEmployeeById(List<Employee> employees) {
        Console.Write("Enter Employee ID to search: ");
        int id = int.Parse(Console.ReadLine());

        Employee foundEmployee = employees.Find(e => e.getId() == id);

        if (foundEmployee != null) {
            foundEmployee.DisplayDetails();
        } else {
            Console.WriteLine($"Employee with ID {id} not found.");
        }
    }

    public void WriteFile(List<Employee> employees) {
        using (StreamWriter sw = new StreamWriter("data.txt", true)){
            foreach (Employee employee in employees){  
                
                string line = $"{employee.getId()}, {employee.getName()}, {employee.getJobTitle()}, {employee.getDepartment()}, {employee.getPhoneNumber()}";
                sw.WriteLine(line);            }
        }
    }

    public void ReadFile(){
        using (StreamReader sr = new StreamReader("data.txt")){

            string line;

            while((line = sr.ReadLine()) != null){
                
                Console.WriteLine(line);


            }
        }
    }

}


}
