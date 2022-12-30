using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLGeneratorLibrary
{
    public class HtmlGeneratorService : IHtmlGeneratorService
    {
        private const string customTagStart = "{{";
        private const string customTagEnd = "}}";

        public string GetHTMLMain(string template, object model)
        {
            //Пришли нулы
            if (string.IsNullOrEmpty(template))
                throw new ArgumentNullException("HtmlPage is null");
            if (!template.Contains($"{customTagStart}"))
                return template;
            if (model == null)
                throw new ArgumentNullException("Model is null");

            Type t = model.GetType();
            var args = t.GetProperties();

            var values = args.Select(value => $"{value.GetValue(model)}").ToArray();
            var agrsTypes = args.Select(x => x.Name).ToArray();
            //type : value
            var modelDict = new Dictionary<string, string> { };

            for (int i = 0; i < values.Length; i++)
            {
                modelDict.Add(agrsTypes[i], values[i]);
            }

            foreach (var modelItem in modelDict)
            {
                var temp = new string($"{customTagStart}{modelItem.Key}{customTagEnd}");
                template = template.Replace($"{customTagStart}{modelItem.Key}{customTagEnd}", modelItem.Value);
            }

            return template;
        }
        public string GetHTML(string template, object model)
        {
            return GetHTMLMain(template, model);
        }

        public string GetHTML(Stream stream, object model)
        {
            string template = StreamToString(stream);
            return GetHTMLMain(template, model);
        }

        public string GetHTML(byte[] bytes, object model)
        {
            string template = Encoding.ASCII.GetString(bytes);
            return GetHTMLMain(template, model);
        }

        public byte[] GetHTMLToByte(string template, object model)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(GetHTMLMain(template, model));
            return bytes;
        }

        public byte[] GetHTMLToByte(Stream stream, object model)
        {
            string template = StreamToString(stream);
            return GetHTMLToByte(template, model);
        }

        public byte[] GetHTMLToByte(byte[] bytes, object model)
        {
            string template = Encoding.ASCII.GetString(bytes);
            return GetHTMLToByte(template, model);
        }

        public Stream GetHTMLToStream(string template, object model)
        {
            Stream stream = StringToStream(GetHTMLMain(template, model));
            return stream;

        }

        public Stream GetHTMLToStream(Stream stream, object model)
        {
            string template = StreamToString(stream);
            return StringToStream(GetHTMLMain(template, model));
        }

        public Stream GetHTMLToStream(byte[] bytes, object model)
        {
            string template = System.Text.Encoding.UTF8.GetString(bytes);
            return StringToStream(GetHTMLMain(template, model));
        }
        public static Stream StringToStream(string s)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(s);
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;
        }
        public static String StreamToString(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string str = reader.ReadToEnd();
            return str;
        }
    }
}
