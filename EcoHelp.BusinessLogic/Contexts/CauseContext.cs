using EcoHelp.BusinessLogic.ViewModels;
using EcoHelp.DataAccess.Model;
using EcoHelp.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace EcoHelp.BusinessLogic.Contexts
{
    public class CauseContext
    {
        #region Private Variables
        private readonly CauseRepository _causeRepository;
        #endregion

        #region Constructors
        public CauseContext()
        {
            _causeRepository = new CauseRepository();
        }
        #endregion

        #region Repository Calls
        /// <summary>
        /// Method to get all active causes from a specific issue Id
        /// </summary>
        /// <param name="issueId"></param>
        /// <returns></returns>
        public List<VMCause> GetActiveCausesByIssueId(int issueId)
        {
            List<Cause> entityList = _causeRepository.GetActiveCausesByIssueId(issueId);
            List<VMCause> viewModelList = entityList.Select(c => new VMCause(c)).ToList();

            return viewModelList;
        }
        #endregion
    }
}
