using System;

using R5T.L0062.T000;
using R5T.L0062.T000.Extensions;
using R5T.T0131;


namespace R5T.S0082
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker
    {
        public IIdentityString Default_IdentityString => "T:default".ToIdentityString();

        /// <summary>
        /// "&lt;inheritdoc"
        /// <para>
        /// Used to determine if some text contains the inheritdoc XML element.
        /// It needs the leading open angle bracket to distinguish from self-referential inheritdoc and escaped inheritdoc ("&amp;lt;inheritdoc...") situations.
        /// </para>
        /// <para>Note: Does not include the trailing close angle bracket since there will usually be cref and path attributes.</para>
        /// </summary>
        public string InheritDocXmlElementMarker => "<inheritdoc";
    }
}
