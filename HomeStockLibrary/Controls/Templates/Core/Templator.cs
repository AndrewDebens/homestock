﻿using HomeStockLibrary.Controls.Resources.Core;
using HomeStockLibrary.Exceptions;
using HomeStockLibrary.Util;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HomeStockLibrary.Controls.Templates.Core
{
    public class Templator
    {
        protected string template { get; set; }
        protected string content { get; set; }

        private Regex _propertyPattern = new Regex(@"{{(.*?)}}");
        private Regex propertyPattern { get; set; }

        public Templator(string template) { this.template = template; propertyPattern = _propertyPattern; }
        public Templator(string template, Regex propertyPattern) { this.template = template; this.propertyPattern = propertyPattern; }

        public static Templator Load(string templateFileName) {
            string template = ResourceLoader.LoadTempalte(templateFileName);
            return new Templator(template);
        }

        public Templator Process(object pattern)
        {
            return Process(pattern, propertyPattern);
        }

        public Templator Process(object pattern, Regex propertyPattern)
        {
            content = template;
            foreach (Match m in propertyPattern.Matches(content))
            {
                var propertyName = m.Groups[1].Value.Trim();
                content = content.Replace(m.Value, getValue(pattern, propertyName));
            }

            return this;
        }

        public override string ToString()
        {
            return content ?? template;
        }

        private string getValue(object pattern, string propertyName)
        {
            PropertyInfo property = pattern.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (property == null)
                throw new HomeStockPropertyException("Object pattern does not defined property '" + propertyName + "' found in template");

            // JSON not currently supported
            //string value = JsonAssistant.Convert(, property.GetType());

            return property.GetValue(pattern, null).ToString().Trim('"');
        }
    }
}
