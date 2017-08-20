using EcoHelp.BusinessLogic.ViewModels;
using EcoHelp.DataAccess.Model;
using EcoHelp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHelp.BusinessLogic.Contexts
{
    public class CategoryContext
    {
        #region Private Variables
        private readonly CategoryRepository _categoryRepository;
        #endregion

        #region Constructors
        public CategoryContext()
        {
            _categoryRepository = new CategoryRepository();
        }
        #endregion

        #region Repository Calls
        /// <summary>
        /// Method to get all active categories
        /// </summary>
        /// <returns></returns>
        public List<VMCategory> GetActiveCategories()
        {
            List<Category> entityList = _categoryRepository.GetActiveCategories();
            List<VMCategory> viewModelList = entityList.Select(c => new VMCategory(c)).ToList();

            return viewModelList;
        }
        #endregion
    }
}
