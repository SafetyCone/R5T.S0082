using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using R5T.T0141;
using R5T.T0181;


namespace R5T.S0082
{
    [ExperimentsMarker]
    public partial interface IExperiments : IExperimentsMarker
    {
        /// <summary>
        /// The XML documentation files for the .NET framework are subtly different than those produced by Visual Studio compilation.
        /// The .NET framework documentation files use 2-space tabs instead of 4-space tabs.
        /// </summary>
        public void Reformat_IllFormattedMember_NetFramework()
        {
            /// Inputs.
            var memberXmlText = Instances.MemberElementXmlTexts.RawNetFrameworkFileFormatting;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var memberElement = Instances.MemberElementOperator.Parse(memberXmlText);

            Instances.MemberElementOperator.Reformat_IllFormattedElement(memberElement);

            var text = Instances.MemberElementOperator.ToString(memberElement);

            Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
                outputFilePath,
                text);
        }

        public void Reformat_IllFormattedMember()
        {
            /// Inputs.
            var memberXmlText = Instances.MemberElementXmlTexts.RawFileFormatting;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var memberElement = Instances.MemberElementOperator.Parse(memberXmlText);

            Instances.MemberElementOperator.Reformat_IllFormattedElement(memberElement);

            var text = Instances.MemberElementOperator.ToString(memberElement);

            Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
                outputFilePath,
                text);
        }

        public async Task RoundTrip_Member_AsFile()
        {
            /// Inputs.
            var memberXmlText = Instances.MemberElementXmlTexts.RawFileFormatting;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var memberElement = Instances.MemberElementOperator.Parse(memberXmlText);

            await Instances.MemberElementOperator.Save(
                outputFilePath,
                memberElement);

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath);
        }

        /// <summary>
        /// <para>
        /// Result: FAIL. The XElement.Save() method adds the XML declaration.
        /// </para>
        /// </summary>
        public void RoundTrip_Member_AsText()
        {
            /// Inputs.
            var memberXmlText = Instances.MemberElementXmlTexts.RawFileFormatting;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var memberElement = Instances.MemberElementOperator.Parse(memberXmlText);

            //var stringBuilder = new StringBuilder();

            //var xmlWriterSettings = new XmlWriterSettings()
            //{
            //    ConformanceLevel = ConformanceLevel.Fragment,
            //    //Indent = false,
            //    //NewLineHandling = NewLineHandling.None,
            //    // Not needed if conformance level is fragment.
            //    //OmitXmlDeclaration = true,
            //};

            //using (var xmlWriter = XmlWriter.Create(stringBuilder, xmlWriterSettings))
            //{
            //    memberElement.Value.WriteTo(xmlWriter);
            //}

            //var text = stringBuilder.ToString();

            var text = Instances.MemberElementOperator.ToString(memberElement);

            Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
                outputFilePath,
                text);
        }

        /// <summary>
        /// Use the standard de/serialization methodology.
        /// </summary>
        public async Task RoundTrip_Document()
        {
            // Inputs.
            var documentationFileXmlText = Instances.DocumentationFileXmlTexts.R5T_T0211;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            // Use the standard deserialization (which preserves whitespace).
            var documentationDocument = Instances.DocumentationFileOperator.Parse(documentationFileXmlText);

            // Use the standard serialization (which preserves whitespace).
            await Instances.DocumentationFileOperator.Save(
                outputFilePath,
                documentationDocument);

            Instances.NotepadPlusPlusOperator.Open(outputFilePath);
        }

        /// <summary>
        /// Use the standard string-based de/serialization methodology.
        /// </summary>
        public void RoundTrip_Document_ToString()
        {
            // Inputs.
            var documentationFileXmlText = Instances.DocumentationFileXmlTexts.R5T_T0211;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            // Use the standard deserialization (which preserves whitespace).
            var documentationDocument = Instances.DocumentationFileOperator.Parse(documentationFileXmlText);

            // Use the standard serialization (which preserves whitespace).
            var text = Instances.DocumentationFileOperator.ToString(documentationDocument);

            Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
                outputFilePath,
                text);
        }

        /// <summary>
        /// Explore what using the <see cref="SaveOptions.DisableFormatting"/> value does.
        /// <para>
        /// Result: same as for <see cref="RoundTrip_Document_SaveOptionsNone"/>
        /// </para>
        /// </summary>
        public async Task RoundTrip_Document_SaveOptionsDisableFormatting()
        {
            /// Inputs.
            var documentationFileXmlText = Instances.DocumentationFileXmlTexts.R5T_T0211;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            // Use the standard deserialization (which preserves whitespace).
            var documentationDocument = Instances.DocumentationFileOperator.Parse(documentationFileXmlText);

            using var fileStream = Instances.FileStreamOperator.NewWrite(outputFilePath);
            using var writer = new StreamWriter(fileStream);

            await documentationDocument.Value.SaveAsync(
                writer,
                SaveOptions.DisableFormatting,
                CancellationToken.None);

            Instances.NotepadPlusPlusOperator.Open(outputFilePath);
        }

        /// <summary>
        /// Explore what using the <see cref="SaveOptions.None"/> value does.
        /// <para>
        /// Result: ok.
        /// The declaration includes an encoding attribute, but otherwise formatting is as it should be.
        /// </para>
        /// </summary>
        public async Task RoundTrip_Document_SaveOptionsNone()
        {
            /// Inputs.
            var documentationFileXmlText = Instances.DocumentationFileXmlTexts.R5T_T0211;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            // Use the standard deserialization (which preserves whitespace).
            var documentationDocument = Instances.DocumentationFileOperator.Parse(documentationFileXmlText);

            using var fileStream = Instances.FileStreamOperator.NewWrite(outputFilePath);
            using var writer = new StreamWriter(fileStream);

            await documentationDocument.Value.SaveAsync(
                writer,
                SaveOptions.None,
                CancellationToken.None);

            Instances.NotepadPlusPlusOperator.Open(outputFilePath);
        }

        /// <summary>
        /// What if we do the same as <see cref="Get_IllFormattedMember_FromDocument"/>, but using alternative de/serialization architecture?
        /// <para>
        /// Result: N/A. No other de/serialization architecture should be used.
        /// </para>
        /// </summary>
        public void Get_IllFormattedMember_FromDocument_Experiment02()
        {
            ///// Inputs.
            //var documentationFileXmlText = Instances.DocumentationFileXmlTexts.R5T_T0211;
            //var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            ///// Run.
            //var xmlReaderSettings = new XmlReaderSettings();

            //var xmlReader = XmlReader.Create()
            //XDocument.LoadAsync()

            //var documentationDocument = XDocument.Parse(
            //    documentationFileXmlText.Value);

            //var documentationElement = Instances.DocumentationFileXmlOperator.Get_DocumentationElement(documentationDocument);

            //var firstMemberElement = Instances.DocumentationElementXmlOperator.Get_MemberElements(documentationElement).First();

            //var text = firstMemberElement.ToString();

            //Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
            //    outputFilePath,
            //    text);
        }

        /// <summary>
        /// What if we do the same as <see cref="Get_IllFormattedMember_FromDocument"/>, but without preserving whitespace when parsing?
        /// <para>
        /// Result: wierd. There is a distinct difference between parsing from an XElement and parsing from an XDocument, then selecting an element.
        /// The output text has no indentation on the first line, but then two spaces on the second line. (This is unexpected.)
        /// The text of the first element has the documentation file's indentation (which is expected, since the file's formatting indentation gets co-mingled with the text value's indentation).
        /// But somehow the trailing closing &lt;/member&gt; tag is on its own line? (This is unexpected.)
        /// </para>
        /// </summary>
        public void Get_IllFormattedMember_FromDocument_Experiment01()
        {
            /// Inputs.
            var documentationFileXmlText = Instances.DocumentationFileXmlTexts.R5T_T0211;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var documentationDocument = XDocument.Parse(
                documentationFileXmlText.Value);

            var documentationElement = Instances.DocumentationFileXmlOperator.Get_DocumentationElement(documentationDocument);

            var firstMemberElement = Instances.DocumentationElementXmlOperator.Get_MemberElements(documentationElement).First();

            var text = firstMemberElement.ToString();

            Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
                outputFilePath,
                text);
        }

        /// <summary>
        /// Start with the full documentation file, and select a member.
        /// <para>
        /// Result: success. The output text has no indentation on the first line, then the document indentaion on all following lines.
        /// Note that the trailing closing &lt;/member&gt; tag is on its own line.
        /// </para>
        /// </summary>
        public void Get_IllFormattedMember_FromDocument()
        {
            /// Inputs.
            var documentationFileXmlText = Instances.DocumentationFileXmlTexts.R5T_T0211;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var documentationDocument = XDocument.Parse(
                documentationFileXmlText.Value,
                LoadOptions.PreserveWhitespace);

            var documentationElement = Instances.DocumentationFileXmlOperator.Get_DocumentationElement(documentationDocument);

            var firstMemberElement = Instances.DocumentationElementXmlOperator.Get_MemberElements(documentationElement).First();

            var text = firstMemberElement.ToString();

            Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
                outputFilePath,
                text);
        }

        /// <summary>
        /// What happens if we do the same thing as <see cref="Get_IllFormattedComment"/>, but without preserving whitespace when parsing?
        /// <para>
        /// Result: Kinda success.
        /// This produces the same indentation behavior, however the trailing closing &lt;/member&gt; tag is not on its own line.
        /// </para>
        /// </summary>
        public void Get_IllFormattedComment_Experiment01()
        {
            /// Inputs.
            var memberXmlText = Instances.MemberElementXmlTexts.RawFileFormatting;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var element = XElement.Parse(
                memberXmlText.Value);

            var text = element.ToString();

            Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
                outputFilePath,
                text);
        }

        /// <summary>
        /// I want to have an example of the case where formatting messes with 
        /// <para>
        /// Result: Success!
        /// This code produces a text that has no indentation on the first line, but then the raw XML documentation file indentation for all following lines.
        /// Note that the trailing closing &lt;/member&gt; tag is on its own line.
        /// </para>
        /// </summary>
        public void Get_IllFormattedComment()
        {
            /// Inputs.
            var memberXmlText = Instances.MemberElementXmlTexts.RawFileFormatting;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var element = XElement.Parse(
                memberXmlText.Value,
                LoadOptions.PreserveWhitespace);

            var text = element.ToString();

            Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
                outputFilePath,
                text);
        }
    }
}
