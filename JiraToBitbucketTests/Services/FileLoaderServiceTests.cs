using System.IO;
using JiraToBitBucket.Services;
using NUnit.Framework;
using Shouldly;

namespace JiraToBitbucketTests.Services
{
    [TestFixture]
    public class FileLoaderServiceTests
    {
        private static FileLoaderService buildFileLoaderService(bool valid)
        {
            return valid ? 
                new FileLoaderService("C:/Users/marc.costello/Documents/Visual Studio 2012/Projects/JiraToBitBucket/jira_export.xml") :
                new FileLoaderService("C:/Users/marc.costello/Documents/Visual Studio 2012/Projects/JiraToBitBucket/doesntexist.xml");
        }

        [Test]
        public static void FileIsValid_ShouldLocateFileFromPathString()
        {
            var loader = buildFileLoaderService(true);

            loader.FileIsValid().ShouldBe(true);
        }

        [Test]
        public static void FileIsValid_ShouldReturnFalseIfFileCannotBeFound()
        {
            var loader = buildFileLoaderService(false);

            loader.FileIsValid().ShouldBe(false);
        }

        [Test]
        public static void FileIsValid_ThrowExceptionIfFileIsNotXMLFormat()
        {
            var loader = new FileLoaderService("C:/Users/marc.costello/Documents/Visual Studio 2012/Projects/JiraToBitBucket/jira_export.txt");

            Should.Throw<FileLoadException>(() => loader.FileIsValid());
        }

        [Test]
        public static void LoadFile_ThrowExceptionIfXMLFileIsNotARecocognisedExportFromJira()
        {
            var loader = new FileLoaderService("C:/Users/marc.costello/Documents/Visual Studio 2012/Projects/JiraToBitBucket/jira_export_invalid.xml");

            Should.Throw<FileLoadException>(() => loader.LoadFile());
        }

        [Test]
        public static void LoadFile_StreamShouldReadTheData()
        {
            var loader = buildFileLoaderService(true);

            loader.LoadFile();

            loader.XmlData.ShouldNotBeEmpty();
            loader.XmlData.ShouldEndWith("</entity-engine-xml>");
        }

        [Test]
        public static void LoaderHasAFileInfoPropertyFromPathString()
        {
            var loader = buildFileLoaderService(true);

            loader.JiraXmlFile.ShouldBeTypeOf<FileInfo>();
            loader.JiraXmlFile.ShouldNotBe(null);
        }
    }
}
