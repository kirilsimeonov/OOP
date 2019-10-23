using System;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter :BaseMachine, IFighter
    {

        private const double INITIAL_HEALTH_POINTS = 200;
        private const double ATTACK_CHANGE = 50;
        private const double DEFENSE_CHANGE = 25;

        public Fighter(string name, double attackPoints, double defensePoints) 
        : base(name, attackPoints+ATTACK_CHANGE, defensePoints-DEFENSE_CHANGE, INITIAL_HEALTH_POINTS)
        {
            AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == true)
            {
                AggressiveMode = false;
                AttackPoints -= ATTACK_CHANGE;
                DefensePoints += DEFENSE_CHANGE;

            }
            else if (AggressiveMode==false)
            {
                AggressiveMode = true;
                 AttackPoints += ATTACK_CHANGE;
                DefensePoints -= DEFENSE_CHANGE;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
           
            sb.AppendLine($" *Aggressive: {(this.AggressiveMode == true ? "ON" : "OFF")}");


            return sb.ToString().TrimEnd();
        }

       
    }
}
