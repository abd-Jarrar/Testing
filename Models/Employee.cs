using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string DutyStation { get; set; } = null!;
        public bool IsMarried { get; set; }
        public int TotalDependencies { get; set; }

        public decimal Wage { get; set; }

        public int WorkingDays { get; set; }
        public bool IsDanger { get; set; }
        public bool HasPensionPlan { get; set; }

        public HealthInsurancePackage? HealthInsurancePackage { get; set; }

        public WorkPlatform WorkPlatform { get; set; }

    }
}
