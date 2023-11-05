using System;

using R5T.L0062.T000;
using R5T.T0132;
using R5T.T0211;
using R5T.T0212;
using R5T.T0212.Extensions;


namespace R5T.S0082
{
    [FunctionalityMarker]
    public partial interface IXmlDocumentationCommentOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Platform.IXmlDocumentationCommentOperator _Platform => Platform.XmlDocumentationCommentOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Platform.IXmlDocumentationCommentOperator.Needs_Expansion(string)"/>
        public bool Needs_Expansion(IXmlDocumentationComment xmlDocumentationComment)
        {
            var output = _Platform.Needs_Expansion(xmlDocumentationComment.Value);
            return output;
        }

        /// <inheritdoc cref="Platform.IXmlDocumentationCommentOperator.ToMemberElementXmlText(string, string)"/>
        public IMemberElementXmlText ToMemberElementXmlText(
            IXmlDocumentationComment xmlDocumentationComment,
            IIdentityString identityString)
        {
            var output = _Platform.ToMemberElementXmlText(
                xmlDocumentationComment.Value,
                identityString.Value)
                .ToMemberElementXmlText();

            return output;
        }

        public IMemberElement ToMemberElement_WithoutReformatting(
            IXmlDocumentationComment xmlDocumentationComment,
            IIdentityString identityString)
        {
            var output = _Platform.ToMemberElement(
                xmlDocumentationComment.Value,
                identityString.Value)
                .ToMemberElement();

            return output;
        }

        public IMemberElement ToMemberElement_WithReformatting(
            IXmlDocumentationComment xmlDocumentationComment,
            IIdentityString identityString)
        {
            var output = this.ToMemberElement_WithoutReformatting(
                xmlDocumentationComment,
                identityString);

            Instances.MemberElementXmlOperator.Reformat_XmlDocumentationComment(output);

            return output;
        }

        public IMemberElement ToMemberElement_WithReformatting_Indented(
            IXmlDocumentationComment xmlDocumentationComment,
            IIdentityString identityString)
        {
            var output = this.ToMemberElement_WithoutReformatting(
                xmlDocumentationComment,
                identityString);

            Instances.MemberElementXmlOperator.Reformat_XmlDocumentationComment_Indented(output);

            return output;
        }
    }
}
