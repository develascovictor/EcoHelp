using System;
using System.ComponentModel;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.BusinessLogic.ViewModels
{
    public class VMSolution
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public VMSolution()
        {
            EmptyObject();
        }

        public VMSolution(Solution solution)
        {
            EmptyObject();

            if (solution != null)
            {
                Id = solution.SolutionId;
                Description = solution.Description;
                IsActive = solution.IsActive;
            }
        }

        private void EmptyObject()
        {
            Id = 0;
            Description = String.Empty;
            IsActive = false;
        }
    }
}