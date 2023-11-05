using System;

using R5T.T0132;
using R5T.T0212;
using R5T.T0212.Extensions;


namespace R5T.S0082
{
    [FunctionalityMarker]
    public partial interface IMemberElementXmlTextOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Platform.IMemberElementXmlTextOperator _Platform => Platform.MemberElementXmlTextOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public IMemberElement ToMemberElement(IMemberElementXmlText memberElementXmlText)
        {
            var output = _Platform.ToMemberElement(memberElementXmlText.Value)
                .ToMemberElement();

            return output;
        }
    }
}
