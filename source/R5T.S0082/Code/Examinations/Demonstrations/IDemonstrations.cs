using System;
using System.Linq;
using R5T.T0141;
using R5T.T0181.Extensions;
using R5T.T0212;


namespace R5T.S0082
{
    [DemonstrationsMarker]
    public partial interface IDemonstrations : IDemonstrationsMarker
    {
        /// <summary>
        /// Given a set of member documentations, process them by themselves.
        /// </summary>
        public void Process_MemberDocumentationSet_Inheritdoc()
        {
            /// Inputs.
            var memberDocumentationSet =
                //Instances.MemberDocumentationSets.Cyclic
                //Instances.MemberDocumentationSets.Cyclic_Pathological
                Instances.MemberDocumentationSets.Cyclic_Pathological_FromOutside
                ;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var humanOutputFilePath = Instances.FilePaths.HumanOutputTextFilePath;
            var logFilePath = Instances.FilePaths.LogFilePath;

            Instances.TextOutputOperator.InTextOutputContext_Synchronous(
                humanOutputFilePath,
                nameof(Process_MemberDocumentation_Inheritdoc),
                logFilePath,
                textOutput =>
                {
                    var processedMemberDocumentations = Instances.DocumentationCommentOperations.Expand_InheritdocElements(
                        textOutput,
                        out var missingDocumentationReferences,
                        memberDocumentationSet);

                    Instances.MemberDocumentationOperator.Describe_ToFile_Synchronous(
                        outputFilePath,
                        processedMemberDocumentations);
                });

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath,
                humanOutputFilePath,
                logFilePath);
        }

        /// <summary>
        /// Given a pathologically self-referential member documentation, process it in by itself.
        /// </summary>
        /// <remarks>
        /// A documentation comment can include an inheritdoc element with a self-referential path that, when evaluated, would include itself.
        /// This is a mistake, but mistakes can happen.
        /// </remarks>
        public void Process_MemberDocumentation_Inheritdoc_PathologicalSelfReferential()
        {
            /// Inputs.
            var memberDocumentation = Instances.MemberDocumentations_Raw.Pathological_A;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;
            var errorsFilePath = Instances.FilePaths.OutputErrorsTextFilePath;


            /// Run.
            var humanOutputFilePath = Instances.FilePaths.HumanOutputTextFilePath;
            var logFilePath = Instances.FilePaths.LogFilePath;

            Instances.TextOutputOperator.InTextOutputContext_Synchronous(
                humanOutputFilePath,
                nameof(Process_MemberDocumentation_Inheritdoc),
                logFilePath,
                textOutput =>
                {
                    var processedMemberDocumentation = Instances.DocumentationCommentOperations.Expand_InheritdocElements(
                        memberDocumentation,
                        textOutput,
                        out var missingDocumentationReferences);

                    Instances.MemberDocumentationOperator.Describe_ToFile_Synchronous(
                        outputFilePath,
                        processedMemberDocumentation);

                    Instances.MissingDocumentationReferenceOperator.Describe_ToFile_Synchronous(
                        errorsFilePath.ToTextFilePath(),
                        missingDocumentationReferences);
                });

            Instances.NotepadPlusPlusOperator.Open(
                logFilePath,
                humanOutputFilePath,
                errorsFilePath,
                outputFilePath);
        }

