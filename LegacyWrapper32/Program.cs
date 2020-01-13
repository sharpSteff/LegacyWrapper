using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.ExceptionServices;
using LegacyWrapper.Handler;
using PommaLabs.Thrower;

namespace LegacyWrapper32
{
    public class Program
    {
        /// <summary>
        /// Main method of the legacy dll wrapper.
        /// </summary>
        /// <param name="args">
        /// The first parameter is expected to be a string.
        /// The Wrapper will use this string to create a named pipe.
        /// </param>
        static void Main(string[] args)
        {
            try
            {
                //Debugger.Launch();

                ICallRequestHandler requestHandler = CallRequestHandlerFactory.GetInstance(args);
                requestHandler.Call();
            }
            catch (IOException ex1)
            {
                if (ex1.Message != "Pipe is broken.")
                {
                    // Fehlermeldung ignorieren
                    //Debugger.Launch();
                }
            }
            catch (System.Exception)
            {
                Debugger.Launch();
                throw;
            }
            
        }   
    }
}
