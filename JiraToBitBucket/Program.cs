using System;
using System.IO;
using System.Linq;
using JiraToBitBucket.Models.Jira;
using JiraToBitBucket.Services;

namespace JiraToBitBucket
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            if (args.Length > 0)
            {
                path = args[0];
            }
            else
            {
                Console.Write("Enter absolute file path of the Jira xml file: ");
                path = Console.ReadLine();
            }
            
            try
            {
                BeginProcess(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.WriteLine("Export Complete.");
            Console.ReadKey();
        }

        private static void BeginProcess(string path)
        {
            var loader = new FileLoaderService(path).LoadFile();

            // TODO: Move parsing into the FileLoaderService - it's a bit overkill as a seperate process.
            var xmlDocument = new ParserService().Parse(loader.XmlData);

            var doc = new JiraDocument(xmlDocument);
            var converter = new JiraToBitbucketService(doc);

            var bitbucketDoc = converter.BuildBitbucketDocument();

            // Write out the Json result into a file
            string fileName = loader.JiraXmlFile.Name.Replace(".xml",".json");
            string jsonFilePath = loader.JiraXmlFile.Directory.FullName + "\\" + fileName;
            using (var jsonFile = new FileStream(jsonFilePath, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite))
            {
                using (var writer = new StreamWriter(jsonFile))
                {
                    writer.Write(bitbucketDoc.ToJson());
                }
            }
        }
    }
}
