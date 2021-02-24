using System;

namespace KalkulatorPiramidyFinansowej.Exceptions {
    class FinancialPyramidRuntimeException : Exception {
        public FinancialPyramidRuntimeException (string message) : base (message) { }
    }
}
