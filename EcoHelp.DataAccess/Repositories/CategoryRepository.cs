using System.Linq;
using System.Collections.Generic;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.DataAccess.Repositories
{
    public class CategoryRepository : Repository
    {
        /// <summary>
        /// Method to get all active categories
        /// </summary>
        /// <returns></returns>
        public List<Category> GetTravelRequestsWithPendingApprovals()
        {
            List<Category> categories = Db.Categories
                .Where(c => c.IsActive)
                .OrderBy(c => c.Name)
                .ToList();

            return categories;
        }
    }
}