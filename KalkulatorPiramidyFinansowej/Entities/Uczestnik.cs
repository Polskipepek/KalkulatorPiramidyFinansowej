using System.Collections.Generic;

namespace KalkulatorPiramidyFinansowej.Entities {
    public class Uczestnik {
        public int Id { get; init; }
        public int PoziomWpiramidzie { get; init; }
        public int? PrzelozonyId { get; init; }
        public Uczestnik Przelozony { get; set; }
        public int[] PodwladniIds { get; init; }
        public IEnumerable<Uczestnik> Podwladni { get; set; }
    }
}
