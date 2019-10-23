using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Mission;

namespace SpaceStation.Core
{
    public class Controller : IController


    {

        private PlanetRepository planetRepository;
        private AstronautRepository astronautRepository;
        private Mission mission;

        public Controller()
        {
            planetRepository = new PlanetRepository();
            astronautRepository = new AstronautRepository();
            mission = new Mission();

        }


        int exploredPlanets = 0;

        public string AddAstronaut(string type, string astronautName)
        {
            if (type=="Biologist")
            {
                IAstronaut astronaut = new Biologist(astronautName);
                astronautRepository.Add(astronaut);
                return $"Successfully added {type}: {astronautName}!";
            }
            else if (type=="Geodesist")
            {
                IAstronaut astronaut = new Geodesist(astronautName);
                astronautRepository.Add(astronaut);
                return $"Successfully added {type}: {astronautName}!";
            }
            else if (type == "Meteorologist")
            {
                IAstronaut astronaut = new Meteorologist(astronautName);
                astronautRepository.Add(astronaut);
                return $"Successfully added {type}: {astronautName}!";
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
        }
       

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planetRepository.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planetRepository.FindByName(planetName);

            if (!astronautRepository.Models.Any(x=>x.Oxygen>60))
            {
                throw new InvalidOperationException($"You need at least one astronaut to explore the planet");
            }

            var astro = astronautRepository.Models.Where(x => x.Oxygen > 60).ToList();

            mission.Explore(planet, astro);
            exploredPlanets++;
            var dead = astro.Where(x => x.CanBreath == false);
            return $"Planet: {planetName} was explored! Exploration finished with {dead.Count()} dead astronauts!";
        }
        //        public string ExplorePlanet(string planetName)
        //        {
        //            var planetToExplore = this.planetRepository.FindByName(planetName);
        //            var astronauts = this.astronautRepository.Models.Where(a => a.Oxygen > 60).Where(a => a.CanBreath == true).ToList();

        //            if (astronauts.Count == 0)
        //            {
        //                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
        //            }

        //            this.mission.Explore(planetToExplore, astronauts);
        //            this.exploredPlanets++;

        //            string result = $"Planet: {planetName} was explored! Exploration finished with {astronauts.Where(a => a.CanBreath == false).Count()} dead astronauts!";

        //            return result;
        //        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var astronaut in astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count==0)
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
               // sb.Append(Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (astronautRepository.FindByName(astronautName)==null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            else
            {
                astronautRepository.Remove(astronautRepository.FindByName(astronautName));
                return $"Astronaut {astronautName} was retired!";
            }
        }
    }
}






