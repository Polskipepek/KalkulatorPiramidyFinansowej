using KalkulatorPiramidyFinansowej.Entities;
using KalkulatorPiramidyFinansowej.Entities.Factories;
using KalkulatorPiramidyFinansowej.Exceptions;
using KalkulatorPiramidyFinansowej.Payments;
using KalkulatorPiramidyFinansowej.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KalkulatorPiramidyFinansowej {
    class Program {
        private const string PiramidaFileName = "piramida.xml";
        private const string PrzelewyFileName = "przelewy.xml";

        private IEnumerable<Uczestnik> uczestnicy;
        private IEnumerable<Przelew> przelewy;

        static void Main () {
            new Program ().Start ();
        }

        private void Start () {
            try {
                uczestnicy = ReadUczestnicy ();
                przelewy = ReadPrzelewy ();
            } catch (FinancialPyramidRuntimeException ex) {
                Console.WriteLine ("Wystąpił błąd podczas próby importu danych:");
                Console.WriteLine (ex.Message);
                return;
            }

            PaymentManager paymentManager = new (uczestnicy);

            paymentManager.Deposit (przelewy);

            UczestnikDtoFactory uczestnikDtoFactory = new (paymentManager);
            var uczestnicyDtos = uczestnicy.Select (u => uczestnikDtoFactory.Create (u));

            Console.WriteLine (string.Join (Environment.NewLine, uczestnicyDtos));
        }

        private IEnumerable<Uczestnik> ReadUczestnicy () {
            try {
                return UczestnikReader.Instance.Read (new FileInfo (PiramidaFileName));
            } catch (FileNotFoundException) {
                var exMessage = $"Nie znaleziono podanego pliku piramidy ({PiramidaFileName})";
                throw new FinancialPyramidRuntimeException (exMessage);
            } catch (Exception ex) {
                var exMessage = $"Niepoprawny format pliku wejściowego piramidy{Environment.NewLine}{ex.Message}";
                throw new FinancialPyramidRuntimeException (exMessage);
            }
        }
        private IEnumerable<Przelew> ReadPrzelewy () {
            try {
                return PrzelewReader.Instance.Read (new FileInfo (PrzelewyFileName));
            } catch (FileNotFoundException) {
                var exMessage = $"Nie znaleziono podanego pliku przelewów ({PrzelewyFileName})";
                throw new FinancialPyramidRuntimeException (exMessage);
            } catch (Exception ex) {
                var exMessage = $"Niepoprawny format pliku wejściowego przelewów{Environment.NewLine}{ex.Message}";
                throw new FinancialPyramidRuntimeException (exMessage);
            }
        }
    }
}
