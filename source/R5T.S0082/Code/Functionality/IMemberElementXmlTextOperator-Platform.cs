using System;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.S0082.Platform
{
    [FunctionalityMarker]
    public partial interface IMemberElementXmlTextOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Converts the member element XML text into an XElement.
        /// </summary>
        public XElement ToMemberElement(string memberElementXmlText)
        {
            var output = Instances.XElementOperator.Create_Element(
                memberElementXmlText,
                // Very important to preserve all whitespace (since formatting of the member element might matter).
                LoadOptions.PreserveWhitespace);

            return output;
        }
    }
}
