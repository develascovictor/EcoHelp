using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.DataAccess.Repositories
{
    public class ContactRepository : Repository
    {
        /// <summary>
        /// Method to get a list of all supervisors per zone
        /// </summary>
        /// <param name="zoneId"></param>
        /// <returns></returns>
        public List<Contact> GetSupervisorContactsByZoneId(int zoneId)
        {
            List<Contact> contacts = Db.Contacts
                .Where(c => c.IsActive && c.Stations.Any(s => s.IsActive && s.ZoneId == zoneId))
                .ToList();
            return contacts;
        }
    }
}