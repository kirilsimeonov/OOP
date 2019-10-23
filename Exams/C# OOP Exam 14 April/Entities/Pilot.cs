using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private readonly List<IMachine> machines;

        public Pilot(string name) 
        {
            Name = name;
            machines = new List<IMachine>();
        }

        public string Name { get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine==null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }
            machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{name} - {machines.Count} machines");
            foreach (var machine in machines )
            {
                sb.AppendLine(machine.ToString());
                //sb.AppendLine($"- {machine.Name}");
                //sb.AppendLine($" *Type:{machine.GetType().Name}");
                //sb.AppendLine($" *Health:{machine.HealthPoints}");
                //sb.AppendLine($" *Attack:{machine.AttackPoints}");
                //sb.AppendLine($" *Defense:{machine.DefensePoints}");
                //sb.AppendLine($" *Targets: {string.Join(" ",machine.Targets)}");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
