using System;
using System.ComponentModel;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.BusinessLogic.ViewModels
{
    public class VMContact
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int SpeedDial { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }

        public VMContact()
        {
            EmptyObject();
        }

        public VMContact(Contact contact)
        {
            EmptyObject();

            if (contact != null)
            {
                Id = contact.ContactId;
                FullName = contact.FullName;
                SpeedDial = contact.SpeedDial;
                PhoneNumber = contact.PhoneNumber;
                EmailAddress = contact.EmailAddress;
                IsActive = contact.IsActive;
            }
        }

        private void EmptyObject()
        {
            Id = 0;
            FullName = String.Empty;
            SpeedDial = 0;
            PhoneNumber = String.Empty;
            EmailAddress = String.Empty;
            IsActive = false;
        }
    }
}