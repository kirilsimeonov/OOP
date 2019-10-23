using System;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Tank:BaseMachine,ITank
    {
        private const double INITIAL_HEALTH_POINTS = 100;
        private const double ATTACK_CHANGE = 40;
        private const double DEFENSE_CHANGE = 30;

        public Tank(string name, double attackPoints, double defensePoints)
        : base(name, attackPoints - ATTACK_CHANGE, defensePoints + DEFENSE_CHANGE, INITIAL_HEALTH_POINTS)
        {
            DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }



        public void ToggleDefenseMode()
        {
            if (DefenseMode == true)
            {
                DefenseMode = false;
                AttackPoints += ATTACK_CHANGE;
                DefensePoints -= DEFENSE_CHANGE;

            }
            else if (DefenseMode == false)
            {
                DefenseMode = true;
                AttackPoints -= ATTACK_CHANGE;
                DefensePoints += DEFENSE_CHANGE;
            }
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Defense: {(this.DefenseMode == true ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
