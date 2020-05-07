namespace SjsApi.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Icon" />.
    /// </summary>
    public class Icon
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Group.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets the Color.
        /// </summary>
        public string Color { get; set; }
    }

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
        public Icon Icon { get; set; }

        /// <summary>
        /// Gets or sets the Link.
        /// </summary>
        public string Link { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="Media" />.
    /// </summary>
    public class Media
    {
        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="Media" />.
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public Media Image { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the FeatureSet.
        /// </summary>
        public string[] FeatureSet { get; set; }
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
        public Icon Icon { get; set; }

        /// <summary>
        /// Gets or sets the References.
        /// </summary>
        public IEnumerable<Reference> References { get; set; }

        /// <summary>
        /// Gets or sets the Media.
        /// </summary>
        public IEnumerable<Media> Media { get; set; }

        /// <summary>
        /// Gets or sets the Features.
        /// </summary>
        public IEnumerable<Feature> Features { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="ContentSection" />.
    /// </summary>
    public class ContentSection
    {
        /// <summary>
        /// Gets or sets the BackgroundImage.
        /// </summary>
        public Media BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Subtitle.
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the Heading.
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Projects.
        /// </summary>
        public IEnumerable<Project> Projects { get; set; }
    }
}
