using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesEncountersMonitor.Models
{
    class EncounterModel
    {
        public EmployeeModel FirstEmployee { get; private set; }
        public EmployeeModel SecondEmployee { get; private set; }
        public int Frequence { get; set; }

        public EncounterModel() { }
        public EncounterModel(EmployeeModel firstEmployee, EmployeeModel secondEmployee, int frequence)
        {
            FirstEmployee = firstEmployee;
            SecondEmployee = secondEmployee;
            Frequence = frequence;
        }

        public override String ToString()
        {
            return FirstEmployee.EmployeeName + "-" + SecondEmployee.EmployeeName + ":" + Frequence;
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() == typeof(EncounterModel))
            {
                var anotherEncounter = (EncounterModel) obj;
                if (this.FirstEmployee.EmployeeName == anotherEncounter.FirstEmployee.EmployeeName &&
                    this.SecondEmployee.EmployeeName == anotherEncounter.SecondEmployee.EmployeeName &&
                    this.Frequence == anotherEncounter.Frequence)
                {
                    return true;
                }
                else 
                {
                    if (this.FirstEmployee.EmployeeName == anotherEncounter.SecondEmployee.EmployeeName &&
                    this.SecondEmployee.EmployeeName == anotherEncounter.FirstEmployee.EmployeeName &&
                    this.Frequence == anotherEncounter.Frequence)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
