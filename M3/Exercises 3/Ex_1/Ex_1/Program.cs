// ***********************************************************************
// Assembly         : Exercise 3 program 1
// Author           : Daniel Beckerich
// Created          : 11/7/2018
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 11/7/2018
// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Linq;

//this interface will dictate what methods and data members all staff members will have.
public interface IStaff
{
    //variables for the name and salary
    string Name { get; set; }
    double Salary { get; set; }

}

//interface that teaching staff members will have.
public interface ITeachable
{
    void Teach();
}

//administrative interface that staff members with administrative duties will have
public interface IAdmin
{
    void Administrate();
}

//professor implementation
class Professor : IStaff, ITeachable
{
    enum Fields { Math, English, Geography, ComputerScience };

    public string Name { get; set; }
    public double Salary { get; set; }

    public Professor(String newName, double newSalary)
    {
        Name = newName;
        Salary = newSalary;
    }

    //have the professor Teach.
    public void Teach()
    {
        Console.WriteLine("{0} is Teaching the field of {1}", Name, Fields.Math);
    }
}

class Researcher : IStaff, ITeachable
{
    //Hard coded fields of study.
    enum Fields { Math, English, Geography, ComputerScience };

    public string Name { get; set; }
    public double Salary { get; set; }

    public Researcher(String newName, double newSalary)
    {
        Name = newName;
        Salary = newSalary;
    }

    //have the researcher teach.
    public void Teach()
    {
        Console.WriteLine("{0} is Teaching the field of {1}", Name, Fields.Math);
    }

    //have the researcher conduct research.
    public void conductReaserch()
    {
        Console.WriteLine("{0} is conducting research in the field of {1}", Name, "Biology");
    }
}

class Dean : IStaff, ITeachable, IAdmin
{
    //enum containing the fields of study that the person can teach.
    enum Fields { Math, English, Geography, ComputerScience };

    //constructors, containing both empty and non-empty versions.
    public string Name { get; set; }
    public double Salary { get; set; }

    public Dean(String newName, double newSalary)
    {
        Name = newName;
        Salary = newSalary;
    }

    //methods for both teaching and administrating. 
    public void Teach()
    {
        Console.WriteLine("{0} is Teaching the field of {1}", Name, Fields.Math);
    }

    public void Administrate()
    {
        Console.WriteLine("{0} is doing administrative tasks", Name);
    }
}

class Administrator : IAdmin
{
    public string Name { get; set; }
    public double Salary { get; set; }

    public Administrator(String newName, double newSalary)
    {
        Name = newName;
        Salary = newSalary;
    }

    public void Administrate()
    {
        Console.WriteLine("{0} is doing administrative tasks", Name);
    }
}



//department implementation; 
class Department
{
    //variables for storing staff members, the dean, the professors, administrators, and the researchers.
    //I'm using a list so i can use .Add() to help me keep track of the number of staff members.
    public List<IStaff> departmentStaff;

    //if we just want an empty department, add a default staff member as the dean. the others do not matter.
    public Department()
    {
        departmentStaff = new List<IStaff>();

    }

    public Department(List<IStaff> StaffList)
    {
        departmentStaff = StaffList;
    }

    //this method will add a staff member to the list with its appropriate type to the list.
    public void AddStaff(string newName, double newSalary, string staffType)
    {
        if (staffType.ToLower() == "dean") { departmentStaff.Add(new Dean(newName, newSalary)); }
        else if (staffType.ToLower() == "professor") { departmentStaff.Add(new Professor(newName, newSalary)); }
        else if (staffType.ToLower() == "administrator") { departmentStaff.Add(new Dean(newName, newSalary)); }
        else departmentStaff.Add(new Researcher(newName, newSalary));
    }
}

//university definition 
class University
{
    public Department[] DepartmentList;

    public University(List<Department> newDepartment)
    {
        DepartmentList = newDepartment.ToArray();
    }

    Department[] getDptList()
    {
        return DepartmentList;
    }
}


namespace Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //first create the four new departments.
            Department MthDepartment = new Department();
            Department EngDepartment = new Department();
            Department GeoDepartment = new Department();
            Department CSDepartment = new Department();

            //add people to them
            MthDepartment.AddStaff("James", 70000, "Administrator");
            MthDepartment.AddStaff("Matt", 80000, "dean");
            MthDepartment.AddStaff("Clark", 75000, "Researcher");
            MthDepartment.AddStaff("Jill", 75000, "Professor");

            EngDepartment.AddStaff("Mark", 70000, "Administrator");
            EngDepartment.AddStaff("Kaitlyn", 80000, "dean");
            EngDepartment.AddStaff("John", 75000, "Researcher");
            EngDepartment.AddStaff("Bob", 75000, "Professor");

            GeoDepartment.AddStaff("Joe", 70000, "Administrator");
            GeoDepartment.AddStaff("Cathy", 80000, "dean");
            GeoDepartment.AddStaff("Annette", 75000, "Researcher");
            GeoDepartment.AddStaff("Chester", 75000, "Professor");
            //should have used a database...
            CSDepartment.AddStaff("Cortney", 70000, "Administrator");
            CSDepartment.AddStaff("Joesph", 80000, "dean");
            CSDepartment.AddStaff("Jackelyn", 75000, "Researcher");
            CSDepartment.AddStaff("Gregg", 75000, "Professor");

            //now add all the departments to the university.
            University newUni = new University(new List<Department> { MthDepartment, EngDepartment, GeoDepartment, CSDepartment });

            //for each department
            for (int z = 0; z < newUni.DepartmentList.Count(); z++)
            {
                //and each staff member in that department.
                for (int i = 0; i < newUni.DepartmentList[0].departmentStaff.Count(); i++)
                {
                    //print out the staff list.
                    Console.WriteLine("{0} Makes ${1}", newUni.DepartmentList[z].departmentStaff[i].Name, newUni.DepartmentList[0].departmentStaff[i].Salary);

                    //if the specific person can teach or research, cast the object to the specific type (interface or class type) and execute their unique method.
                    if (newUni.DepartmentList[z].departmentStaff[i] is Researcher) { ((Researcher)(newUni.DepartmentList[z].departmentStaff[i])).conductReaserch(); }
                    if (newUni.DepartmentList[z].departmentStaff[i] is ITeachable) { ((ITeachable)(newUni.DepartmentList[z].departmentStaff[i])).Teach(); }
                    if (newUni.DepartmentList[z].departmentStaff[i] is IAdmin) { ((IAdmin)(newUni.DepartmentList[z].departmentStaff[i])).Administrate(); }

                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
