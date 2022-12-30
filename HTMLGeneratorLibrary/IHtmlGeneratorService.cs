using System;
using System.IO;
using System.Threading.Tasks;

namespace HTMLGeneratorLibrary
{
    public interface IHtmlGeneratorService
    {
        string GetHTMLMain(string template, object model);
        //string GetHTML(Path pathTemplate, object model);
        string GetHTML(Stream stream, object model);
        string GetHTML(byte[] bytes, object model);
        Stream GetHTMLToStream(string template, object model);
        //Stream GetHTMLToStream(Path pathTemplate, object model);
        Stream GetHTMLToStream(Stream stream, object model);
        Stream GetHTMLToStream(byte[] bytes, object model);
        byte[] GetHTMLToByte(string template, object model);
        //byte[] GetHTMLToByte(Path pathTemplate, object model);
        byte[] GetHTMLToByte(Stream stream, object model);
        byte[] GetHTMLToByte(byte[] bytes, object model);
        //void SaveFileToDirectory(Path pathTemplate, Path outFilePath, object model);
        //Task SaveFileToDirectoryAsync(Path pathTemplate, Path outFilePath, object model);
    }
}
