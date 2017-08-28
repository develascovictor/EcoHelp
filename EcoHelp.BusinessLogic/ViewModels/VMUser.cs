using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.BusinessLogic.ViewModels
{
    public class VMUser
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }

        public VMContact Contact { get; set; }
        public VMProperty Role { get; set; }

        public List<VMStation> AllowedStations { get; set; }

        public VMUser()
        {
            EmptyObject();
        }

        public VMUser(User user)
        {
            EmptyObject();

            if (user != null)
            {
                Id = user.UserId;
                ContactId = user.ContactId;
                Username = user.Username;
                IsActive = user.IsActive;

                Contact = new VMContact(user.Contact);

                if (user.Contact.Developers != null && user.Contact.Developers.Any(d => d.IsActive))
                {
                    Role = Roles.Developer.ToVMProperty();
                    AllowedStations = new List<VMStation>();
                }

                else if (user.Contact.SupportTechnicians != null && user.Contact.SupportTechnicians.Any(s => s.IsActive))
                {
                    Role = Roles.SupportTechnician.ToVMProperty();
                    AllowedStations =
                        user.Contact.SupportTechnicians
                        .First(s => s.IsActive).Zone.Stations
                        .Where(s => s.IsActive)
                        .Select(s => new VMStation(s))
                        .OrderBy(s => s.Number)
                        .ToList();
                }

                else if (user.Contact.Stations != null && user.Contact.Stations.Any(s => s.IsActive))
                {
                    Role = Roles.Supervisor.ToVMProperty();
                    AllowedStations =
                        user.Contact.Stations
                        .Where(s => s.IsActive)
                        .Select(s => new VMStation(s))
                        .OrderBy(s => s.Number)
                        .ToList();
                }

                else if (user.Contact.Stations1 != null && user.Contact.Stations1.Any(s => s.IsActive))
                {
                    Role = Roles.Station.ToVMProperty();
                    AllowedStations =
                        user.Contact.Stations1
                        .Where(s => s.IsActive)
                        .Select(s => new VMStation(s))
                        .OrderBy(s => s.Number)
                        .ToList();
                }
            }
        }

        private void EmptyObject()
        {
            Id = 0;
            ContactId = 0;
            Username = String.Empty;
            IsActive = false;

            Contact = null;
            Role = null;
        }
    }

    public enum Roles
    {
        [Description("No Definido")]
        Undefined = 0,
        [Description("Desarrollador")]
        Developer = 1,
        [Description("Soporte Técnico")]
        SupportTechnician = 2,
        [Description("Supervisor")]
        Supervisor = 3,
        [Description("Estación")]
        Station = 4
    }
}