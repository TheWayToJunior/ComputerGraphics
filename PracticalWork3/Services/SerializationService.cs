using System.IO;
using System.Xml.Serialization;

namespace PracticalWork3.Services
{
    public class SerializationService
    {
        private string path;

        public SerializationService(string path)
        {
            this.path = path;
        }

        public string Path => path;

        public void Serialize<T>(T serializationObject)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, serializationObject);
            }
        }

        public T Deserialize<T>()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            T result;

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                result = (T)xmlSerializer.Deserialize(fileStream);
            }

            return result;
        }
    }
}
