using System;
using System.Xml.Linq;
using R5T.T0132;


namespace R5T.S0082.Platform
{
    [FunctionalityMarker]
    public partial interface IXmlDocumentationCommentOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Determines if the XML documentation comment contains any reference elements that need expansion (for example, &lt;inheritdoc&gt; elements).
        /// </summary>
        /// <remarks>
        /// For now, just analyzes &lt;inheritdoc&gt; elements.
        /// </remarks>
        public bool Needs_Expansion(string xmlDocumentationComment)
        {
            var output = Instances.StringOperator.Contains(
                xmlDocumentationComment,
                Instances.Values.InheritDocXmlElementMarker);

            return output;
        }

        /// <summary>
        /// Wraps the XML documentation comment in a member XML element with a name attribute value given by the identity string.
        /// </summary>
        public string ToMemberElementXmlText(
            string xmlDocumentationComment,
            string identityString)
        {
            var output = $@"<member name =""{identityString}"">{xmlDocumentationComment}</member>";
            return output;
        }

        /// <summary>
        /// Wraps the XML documentation comment in a member XML element with a name attribute value given by the identity string, then converts the result to an <see cref="XElement"/>.
        /// </summary>
        public XElement ToMemberElement(
            string xmlDocumentationComment,
            string identityString)
        {
            var memberElementXmlText = this.ToMemberElementXmlText(
                xmlDocumentationComment,
                identityString);

            var output = Instances.MemberElementXmlTextOperator._Platform.ToMemberElement(memberElementXmlText);
            return output;
        }
    }
}
