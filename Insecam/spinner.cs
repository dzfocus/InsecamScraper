using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Edokan.KaiZen.Colors;


namespace Insecam
{
    public class ConsoleSpinner
    {
        private CancellationTokenSource TokenSource { get; set; }
        private Task Task { get; set; }

        public ConsoleSpinner()
        {
            this.TokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            var token = this.TokenSource.Token;

            if (this.Task == null)
            {
                this.Task = Task.Run(() =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        var spinChars = new char[] { '|', '/', '-', '\\' };

                        foreach (var spinChar in spinChars)
                        {
                            Console.Write(string.Concat("\r", "loading....".Green() + spinChar, "\r"));

                            System.Threading.Tasks.Task.Delay(80).Wait();
                        }
                    }
                }, token);
            }

        }
        public void Stop()
        {
            this.TokenSource.Cancel();
            this.Task.Wait();
            this.Task = null;
        }
    }
}
