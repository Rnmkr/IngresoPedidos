using System;
using System.Windows.Input;

namespace IngresoPedidos.Helpers
{
    public class WaitCursor : IDisposable
    {
        private Cursor previousCursor;

        public WaitCursor()
        {
            previousCursor = Mouse.OverrideCursor;

            Mouse.OverrideCursor = Cursors.Wait;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Mouse.OverrideCursor = previousCursor;
        }
        #endregion
    }
}
