using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {

                IAstronaut astronaut = astronauts.FirstOrDefault(x=>x.CanBreath==true);
                if (astronaut==null)
                {
                    break;
                }
                var currentItem = planet.Items.FirstOrDefault();
                if (currentItem==null)
                {
                    break;
                }
                astronaut.Breath();
                if (astronaut.CanBreath)
                {
                    astronaut.Bag.Items.Add(currentItem);
                    planet.Items.Remove(currentItem);
                }




            }
            //while (true)
            //{
                //var astronaut = astronauts.FirstOrDefault(a => a.CanBreath == true);

                //if (astronaut == null)
                //{
                //    break;
                //}
                //if (planet.Items.Count == 0)
                //{
                //    break;
                //}

                //while (astronaut.CanBreath)
                //{
                //    var item = planet.Items.FirstOrDefault();

                //    if (item == null)
                //    {
                //        break;
                //    }

                //    astronaut.Breath();

                //    if (astronaut.CanBreath)
                //    {
                //        astronaut.Bag.Items.Add(item);
                //        planet.Items.Remove(item);
                //    }

                //}

            //}
        }
    }
}
