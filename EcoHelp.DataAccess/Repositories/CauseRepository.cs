using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.DataAccess.Repositories
{
    public class CauseRepository : Repository
    {
        /// <summary>
        /// Method to get all active causes from a specific issue Id
        /// </summary>
        /// <param name="issueId"></param>
        /// <returns></returns>
        public List<Cause> GetActiveCausesByIssueId(int issueId)
        {
            List<Cause> causes = Db.IssueCauses
                .Include(i => i.Issue)
                .Include(i => i.Cause)
                .Include(i => i.Cause.CauseSolutions)
                .Include("Cause.CauseSolutions.Solution")
                .Where(i => i.IsActive && i.IssueId == issueId && i.Cause.IsActive)
                .OrderBy(i => i.Sequence)
                .Select(i => i.Cause)
                .ToList();
            return causes;
        }
    }
}