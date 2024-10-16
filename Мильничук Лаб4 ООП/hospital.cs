using System;
using System.Collections.Generic;
using System.Linq;

public class Hospital
{
    private Dictionary<string, List<string>> departments;
    private Dictionary<string, List<string>> doctors;

    public Hospital()
    {
        departments = new Dictionary<string, List<string>>();
        doctors = new Dictionary<string, List<string>>();
    }

    public void AddPatient(string department, string doctor, string patient)
    {
        if (!departments.ContainsKey(department))
        {
            departments[department] = new List<string>();
        }

        if (departments[department].Count < 60)
        {
            departments[department].Add(patient);
        }

        if (!doctors.ContainsKey(doctor))
        {
            doctors[doctor] = new List<string>();
        }

        doctors[doctor].Add(patient);
    }

    public void OutputDepartment(string department)
    {
        if (departments.ContainsKey(department))
        {
            foreach (var patient in departments[department])
            {
                Console.WriteLine(patient);
            }
        }
    }

    public void OutputRoom(string department, int roomNumber)
    {
        if (departments.ContainsKey(department))
        {
            var patients = departments[department].Skip((roomNumber - 1) * 3).Take(3).OrderBy(p => p);
            foreach (var patient in patients)
            {
                Console.WriteLine(patient);
            }
        }
    }

    public void OutputDoctor(string doctor)
    {
        if (doctors.ContainsKey(doctor))
        {
            foreach (var patient in doctors[doctor].OrderBy(p => p))
            {
                Console.WriteLine(patient);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Hospital hospital = new Hospital();
        string input;

        while ((input = Console.ReadLine()) != "Output")
        {
            string[] data = input.Split();
            string department = data[0];
            string doctor = data[1] + " " + data[2];
            string patient = data[3];

            hospital.AddPatient(department, doctor, patient);
        }

        while ((input = Console.ReadLine()) != "End")
        {
            string[] command = input.Split();

            if (command.Length == 1)
            {
                hospital.OutputDepartment(command[0]);
            }
            else if (command.Length == 2 && int.TryParse(command[1], out int roomNumber))
            {
                hospital.OutputRoom(command[0], roomNumber);
            }
            else
            {
                string doctor = command[0] + " " + command[1];
                hospital.OutputDoctor(doctor);
            }
        }
    }
}
