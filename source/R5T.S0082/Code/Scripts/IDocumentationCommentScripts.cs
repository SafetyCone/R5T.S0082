using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0159;
using R5T.T0172.Extensions;
using R5T.T0181.Extensions;
using R5T.T0212.F000;
using R5T.T0246;


namespace R5T.S0082
{
    [ScriptsMarker]
    public partial interface IDocumentationCommentScripts : IScriptsMarker
    {
        /// <summary>
        /// Get the processed documentation comments for a project.
        /// (Includes recursive project definitions, so missing names should only come from NuGet packages and base libraries.)
        /// </summary>
        public async Task Get_ProjectDocumentationComments()
        {
            /// Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.F0000\source\R5T.F0000\R5T.F0000.csproj".ToProjectFilePath();
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;
            var outputFilePath2 = Instances.FilePaths.OutputTextFilePath_Secondary;
            var errorsFilePath = Instances.FilePaths.OutputErrorsTextFilePath;


            /// Run.
            var missingDocumentationReferences = new List<MissingDocumentationReference>();

            var rawDocumentationCommentsByIdentityName = await Instances.DocumentationCommentOperations.Get_DocumentationComments_Recursive_Raw(
                projectFilePath);

            Instances.MemberDocumentationOperator.Describe_ToFile_Synchronous(
                outputFilePath2.ToTextFilePath(),
                rawDocumentationCommentsByIdentityName);

            Instances.NotepadPlusPlusOperator.Open(outputFilePath2);

            var documentationCommentsByIdentityName = await Instances.DocumentationCommentOperations.Get_DocumentationComments(
                projectFilePath,
                TextOutput.Null,
                missingDocumentationReferences);

            var lines = Instances.MemberDocumentationOperator.Describe(documentationCommentsByIdentityName.Values);

            Instances.NotepadPlusPlusOperator.WriteLinesAndOpen(
                outputFilePath,
                lines);

            lines = Instances.EnumerableOperator.AlternateWith(
                Instances.MissingDocumentationReferenceOperator.Describe(missingDocumentationReferences),
                String.Empty);

            Instances.NotepadPlusPlusOperator.WriteLinesAndOpen(
                errorsFilePath,
                lines);
        }

        /// <summary>
        /// Get the processed documentation comments for a single project.
        /// There should be many unrecognized names (since there will be lots of references to members from recursive project references).
        /// </summary>
        public async Task Get_SingleProjectDocumentationComments()
        {
            /// Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.F0000\source\R5T.F0000\R5T.F0000.csproj".ToProjectFilePath();
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;
            var errorsFilePath = Instances.FilePaths.OutputErrorsTextFilePath;


            /// Run.
            var missingDocumentationReferences = new List<MissingDocumentationReference>();

            var documentationCommentsByIdentityName = await Instances.DocumentationCommentOperations.Get_DocumentationComments_NonRecursive(
                projectFilePath,
                TextOutput.Null,
                missingDocumentationReferences);

            var lines = Instances.MemberDocumentationOperator.Describe(documentationCommentsByIdentityName.Values);

            Instances.NotepadPlusPlusOperator.WriteLinesAndOpen(
                outputFilePath,
                lines);

            lines = Instances.EnumerableOperator.AlternateWith(
                Instances.MissingDocumentationReferenceOperator.Describe(missingDocumentationReferences),
                String.Empty);

            Instances.NotepadPlusPlusOperator.WriteLinesAndOpen(
                errorsFilePath,
                lines);
        }

        /// <summary>
        /// Just get the raw documentation comments for all recursive projects.
        /// </summary>
        public async Task Get_RawProjectDocumentationComments()
        {
            /// Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.F0000\source\R5T.F0000\R5T.F0000.csproj".ToProjectFilePath();
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var documentationCommentsByIdentityName = await Instances.DocumentationCommentOperations.Get_DocumentationComments_Recursive_Raw(
                projectFilePath);

            var lines = Instances.MemberDocumentationOperator.Describe(documentationCommentsByIdentityName.Values);

            Instances.NotepadPlusPlusOperator.WriteLinesAndOpen(
                outputFilePath,
                lines);
        }
    }
}
