using System;
using System.ComponentModel;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.BusinessLogic.ViewModels
{
    public class VMStation
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public int SupervisorContactId { get; set; }
        public int StationContactId { get; set; }
        public int BusinessNameId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public VMZone Zone { get; set; }
        public VMContact SupervisorContact { get; set; }
        public VMContact StationContact { get; set; }
        public VMBusinessName BusinessName { get; set; }

        public VMStation()
        {
            EmptyObject();
        }

        public VMStation(Station station)
        {
            EmptyObject();

            if (station != null)
            {
                Id = station.StationId;
                ZoneId = station.ZoneId;
                SupervisorContactId = station.SupervisorContactId;
                StationContactId = station.StationContactId;
                BusinessNameId = station.BusinessNameId;
                Number = station.Number;
                Name = station.Name;
                IsActive = station.IsActive;

                Zone = new VMZone(station.Zone);
                SupervisorContact = new VMContact(station.Contact);
                StationContact = new VMContact(station.Contact1);
                BusinessName = new VMBusinessName(station.BusinessName);
            }
        }

        private void EmptyObject()
        {
            Id = 0;
            ZoneId = 0;
            SupervisorContactId = 0;
            StationContactId = 0;
            BusinessNameId = 0;
            Number = 0;
            Name = String.Empty;
            IsActive = false;

            Zone = null;
            SupervisorContact = null;
            StationContact = null;
            BusinessName = null;
        }
    }
}