using System;
using EcoHelp.Utilities;

namespace EcoHelp.BusinessLogic.ViewModels
{
    public class VMProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public VMProperty()
        {
            EmptyObject();
        }

        /// <summary>
        /// Constructor that creates a View Model based of an Enum object
        /// </summary>
        /// <param name="enumValue">Fills enum to View Model</param>
        public VMProperty(Enum enumValue)
        {
            EmptyObject();

            if (enumValue != null)
            {
                Id = Convert.ToInt32(enumValue);
                Name = enumValue.GetDescription();
            }
        }

        /// <summary>
        /// Method to set all values to default
        /// </summary>
        private void EmptyObject()
        {
            Id = 0;
            Name = String.Empty;
        }
    }

    public static partial class Extensions
    {
        /// <summary>
        /// Method to convert an Enum object to view model object
        /// </summary>
        /// <param name="enumValue">Fills data to View Model</param>
        /// <returns></returns>
        public static VMProperty ToVMProperty(this Enum enumValue)
        {
            VMProperty vmProperty = enumValue != null ? new VMProperty(enumValue) : null;
            return vmProperty;
        }
    }
}