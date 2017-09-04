using System;
using System.Linq;
using System.Collections.Generic;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.BusinessLogic.ViewModels
{
    public class VMCause
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public List<VMSolution> Solutions { get; set; }

        public VMCause()
        {
            EmptyObject();
        }

        public VMCause(Cause cause)
        {
            EmptyObject();

            if (cause != null)
            {
                Id = cause.CauseId;
                Description = cause.Description;
                IsActive = cause.IsActive;

                Solutions = cause
                    .CauseSolutions
                    .Where(cs => cs.IsActive)
                    .OrderBy(cs => cs.Sequence)
                    .Select(cs => cs.Solution)
                    .Where(s => s.IsActive)
                    .Select(s => new VMSolution(s))
                    .ToList();
            }
        }

        private void EmptyObject()
        {
            Id = 0;
            Description = String.Empty;
            IsActive = false;

            Solutions = new List<VMSolution>();
        }
    }
}