        /// <summary>
        /// Given a self-referential member documentation, process it in by itself.
        /// </summary>
        /// <remarks>
        /// Self-referential XML documentation comment appear frequently in glossary documentation.
        /// </remarks>
        public void Process_MemberDocumentation_Inheritdoc_SelfReferential()
        {
            /// Inputs.
            var memberDocumentation = Instances.MemberDocumentations.Self_Referential;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var humanOutputFilePath = Instances.FilePaths.HumanOutputTextFilePath;
            var logFilePath = Instances.FilePaths.LogFilePath;

            Instances.TextOutputOperator.InTextOutputContext_Synchronous(
                humanOutputFilePath,
                nameof(Process_MemberDocumentation_Inheritdoc),
                logFilePath,
                textOutput =>
                {
                    var processedMemberDocumentation = Instances.DocumentationCommentOperations.Expand_InheritdocElements(
                        memberDocumentation,
                        textOutput,
                        out var missingDocumentationReferences);

                    Instances.MemberDocumentationOperator.Describe_ToFile_Synchronous(
                        outputFilePath,
                        processedMemberDocumentation);
                });

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath,
                humanOutputFilePath,
                logFilePath);
        }

        /// <summary>
        /// Given a single member documentation process it in by itself.
        /// </summary>
        public void Process_MemberDocumentation_Inheritdoc()
        {
            /// Inputs.
            var memberDocumentation =
                Instances.MemberDocumentations.Self_Referential
                ;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var humanOutputFilePath = Instances.FilePaths.HumanOutputTextFilePath;
            var logFilePath = Instances.FilePaths.LogFilePath;

            Instances.TextOutputOperator.InTextOutputContext_Synchronous(
                humanOutputFilePath,
                nameof(Process_MemberDocumentation_Inheritdoc),
                logFilePath,
                textOutput =>
                {
                    var processedMemberDocumentation = Instances.DocumentationCommentOperations.Expand_InheritdocElements(
                        memberDocumentation,
                        textOutput,
                        out var missingDocumentationReferences);

                    Instances.MemberDocumentationOperator.Describe_ToFile_Synchronous(
                        outputFilePath,
                        processedMemberDocumentation);
                });

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath,
                humanOutputFilePath,
                logFilePath);
        }

        public void Write_MemberDocumentation_ToFile()
        {
            /// Inputs.
            var memberDocumentation = Instances.MemberDocumentations.Self_Referential;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            Instances.MemberDocumentationOperator.Describe_ToFile_Synchronous(
                outputFilePath,
                memberDocumentation);

            Instances.NotepadPlusPlusOperator.Open(outputFilePath);
        }

        /// <summary>
        /// Convert an XML documentation comment to a member element (XElement).
        /// </summary>
        public void Convert_ToMemberElement()
        {
            /// Inputs.
            var xmlDocumentationComment = Instances.XmlDocumentationComments.SummaryAndResult;
            var identityString = Instances.Values.Default_IdentityString;


            /// Run.
            var memberElement = Instances.XmlDocumentationCommentOperator.ToMemberElement_WithReformatting(
                xmlDocumentationComment,
                identityString);
            //var memberElement = Instances.XmlDocumentationCommentOperator.ToMemberElement_WithReformatting_Indented(
            //    xmlDocumentationComment,
            //    identityString);

            var memberElementXmlText = Instances.XElementOperator.To_Text_NoModifications(memberElement.Value);

            Console.WriteLine($"{xmlDocumentationComment}\n+\n{identityString}\n=>\n{memberElementXmlText}");
        }

        /// <summary>
        /// Convert an XML documentation comment to a member element XML text.
        /// </summary>
        public void Convert_ToMemberElementXmlText()
        {
            /// Inputs.
            var xmlDocumentationComment = Instances.XmlDocumentationComments.SummaryAndResult;
            var identityString = Instances.Values.Default_IdentityString;


            /// Run.
            var memberElementXmlText = Instances.XmlDocumentationCommentOperator.ToMemberElementXmlText(
                xmlDocumentationComment,
                identityString);

            Console.WriteLine($"{xmlDocumentationComment}\n+\n{identityString}\n=>\n{memberElementXmlText}");
        }

        /// <summary>
        /// Demonstration showing the function that tests whether an XML documentation comment needs expansion.
        /// </summary>
        public void Needs_Expansion()
        {
            var xmlDocumentationComments = new[]
            {
                Instances.XmlDocumentationComments.SummaryAndResult,
                Instances.XmlDocumentationComments.Contains_InheritdocElement,
                Instances.XmlDocumentationComments.Pathological_ContainsEscapedInheritdoc,
                Instances.XmlDocumentationComments.Pathological_ContainsSelfReferentialInheritdoc,
            };

            var results = xmlDocumentationComments
                .Select(xmlDocumentationComment =>
                {
                    var needsExpansion = Instances.XmlDocumentationCommentOperator.Needs_Expansion(xmlDocumentationComment);

                    return (xmlDocumentationComment, needsExpansion);
                })
                .Now();

            foreach (var (xmlDocumentationComment, needsExpansion) in results)
            {
                Console.WriteLine($"{xmlDocumentationComment}\n=> Expansion needed? {needsExpansion}\n");

                Console.WriteLine();
            }
        }
    }
}
