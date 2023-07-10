using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0162;
using R5T.T0172.Extensions;
using R5T.T0212.F000;


namespace R5T.S0082
{
    [FunctionalityMarker]
    public partial interface IDocumentationCommentScripts : IFunctionalityMarker
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
            var errorsFilePath = Instances.FilePaths.OutputErrorsTextFilePath;


            /// Run.
            var missingDocumentationReferences = new List<MissingDocumentationReference>();

            var documentationCommentsByIdentityName = await Instances.DocumentationCommentOperations.Get_DocumentationComments(
                projectFilePath,
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
