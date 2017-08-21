using System;
using System.ComponentModel;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.BusinessLogic.ViewModels
{
    public class VMIssue
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int PriorityId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public VMProperty Priority
        {
            get
            {
                return ((Priorities)PriorityId).ToVMProperty();
            }
        }

        public VMIssue()
        {
            EmptyObject();
        }

        public VMIssue(Issue issue)
        {
            EmptyObject();

            if (issue != null)
            {
                Id = issue.IssueId;
                CategoryId = issue.CategoryId;
                PriorityId = issue.PriorityId;
                Name = issue.Name;
                IsActive = issue.IsActive;
            }
        }

        private void EmptyObject()
        {
            Id = 0;
            CategoryId = 0;
            PriorityId = 0;
            Name = String.Empty;
            IsActive = false;
        }
    }

    public enum Priorities
    {
        [Description("Bajo")]
        Low = 1,
        [Description("Medio")]
        Medium = 2,
        [Description("Alto")]
        High = 3
    }
}
