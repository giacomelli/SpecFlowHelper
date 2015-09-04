using System;

namespace SpecFlowHelper.Integrations
{
    /// <summary>
    /// UrlOpening event args.
    /// </summary>
    public class UrlOpeningEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlOpeningEventArgs"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="relativeUrl">The relative URL.</param>
        public UrlOpeningEventArgs(string baseUrl, string relativeUrl)
        {
            BaseUrl = baseUrl;
            RelativeUrl = relativeUrl;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the relative URL.
        /// </summary>
        public string RelativeUrl { get; set; }
        #endregion
    }
}
