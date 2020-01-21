using System;
using System.IO.Pipes;
using System.Runtime.Serialization;
using LegacyWrapper.Common.Serialization;
using LegacyWrapper.Common.Token;
using LegacyWrapperClient.Configuration;
using LegacyWrapperClient.ProcessHandling;
using PommaLabs.Thrower;

namespace LegacyWrapperClient.Transport
{
    internal class PipeConnector : IPipeConnector
    {
        private bool _isDisposed;

        private PipeStream _pipe;

        private readonly ICallFormatter _formatter;
        private readonly IWrapperProcessStarter _wrapperProcessStarter;
        private readonly PipeStreamFactory _pipeStreamFactory;
        private readonly PipeToken _pipeToken;

        /// <summary>
        /// Creates a new WrapperClient instance.
        /// </summary>
        /// <param name="formatter">Formatter instance for data serialization to the pipe.</param>
        /// <param name="wrapperProcessStarter">WrapperProcessStarter instance for invoking the appropriate wrapper executable.</param>
        /// <param name="pipeStreamFactory">A factory instance to create a new NamedPipeClientStream.</param>
        /// <param name="pipeToken">PipeToken instance for creating pipe connections.</param>
        /// <param name="wrapperConfig">the wrapperconfig</param>
        public PipeConnector(ICallFormatter formatter, IWrapperProcessStarter wrapperProcessStarter, PipeStreamFactory pipeStreamFactory, PipeToken pipeToken, IWrapperConfig wrapperConfig)
        {
            Raise.ArgumentNullException.IfIsNull(formatter, nameof(formatter));
            Raise.ArgumentNullException.IfIsNull(wrapperProcessStarter, nameof(wrapperProcessStarter));
            Raise.ArgumentNullException.IfIsNull(pipeStreamFactory, nameof(pipeStreamFactory));
            Raise.ArgumentNullException.IfIsNull(pipeToken, nameof(pipeToken));
            
            _formatter = formatter;
            _wrapperProcessStarter = wrapperProcessStarter;
            _pipeStreamFactory = pipeStreamFactory;
            _pipeToken = pipeToken;

            _wrapperProcessStarter.StartWrapperProcess();
            OpenPipe(wrapperConfig.Timeout);
        }

        public void SendCallRequest(CallData callData)
        {
            _formatter.Serialize(_pipe, callData);
        }

        public CallResult ReceiveCallResponse()
        {
            CallResult callResult = _formatter.Deserialize<CallResult>(_pipe);

            if (callResult.Exception != null)
            {
                throw callResult.Exception;
            }

            return callResult;
        }

        private void OpenPipe(int timeout)
        {
            _pipe = _pipeStreamFactory.GetConnectedPipeStream(_pipeToken, timeout);
        }

        private void ClosePipe()
        {
            CallData info = new CallData { Status = KeepAliveStatus.Close };

            try
            {
                _formatter.Serialize(_pipe, info);
            }
            catch { } // This means the wrapper eventually crashed and doesn't need a clean shutdown anyways

            if (_pipe.IsConnected)
            {
                _pipe.Close();
            }
        }

        #region IDisposable-Implementation
        ~PipeConnector()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                ClosePipe();
                _pipe.Dispose();

                _wrapperProcessStarter.Dispose();
            }

            // Free any unmanaged objects here.

            _isDisposed = true;
        }
        #endregion

    }

}
