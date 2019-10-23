namespace MortalEngines.Core
{
    using System.Collections.Generic;
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Linq;
    using MortalEngines.Common;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            if (pilots.Any(x=>x.Name==name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
           
                IPilot pilot = new Pilot(name);

                this.pilots.Add(pilot);
            return string.Format(OutputMessages.PilotHired, pilot.Name);

        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                ITank tank = new Tank(name,attackPoints,defensePoints);
                machines.Add(tank);
                return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x=>x.Name==name))
            {
                return $"Machine {name} is manufactured already";
            }
            IFighter fighter = new Fighter(name, attackPoints, defensePoints);

            machines.Add(fighter);
            return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, fighter.AggressiveMode == true ? "ON" : "OFF");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (pilots.All(x => x.Name != selectedPilotName))
            {
                return $"Pilot {selectedPilotName} could not be found";
                //pilots.All(x => x.Name != selectedPilotName)
                //!(pilots.Any(x => x.Name == selectedPilotName)
            }
            if (machines.All(x => x.Name != selectedMachineName))
            {
                return $"Machine {selectedMachineName} could not be found";
                //machines.All(x => x.Name != selectedMachineName)
                //!(machines.Any(x => x.Name == selectedPilotName)
            }


            var machine = machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (machine.Pilot==null)
            {
                var pilot = pilots.FirstOrDefault(x => x.Name == selectedPilotName);
                machine.Pilot = pilot;
                return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
            }
            else
            {
                return $"Machine {selectedMachineName} is already occupied";
            }



        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!machines.Any(x=>x.Name==attackingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            if (!machines.Any(x => x.Name == defendingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            var attackingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defendingMachine = machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attackingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            if (defendingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachine);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);

        }

        public string PilotReport(string pilotReporting)
        {

                var pilot = pilots.FirstOrDefault(x => x.Name == pilotReporting);
                 return pilot.Report();
            
        }

        public string MachineReport(string machineName)
        {
            var machine = machines.FirstOrDefault(x => x.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (machines.Any(x=>x.Name ==fighterName))
            {
                var fighter = (Fighter)machines.FirstOrDefault(x => x.Name == fighterName);
                fighter.ToggleAggressiveMode();
                return $"Fighter {fighterName} toggled aggressive mode";
            }
            return $"Machine {fighterName} could not be found";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (machines.Any(x=>x.Name==tankName))
            {
                var tank = (Tank)machines.FirstOrDefault(x => x.Name == tankName);
                tank.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }
            else
            {
                return $"Machine {tankName} could not be found";
            }
        }

    }
}