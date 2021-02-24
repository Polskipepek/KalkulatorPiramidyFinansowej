namespace KalkulatorPiramidyFinansowej.XmlModels {

    // UWAGA: Wygenerowany kod może wymagać co najmniej programu .NET Framework 4.5 lub .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Serializable ()]
    [System.ComponentModel.DesignerCategory ("code")]
    [System.Xml.Serialization.XmlType (AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot (Namespace = "", IsNullable = false)]
    public partial class przelewy {

        private przelewyPrzelew[] przelewField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement ("przelew")]
        public przelewyPrzelew[] Przelewy {
            get {
                return przelewField;
            }
            set {
                przelewField = value;
            }
        }
    }

    /// <remarks/>
    [System.Serializable ()]
    [System.ComponentModel.DesignerCategory ("code")]
    [System.Xml.Serialization.XmlType (AnonymousType = true)]
    public partial class przelewyPrzelew {

        private int odField;

        private int kwotaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute ("od")]
        public int Od {
            get {
                return odField;
            }
            set {
                odField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute ("kwota")]
        public int Kwota {
            get {
                return kwotaField;
            }
            set {
                kwotaField = value;
            }
        }
    }


}
