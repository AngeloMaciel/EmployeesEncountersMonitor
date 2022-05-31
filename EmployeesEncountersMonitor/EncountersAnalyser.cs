using EmployeesEncountersMonitor.Models;
using EmployeesEncountersMonitor.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesEncountersMonitor
{
    class EncountersAnalyser
    {
        private List<EmployeeModel> Employees = new();

        public List<EncounterModel> Analyse()
        {
            //may become a class function (FileParser)
            var fileName = "INPUT.txt";
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var filePath = Path.Combine(projectDirectory, @"Input\", fileName);
            var employeesParser = new EmployeesParser(filePath);
            var encounters = new List<EncounterModel>();
            Employees = employeesParser.Parse();

            foreach (var employee in Employees)
            {
                var attendances = employee.AttendanceTimes;
                //foreach (var attendance in attendances)
                //{
                var foundEmployeeEncounters = FindEmployeeEncounters(employee);//attendance parameter
                foreach (var foundEncounterResult in foundEmployeeEncounters)
                {
                    if (!encounters.Where(
                            e => e.Equals(foundEncounterResult)
                            )
                            .Any()
                        )
                    {
                        encounters.Add(foundEncounterResult);
                    }
                }
                //}
            }
            return encounters;
        }

        private List<EncounterModel> FindEmployeeEncounters(EmployeeModel employee)
        {
            var otherEmployees = Employees.FindAll(em => em.EmployeeName != employee.EmployeeName);
            var employeeAttendances = employee.AttendanceTimes;
            var encounters = new List<EncounterModel>();

            foreach (var otherEmployee in otherEmployees)
            {
                var foundEncounters = otherEmployee.AttendanceTimes.FindAll(
                    at => employeeAttendances.FindAll(
                        eat => IsAnEncounter(at, eat))
                        .Any()
                    );
                var newEncounter = new EncounterModel(
                    employee,
                    otherEmployee,
                    foundEncounters.Count
                    );
                encounters.Add(newEncounter);
            }
            return encounters;
        }

        private bool IsAnEncounter(OfficeAttendanceModel attendance1, OfficeAttendanceModel attendance2)
        {
            if (attendance1.DayOfWeek == attendance2.DayOfWeek)
            {
                if ((attendance1.ExitTime > attendance2.EntryTime) &&
                    attendance1.ExitTime <= attendance2.ExitTime)
                {
                    return true;
                }
                else
                {
                    if ((attendance2.ExitTime > attendance1.EntryTime) &&
                        attendance2.ExitTime <= attendance1.ExitTime)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
