using KalkulatorPiramidyFinansowej.Dtos;
using KalkulatorPiramidyFinansowej.Payments;
using System.Linq;

namespace KalkulatorPiramidyFinansowej.Entities.Factories {
    class UczestnikDtoFactory {
        private readonly PaymentManager paymentManager;

        public UczestnikDtoFactory (PaymentManager paymentManager) {
            this.paymentManager = paymentManager;
        }

        public UczestnikDto Create (Uczestnik uczestnik) {
            UczestnikDto uczestnikDto = new UczestnikDto {
                Id = uczestnik.Id,
                PoziomWpiramidzie = uczestnik.PoziomWpiramidzie,
                LiczbaPodwladnychBezPodwladnych = GetUczestnikLiczbaPodwladnychBezPodwladnych (uczestnik),
                NaleznaProwizja = paymentManager.GetBalance (uczestnik.Id),
            };
            return uczestnikDto;
        }

        private static int GetUczestnikLiczbaPodwladnychBezPodwladnych (Uczestnik uczestnik) => (int) uczestnik.Podwladni?.Count (podwladny => podwladny.Podwladni?.Any () != true);
    }
}
