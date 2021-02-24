using System.IO;

namespace KalkulatorPiramidyFinansowej.Utils {
    public class StringHelper : Singleton<StringHelper> {
        public void ReplaceStringSigns (string fileName) {
            string text = File.ReadAllText (fileName);
            text = text.Replace ("”", "\"");
            File.WriteAllText (fileName, text);
        }
    }
}
