using KalkulatorPiramidyFinansowej.Entities;
using System.Collections.Generic;
using System.Linq;

namespace KalkulatorPiramidyFinansowej.Payments {
    class PaymentManager {
        private readonly IEnumerable<Uczestnik> uczestnicy;
        private Dictionary<int, int> commissions;

        public PaymentManager (IEnumerable<Uczestnik> uczestnicy) {
            this.uczestnicy = uczestnicy;
            commissions = new Dictionary<int, int> ();
        }
        public int GetBalance (int uczestnikId) =>
             commissions.ContainsKey (uczestnikId) ? commissions[uczestnikId] : 0;

        public void Deposit (IEnumerable<Przelew> payments) {
            foreach (var payment in payments) {
                Deposit (payment);
            }
        }

        private void Deposit (Przelew payment) {
            List<Uczestnik> contributorSupervisors = new ();
            var payer = uczestnicy.FirstOrDefault (u => u.Id == payment.IdNadawcy);

            if (payer.Przelozony == null) {
                Transfer (payer.Id, payment.Kwota);
                return;
            }

            var przelozony = payer.Przelozony;

            while (przelozony != null) {
                contributorSupervisors.Add (przelozony);
                przelozony = przelozony.Przelozony;
            }

            contributorSupervisors.Reverse ();
            int contributorSupervisorsCount = contributorSupervisors.Count ();

            int moneyLeft = payment.Kwota;
            for (int i = 0; i < contributorSupervisorsCount; i++) {
                int moneyToSend = 0;
                if (i < contributorSupervisorsCount - 1) {
                    moneyToSend = moneyLeft / 2;
                } else {
                    moneyToSend = moneyLeft;
                }

                moneyLeft -= moneyToSend;
                Transfer (contributorSupervisors[i].Id, moneyToSend);
            }
        }

        private void Transfer (int beneficientId, int amount) {
            if (!commissions.ContainsKey (beneficientId)) {
                commissions.Add (beneficientId, 0);
            }

            commissions[beneficientId] += amount;
        }
    }
}
