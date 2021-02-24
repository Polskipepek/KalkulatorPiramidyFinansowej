using System.Linq;
using System.Xml.Linq;

namespace KalkulatorPiramidyFinansowej.Entities.Factories {
    internal class UczestnikFactory {
        private const string IdNodeName = "id";

        public Uczestnik Create (XElement uczestnikElem) {

            var id = (int) uczestnikElem.Attribute (IdNodeName);
            var poziomWpiramidzie = uczestnikElem.AncestorsAndSelf ().Count () - 2;
            var podwladniIds = uczestnikElem.Descendants ()?.Select (subordinate => (int) subordinate.Attribute (IdNodeName)).ToArray ();
            var przelozonyId = (int?) uczestnikElem.Parent?.Attribute (IdNodeName);

            return new Uczestnik {
                Id = id,
                PoziomWpiramidzie = poziomWpiramidzie,
                PrzelozonyId = przelozonyId,
                PodwladniIds = podwladniIds,
            };
        }
    }
}
