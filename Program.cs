using HTMLGenerator.models;
using HTMLGeneratorLibrary;
using System;

namespace HTMLGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string result = "Hello World";
            var user = new User(343, "loginnew", "passwordnew", 18, "8987858594", "boku no pico");

            string HtmlPage = "<html>\r\n<head>\r\n<title>Шапка</title>\r\n</head>\r\n<body>\r\n{{Id}}\r\n<p>Логин и пароль пользователя: <p>\r\n{{Login}}\r\n{{Password}}\r\n</body>\r\n</html>";

            var gs = new HtmlGeneratorService();
            var res = gs.GetHTMLMain(HtmlPage, user);

            var n = 0;
        }
    }
}
