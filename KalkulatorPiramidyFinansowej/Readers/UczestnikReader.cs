using KalkulatorPiramidyFinansowej.Entities;
using KalkulatorPiramidyFinansowej.Entities.Factories;
using KalkulatorPiramidyFinansowej.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace KalkulatorPiramidyFinansowej.Readers {
    public class UczestnikReader : Singleton<UczestnikReader> {
        private const string UczestnikNodeName = "uczestnik";
        private readonly UczestnikFactory uczestnikFactory = new UczestnikFactory ();

        public IEnumerable<Uczestnik> Read (FileInfo xmlFile) {
            if (!xmlFile.Exists) {
                throw new FileNotFoundException ();
            }

            XDocument xdoc = XDocument.Load (xmlFile.FullName);

            var uczestnicy = xdoc.Descendants (UczestnikNodeName).Select (uczestnikXElem =>
                uczestnikFactory.Create (uczestnikXElem)
            ).ToList ();

            foreach (var uczestnik in uczestnicy) {
                uczestnik.Przelozony = uczestnicy.FirstOrDefault (u => u.Id == uczestnik.PrzelozonyId);
                uczestnik.Podwladni = uczestnicy.Where (u => uczestnik.PodwladniIds.Contains (u.Id));
            }

            return uczestnicy;
        }
    }
}
