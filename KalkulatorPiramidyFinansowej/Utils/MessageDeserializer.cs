using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace KalkulatorPiramidyFinansowej {
    public class MessageDeserializer {
        public static T GetFromFile<T> (FileInfo xmlFile) where T : class {
            if (!xmlFile.Exists) {
                throw new FileNotFoundException ();
            }

            using var filestream = new FileStream (xmlFile.FullName, FileMode.Open);
            using var reader = XmlReader.Create (filestream);
            var serializer = new XmlSerializer (typeof (T));
            return serializer.Deserialize (reader) as T;
        }
    }
}
