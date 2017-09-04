using System;
using System.Linq;
using EcoHelp.DataAccess.Model;
using System.Collections.Generic;

namespace EcoHelp.BusinessLogic.ViewModels
{
    public class VMZone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public VMZone()
        {
            EmptyObject();
        }

        public VMZone(Zone zone)
        {
            EmptyObject();

            if (zone != null)
            {
                Id = zone.ZoneId;
                Name = zone.Name;
                IsActive = zone.IsActive;
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