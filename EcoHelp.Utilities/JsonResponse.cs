namespace EcoHelp.Utilities
{
    public class JsonResponse
    {
        #region Properties
        /// <summary>
        /// Since the JsonResponse could return a successful result or an error message, this determines if the operation was a success or not
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Content to be returned
        /// </summary>
        public object Content { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public JsonResponse()
        {
            Success = false;
            Content = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="success">Sets if operation was successful</param>
        /// <param name="content">Sets the content to be returned</param>
        public JsonResponse(bool success, object content)
        {
            Success = success;
            Content = content;
        }
        #endregion
    }
}