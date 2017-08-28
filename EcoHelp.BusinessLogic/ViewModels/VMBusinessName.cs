using System;
using System.ComponentModel;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.BusinessLogic.ViewModels
{
    public class VMBusinessName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public VMBusinessName()
        {
            EmptyObject();
        }

        public VMBusinessName(BusinessName businessName)
        {
            EmptyObject();

            if (businessName != null)
            {
                Id = businessName.BusinessNameId;
                Name = businessName.Name;
                IsActive = businessName.IsActive;
            }
        }

        private void EmptyObject()
        {
            Id = 0;
            Name = String.Empty;
            IsActive = false;
        }
    }
}