using EcoHelp.BusinessLogic.ViewModels;
using EcoHelp.DataAccess.Model;
using EcoHelp.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace EcoHelp.BusinessLogic.Contexts
{
    public class ContactContext
    {
        #region Private Variables
        private readonly ContactRepository _contactRepository;
        #endregion

        #region Constructors
        public ContactContext()
        {
            _contactRepository = new ContactRepository();
        }
        #endregion

        #region Repository Calls
        /// <summary>
        /// Method to get a list of all active supervisor contacts per zone
        /// </summary>
        /// <param name="zoneId"></param>
        /// <returns></returns>
        public List<VMContact> GetActiveSupervisorContactsByZoneId(int zoneId)
        {
            List<Contact> entityList = _contactRepository.GetActiveSupervisorContactsByZoneId(zoneId);
            List<VMContact> viewModelList = entityList.Select(c => new VMContact(c)).ToList();

            return viewModelList;
        }

        /// <summary>
        /// Method to get a list of all active support technician contacts per zone
        /// </summary>
        /// <param name="zoneId"></param>
        /// <returns></returns>
        public List<VMContact> GetActiveSupportTechnicianContactsByZoneId(int zoneId)
        {
            List<Contact> entityList = _contactRepository.GetActiveSupportTechnicianContactsByZoneId(zoneId);
            List<VMContact> viewModelList = entityList.Select(c => new VMContact(c)).ToList();

            return viewModelList;
        }

        /// <summary>
        /// Method to get a list of all active developer contacts per zone
        /// </summary>
        /// <returns></returns>
        public List<VMContact> GetActiveDeveloperContacts()
        {
            List<Contact> entityList = _contactRepository.GetActiveDeveloperContacts();
            List<VMContact> viewModelList = entityList.Select(c => new VMContact(c)).ToList();

            return viewModelList;
        }
        #endregion
    }
}
