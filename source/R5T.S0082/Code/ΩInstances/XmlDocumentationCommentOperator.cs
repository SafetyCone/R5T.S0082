using System;


namespace R5T.S0082
{
    public class XmlDocumentationCommentOperator : IXmlDocumentationCommentOperator
    {
        #region Infrastructure

        public static IXmlDocumentationCommentOperator Instance { get; } = new XmlDocumentationCommentOperator();


        private XmlDocumentationCommentOperator()
        {
        }

        #endregion
    }
}


namespace R5T.S0082.Platform
{
    public class XmlDocumentationCommentOperator : IXmlDocumentationCommentOperator
    {
        #region Infrastructure

        public static IXmlDocumentationCommentOperator Instance { get; } = new XmlDocumentationCommentOperator();


        private XmlDocumentationCommentOperator()
        {
        }

        #endregion
    }
}
