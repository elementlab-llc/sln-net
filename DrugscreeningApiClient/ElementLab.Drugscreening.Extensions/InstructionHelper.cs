// **********************************************************************************************\
// Module Name:  InstructionHelper.cs
// Project:      ElementLab.Drugscreening.Extensions 
// 
// Copyright (c) Element Lab LLC
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// **********************************************************************************************/
// 

using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using ElementLab.Drugscreening.Contracts;

namespace ElementLab.Drugscreening
{
    public static class InstructionHelper
    {
        static readonly Lazy<XslCompiledTransform> _xslt = new Lazy<XslCompiledTransform>(() => LoadStylesheet(), true);
        static XslCompiledTransform _customStylesheet;

        static XslCompiledTransform InstructionStylesheet => _customStylesheet ?? _xslt.Value;

        /// <summary>
        /// Устанавливает XSLT-шаблон, используемый для формирования реферата в формате HTML
        /// </summary>
        /// <param name="stylesheet">XSLT-шаблон</param>
        public static void UseCustomStylesheet(XslCompiledTransform stylesheet)
        {
            _customStylesheet = stylesheet;
        }

        /// <summary>
        /// Возвращает содержимое инструкции в формате HTML
        /// </summary>
        /// <param name="content">Объект, описывающий содержимое инструкции</param>
        /// <param name="uniqueId">Префикс, добавляемый ко всем ссылкам для их уникальности</param>
        /// <returns>Инструкция в формате HTML</returns>
        public static string GetContentAsHtml(this InstructionContent content, string uniqueId = null)
        {
            var xml = content.Content;
            if (string.IsNullOrWhiteSpace(xml))
                return null;

            if (string.IsNullOrWhiteSpace(uniqueId))
                uniqueId = Guid.NewGuid().ToString("N");

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            string html;
            using (var htmlStream = new StringWriter())
            {
                var args = new XsltArgumentList();
                args.AddParam(nameof(Monograph.documentuniqueid), string.Empty, uniqueId);

                InstructionStylesheet.Transform(xmlDoc, args, htmlStream);
                htmlStream.Flush();
                html = htmlStream.ToString();
            }
            return html;
        }

        static XslCompiledTransform LoadStylesheet()
        {
            XslCompiledTransform xslt;
            using (var ms = new StringReader(Instruction.Stylesheet))
            {
                using (var xr = XmlReader.Create(ms))
                {
                    xslt = new XslCompiledTransform();
                    xslt.Load(xr);
                }
            }
            return xslt;
        }
    }
}
