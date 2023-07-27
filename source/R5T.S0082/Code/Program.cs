using System;
using System.Threading.Tasks;


namespace R5T.S0082
{
    class Program
    {
        static async Task Main()
        {
            //await DocumentationCommentScripts.Instance.Get_RawProjectDocumentationComments();
            //await DocumentationCommentScripts.Instance.Get_SingleProjectDocumentationComments();
            //await DocumentationCommentScripts.Instance.Get_ProjectDocumentationComments();

            //Demonstrations.Instance.Write_MemberDocumentation_ToFile();
            //Demonstrations.Instance.Process_MemberDocumentation_Inheritdoc();
            //Demonstrations.Instance.Process_MemberDocumentation_Inheritdoc_SelfReferential();
            //Demonstrations.Instance.Process_MemberDocumentation_Inheritdoc_PathologicalSelfReferential();
            Demonstrations.Instance.Process_MemberDocumentationSet_Inheritdoc();


            //Experiments.Instance.Get_IllFormattedComment();
            //Experiments.Instance.Get_IllFormattedComment_Experiment01();
            //Experiments.Instance.Get_IllFormattedMember_FromDocument();
            //Experiments.Instance.Get_IllFormattedMember_FromDocument_Experiment01();
            //await Experiments.Instance.RoundTrip_Document_SaveOptionsNone();
            //await Experiments.Instance.RoundTrip_Document_SaveOptionsDisableFormatting();
            //Experiments.Instance.RoundTrip_Document_ToString();
            //await Experiments.Instance.RoundTrip_Document();
            //Experiments.Instance.RoundTrip_Member_AsText();
            //await Experiments.Instance.RoundTrip_Member_AsFile();
            //Experiments.Instance.Reformat_IllFormattedMember();
            //Experiments.Instance.Reformat_IllFormattedMember_NetFramework();
        }

        /// <summary>
        /// Test Test Test <inheritdoc cref="A" path="/summary"/>
        /// </summary>
        public string AX { get; set; }

        /// <summary>
        /// Test <inheritdoc cref="B" path="/summary"/>
        /// </summary>
        public string A { get; set; }

        /// <summary>
        /// Test <inheritdoc cref="C" path="/summary"/>
        /// </summary>
        public string B { get; set; }

        /// <summary>
        /// Test <inheritdoc cref="A" path="/summary"/>
        /// </summary>
        public string C { get; set; }

        /// <summary>
        /// Test <inheritdoc cref="Pathological_A" path="/summary"/>
        /// </summary>
        // Results in: "Test Test "
        public string Pathological_A { get; set; }

        /// <inheritdoc cref="Pathological_B"/>
        // Results in: "" (the empty string)
        public string Pathological_B { get; set; }
    }
}