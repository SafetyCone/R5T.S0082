using System;


namespace R5T.S0082
{
    public class MemberElementXmlTextOperator : IMemberElementXmlTextOperator
    {
        #region Infrastructure

        public static IMemberElementXmlTextOperator Instance { get; } = new MemberElementXmlTextOperator();


        private MemberElementXmlTextOperator()
        {
        }

        #endregion
    }
}


namespace R5T.S0082.Platform
{
    public class MemberElementXmlTextOperator : IMemberElementXmlTextOperator
    {
        #region Infrastructure

        public static IMemberElementXmlTextOperator Instance { get; } = new MemberElementXmlTextOperator();


        private MemberElementXmlTextOperator()
        {
        }

        #endregion
    }
}
