using KalkulatorPiramidyFinansowej.Entities;
using KalkulatorPiramidyFinansowej.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PrzelewyType = KalkulatorPiramidyFinansowej.XmlModels.przelewy;

namespace KalkulatorPiramidyFinansowej.Readers {
    public class PrzelewReader : Singleton<PrzelewReader> {
        public IEnumerable<Przelew> Read (FileInfo xmlFile) {
            var przelewyMessage = MessageDeserializer.GetFromFile<PrzelewyType> (xmlFile);

            var przelewy = przelewyMessage.Przelewy.Select (p => new Przelew {
                IdNadawcy = p.Od,
                Kwota = p.Kwota
            });

            return przelewy.ToList ();
        }
    }
}
