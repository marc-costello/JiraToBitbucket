using System;
using System.IO;
using System.Text;
using System.Xml;

namespace JiraToBitBucket.Services
{
    public class FileLoaderService
    {
        private readonly string _filepath;
        private const string JiraFileRecognitionString = "JIRA Build";

        public FileLoaderService(string filepath)
        {
            _filepath = filepath;
            JiraXmlFile = new FileInfo(_filepath);
        }

        public string XmlData { get; private set; }
        public FileInfo JiraXmlFile { get; private set; }

        public bool FileIsValid()
        {
            if (JiraXmlFile.Extension != ".xml")
            {
                throw new FileLoadException("File must be of XML format");
            }

            return JiraXmlFile.Exists;
        }

        public FileLoaderService LoadFile()
        {
            if (FileIsValid())
            {
                using (var fileStream = new FileStream(_filepath, FileMode.Open, FileAccess.Read))
                {
                    if (!fileStream.CanRead)
                    {
                        throw new FileLoadException(String.Format("Cannot read file '{0}'", _filepath));
                    }

                    byte[] buffer;
                    try
                    {
                        int length = (int)fileStream.Length; // get file length
                        buffer = new byte[length]; // create buffer
                        int count; // actual number of bytes read
                        int sum = 0; // total number of bytes readthe file is a directory.

                        // read until Read method returns 0 (end of the stream has been reached)
                        while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                            sum += count; // sum is a buffer offset for next reading
                    }
                    finally
                    {
                        fileStream.Close();
                    }

                    XmlData = Encoding.UTF8.GetString(buffer);

                    if (!XmlData.Contains(JiraFileRecognitionString))
                    {
                        throw new FileLoadException("File is not a recognised Jira export file");
                    }
                }
            }

            return this;
        }
    }
}
