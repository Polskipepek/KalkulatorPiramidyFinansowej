namespace KalkulatorPiramidyFinansowej.Dtos {
    public class UczestnikDto {
        public int Id { get; init; }
        public int PoziomWpiramidzie { get; init; }
        public int LiczbaPodwladnychBezPodwladnych { get; init; }
        public int NaleznaProwizja { get; init; }

        public override string ToString () {
            return $"{Id} {PoziomWpiramidzie} {LiczbaPodwladnychBezPodwladnych} {NaleznaProwizja}";
        }
    }
}
