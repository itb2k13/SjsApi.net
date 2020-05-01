namespace SjsApi.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Reference" />.
    /// </summary>
    public class Reference
    {
        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Icon.
        /// </summary>
        public string Icon { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="Media" />.
    /// </summary>
    public class Media
    {
        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the ImageTitle.
        /// </summary>
        public string Title { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="Project" />.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Subtitle.
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Icon.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the References.
        /// </summary>
        public IEnumerable<Reference> References { get; set; }

        /// <summary>
        /// Gets or sets the Media.
        /// </summary>
        public IEnumerable<Media> Media { get; set; }
    }
}
