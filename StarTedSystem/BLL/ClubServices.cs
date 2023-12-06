using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StarTedSystem.DAL;
using StarTedSystem.Entities;

namespace StarTedSystem.BLL
{
    public class ClubServices
    {
        private readonly StarTedContext _context;

        internal ClubServices(StarTedContext context) 
        {  
            _context = context; 
        }

        
        /// <summary>
        /// Return all club in the system
        /// </summary>
        /// <returns>A list of clubs, if any were found.</returns>
        public List<Club>? GetClubs() 
        {
            return _context.Clubs.ToList<Club>();
        }

        /// <summary>
        /// Retrieves a list of clubs by status
        /// </summary>
        /// <param name="active">Retrieve active or inactive clubs.</param>
        /// <returns>A list of clubs based on the status.</returns>
        public List<Club>? GetClubs(bool active)
        {
            if (active)
            {
                return _context.Clubs.Where(c => c.Active).ToList();
            }
            else
            {
                return _context.Clubs.Where(c => !c.Active).ToList();
            }
        }
    }
}

