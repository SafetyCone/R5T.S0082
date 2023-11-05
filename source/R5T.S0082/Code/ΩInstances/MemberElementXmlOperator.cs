using System;


namespace R5T.S0082
{
    public class MemberElementXmlOperator : IMemberElementXmlOperator
    {
        #region Infrastructure

        public static IMemberElementXmlOperator Instance { get; } = new MemberElementXmlOperator();


        private MemberElementXmlOperator()
        {
        }

        #endregion
    }
}
