using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiraToBitBucket.Models.Jira;
using JiraToBitBucket.Services;

namespace JiraToBitBucket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter absolute file path of the Jira xml export: ");
            var path = Console.ReadLine();

            var loader =
                new FileLoaderService(
                    "C:/Users/marc.costello/Documents/Visual Studio 2012/Projects/JiraToBitBucket/jira_export.xml");
            loader.LoadFile();
            var xmlDocument = new ParserService().Parse(loader.XmlData);
            var doc = new JiraDocument(xmlDocument);
            var converter = new JiraToBitbucketService(doc);
            var bitbucketDoc = converter.BuildBitbucketDocument();

            Console.WriteLine(bitbucketDoc.ToJson());

            Console.ReadKey();
        }
    }
}
