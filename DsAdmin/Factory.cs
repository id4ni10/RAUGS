using System;

namespace DsAdmin
{
    public class Factory : IDisposable
    {
        private DAO transacao = new DAO();
        private Boolean disposedValue;

        #region Types

        public Contato Contato() { return new Contato(transacao); }

        #endregion

        protected void Dispose(Boolean disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (!transacao.IsClosed) { transacao.Fechar(); }
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            if (System.Runtime.InteropServices.Marshal.GetExceptionCode() == 0)
            {
                transacao.Commit();
            }
            else
            {
                transacao.Rollback();
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}