using System;

public class Employee {

    private int id;
    private string name;
    private string jobTitle;
    private string department;
    private string phoneNumber;

    public void setId(int _id) {
        id = _id;
    }

    public int getId() {
        return id;
    }

    public void setName(string _name) {
        name = _name;
    }

    public string getName() {
        return name;
    }

    public void setJobTitle(string _jobTitle) {
        jobTitle = _jobTitle;
    }

    public string getJobTitle() {
        return jobTitle;
    }

    public void setDepartment(string _department) {
        department = _department;
    }

    public string getDepartment() {
        return department;
    }

    public void setPhoneNumber(string _phoneNumber) {
        phoneNumber = _phoneNumber;
    }

    public string getPhoneNumber() {
        return phoneNumber;
    }

    public void DisplayDetails() {
    
        Console.WriteLine($"{id} - Employee name: {name}. Job Title: {jobTitle}. Department: {department}. Phone number: {phoneNumber}");
    }
}
