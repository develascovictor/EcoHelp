using EcoHelp.DataAccess.Model;

namespace EcoHelp.DataAccess.Repositories
{
    /// <summary>
    /// Connects to the Data Base
    /// </summary>
    public abstract class Repository
    {
        #region Properties
        /// <summary>
        /// Eco Help Entities DB Connection
        /// </summary>
        protected EcoHelpEntities Db { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Repository Constructor
        /// </summary>
        protected Repository()
        {
            Db = new EcoHelpEntities();
        }
        #endregion

        #region Destructor
        ~Repository()
        {

        }
        #endregion
    }
}