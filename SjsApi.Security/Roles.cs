namespace SjsApi.Security
{
    public static class Roles
    {
        public const string Administrator = "Administrator";
        public const string ContentEditor = "Content Editors";
        public const string ContentEditors = Administrator + "," + ContentEditor;
    }
}
