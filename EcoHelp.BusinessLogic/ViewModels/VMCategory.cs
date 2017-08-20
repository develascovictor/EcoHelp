using System;
using System.Linq;
using System.Collections.Generic;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.BusinessLogic.ViewModels
{
    public class VMCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<VMIssue> Issues { get; set; }

        public VMCategory()
        {
            EmptyObject();
        }

        public VMCategory(Category category)
        {
            EmptyObject();

            if (category != null)
            {
                Id = category.CategoryId;
                Name = category.Name;
                IsActive = category.IsActive;

                Issues = category.Issues.Where(i => i.IsActive).OrderBy(i => i.Name).Select(i => new VMIssue(i)).ToList();
            }
        }

        private void EmptyObject()
        {
            Id = 0;
            Name = String.Empty;
            IsActive = false;

            Issues = new List<VMIssue>();
        }
    }
}