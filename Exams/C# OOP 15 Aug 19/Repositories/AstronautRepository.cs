using SpaceStation.Models.Astronauts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>

    {
        private readonly List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut> ();
        }

        public IReadOnlyCollection<IAstronaut> Models => astronauts.AsReadOnly();

        public void Add(IAstronaut model)
        {
            astronauts.Add(model);
        }

       

        public IAstronaut FindByName(string name)
        {
            return astronauts.FirstOrDefault(x => x.Name == name);
            //var astronautToFind = this.astronauts.FirstOrDefault(a => a.Name == name);

            //if (astronautToFind != null)
            //{
            //    return astronautToFind;
            //}
            //else
            //{
            //    return null;
            //}
        }

        public bool Remove(IAstronaut model)
        {
            return astronauts.Remove(model);
        }

        
    }


}
