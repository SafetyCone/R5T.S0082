using System;


namespace R5T.S0082
{
    public class DocumentationCommentScripts : IDocumentationCommentScripts
    {
        #region Infrastructure

        public static IDocumentationCommentScripts Instance { get; } = new DocumentationCommentScripts();


        private DocumentationCommentScripts()
        {
        }

        #endregion
    }
}
