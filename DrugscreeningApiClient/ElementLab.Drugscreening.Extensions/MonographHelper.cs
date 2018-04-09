// **********************************************************************************************\
// Module Name:  MonographHelper.cs
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
    /// <summary>
    /// ������ ��� ������������� XML-���������� � HTML
    /// </summary>
    public static class MonographHelper
    {
        static readonly Lazy<XslCompiledTransform> _xslt = new Lazy<XslCompiledTransform>(() => LoadStylesheet(), true);
        static XslCompiledTransform _customStylesheet;

        static XslCompiledTransform MonographStylesheet => _customStylesheet ?? _xslt.Value;

        /// <summary>
        /// ������������� XSLT-������, ������������ ��� ������������ �������� � ������� HTML
        /// </summary>
        /// <param name="stylesheet">XSLT-������</param>
        public static void UseCustomStylesheet(XslCompiledTransform stylesheet)
        {
            _customStylesheet = stylesheet;
        }

        /// <summary>
        /// ���������� ����� ����������������� �������� � ������� HTML
        /// </summary>
        /// <param name="result">��������� ���������</param>
        /// <param name="uniquePrefix"></param>
        /// <returns>���������� ����������������� �������� � ������� HTML</returns>
        public static string GetProfessionalMonographHtml(this ProfessionalResult result, string uniquePrefix = null)
        {
            if (string.IsNullOrWhiteSpace(uniquePrefix))
                uniquePrefix = Guid.NewGuid().ToString("N");
            return GetMonographHtml(result.ProfessionalMonograph, uniquePrefix);
        }

        /// <summary>
        /// ���������� ����� ������������ �������� � ������� HTML.
        /// </summary>
        /// <param name="result">��������� ���������</param>
        /// <returns>���������� ������������ �������� � ������� HTML</returns>
        public static string GetPatientMonographHtml(this PatientResult result, string uniquePrefix = null)
        {
            if (string.IsNullOrWhiteSpace(result.PatientMonograph))
                return null;

            if (string.IsNullOrWhiteSpace(uniquePrefix))
                uniquePrefix = Guid.NewGuid().ToString("N");
            return GetMonographHtml(result.PatientMonograph, uniquePrefix);
        }

        /// <summary>
        /// ����������� ���������� �� XML � HTML
        /// </summary>
        /// <param name="xml">���������� � ������� XML</param>
        /// <param name="uniqueId">���������� ������������� ����������</param>
        /// <returns>���������� � ������� HTML</returns>
        static string GetMonographHtml(string xml, string uniqueId)
        {
            if (string.IsNullOrWhiteSpace(xml))
                xml = "<monograph></monograph>";

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            string html;
            using (var htmlStream = new StringWriter())
            {
                var args = new XsltArgumentList();
                args.AddParam(nameof(Monograph.documentuniqueid), string.Empty, uniqueId);
                args.AddParam(nameof(Monograph.managementlevelstitle), string.Empty, Monograph.managementlevelstitle);
                args.AddParam(nameof(Monograph.severitylevelstitle), string.Empty, Monograph.severitylevelstitle);
                args.AddParam(nameof(Monograph.documentationlevelstitle), string.Empty, Monograph.documentationlevelstitle);
                args.AddParam(nameof(Monograph.onsetstitle), string.Empty, Monograph.onsetstitle);
                args.AddParam(nameof(Monograph.placentaltransferstitle), string.Empty, Monograph.placentaltransferstitle);
                args.AddParam(nameof(Monograph.breastfeedingaapstitle), string.Empty, Monograph.breastfeedingaapstitle);
                args.AddParam(nameof(Monograph.breastfeedingratingstitle), string.Empty, Monograph.breastfeedingratingstitle);
                args.AddParam(nameof(Monograph.breastfeedingexcretedstitle), string.Empty, Monograph.breastfeedingexcretedstitle);
                args.AddParam(nameof(Monograph.alerttitle), string.Empty, Monograph.alerttitle);
                args.AddParam(nameof(Monograph.effecttitle), string.Empty, Monograph.effecttitle);
                args.AddParam(nameof(Monograph.mechanismtitle), string.Empty, Monograph.mechanismtitle);
                args.AddParam(nameof(Monograph.managementtitle), string.Empty, Monograph.managementtitle);
                args.AddParam(nameof(Monograph.discussiontitle), string.Empty, Monograph.discussiontitle);
                args.AddParam(nameof(Monograph.commenttitle), string.Empty, Monograph.commenttitle);
                args.AddParam(nameof(Monograph.whattitle), string.Empty, Monograph.whattitle);
                args.AddParam(nameof(Monograph.whytitle), string.Empty, Monograph.whytitle);
                args.AddParam(nameof(Monograph.instructionstitle), string.Empty, Monograph.instructionstitle);
                args.AddParam(nameof(Monograph.drugstitle), string.Empty, Monograph.drugstitle);
                args.AddParam(nameof(Monograph.referencestitle), string.Empty, Monograph.referencestitle);

                MonographStylesheet.Transform(xmlDoc, args, htmlStream);
                htmlStream.Flush();
                html = htmlStream.ToString();
            }
            return html;
        }

        static XslCompiledTransform LoadStylesheet()
        {
            XslCompiledTransform xslt;
            using (var ms = new StringReader(Monograph.Stylesheet))
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