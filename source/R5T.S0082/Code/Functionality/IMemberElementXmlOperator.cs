using System;
using System.Linq;
using System.Xml.Linq;

using R5T.T0132;
using R5T.T0212;

namespace R5T.S0082
{
    [FunctionalityMarker]
    public partial interface IMemberElementXmlOperator : IFunctionalityMarker
    {
        public void RemoveAllChildWhitespaceOnlyTextNodes(IMemberElement memberElement)
        {
            var whitespaceOnlyChildTextNodes = Instances.XElementOperator.Enumerate_ChildNodesOfType<XText>(memberElement.Value)
                .Where(Instances.XTextOperator.Is_WhitespaceOnly)
                .Now();

            foreach (var textNode in whitespaceOnlyChildTextNodes)
            {
                textNode.Remove();
            }
        }

        public void PutAllChildElementsOnNewLine(IMemberElement memberElement)
        {
            // Assume XML documentation comment is composed of multiple top-level elements, with no indentation.
            var childElements = Instances.XElementOperator.Get_ChildElements(memberElement.Value);

            foreach (var childElement in childElements)
            {
                childElement.AddBeforeSelf(new XText(Environment.NewLine));
            }
        }

        public void IndentMemberContent(IMemberElement memberElement)
        {
            // Every newline in every text node becomes a newline+tab.
            var textNodes = Instances.XElementOperator.Get_DescendantNodesOfType<XText>(memberElement.Value);

            foreach (var textNode in textNodes)
            {
                var textNodeValue = textNode.Value;

                var newTextNodeValue = Instances.StringOperator.Replace(
                    textNodeValue,
                    Instances.Strings.NewLine_NonWindows + Instances.Strings.Tab,
                    Instances.Strings.NewLine_NonWindows);

                textNode.Value = newTextNodeValue;
            }
        }

        public void PutElementEndTagOnNewLine(IMemberElement memberElement)
        {
            // Put the member elment end tag on its own line.
            Instances.XElementOperator.Add_BeforeElementEndTag(
                memberElement.Value,
                new XText(Environment.NewLine));
        }

        /// <summary>
        /// Reformats the XML documentation comment content to the most useful format (no indentation in the XML documentation comment).
        /// </summary>
        public void Reformat_XmlDocumentationComment(IMemberElement memberElement)
        {
            var actions = new[]
            {
                this.RemoveAllChildWhitespaceOnlyTextNodes,
                this.PutAllChildElementsOnNewLine,
                this.PutElementEndTagOnNewLine
            };

            Instances.ActionOperator.Run(
                memberElement,
                actions);
        }

        /// <summary>
        /// Reformats the XML documentation comment content to the most pretty format (a tab worth of indentation in the XML documentation comment).
        /// </summary>
        public void Reformat_XmlDocumentationComment_Indented(IMemberElement memberElement)
        {
            var actions = new[]
            {
                this.RemoveAllChildWhitespaceOnlyTextNodes,
                this.PutAllChildElementsOnNewLine,
                this.IndentMemberContent,
                // Must come after indentint member content, else the end tag will be indented as well.
                this.PutElementEndTagOnNewLine
            };

            Instances.ActionOperator.Run(
                memberElement,
                actions);
        }
    }
}
