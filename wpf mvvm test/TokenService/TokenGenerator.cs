using Microsoft.Identity.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wpf_mvvm_test.Interfaces;

namespace wpf_mvvm_test.Token
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly ConcurrentQueue<string> _tokens = new ConcurrentQueue<string>();
        private bool _isGenerating;
        private Thread _thread;
        private readonly int _interval;
        public TokenGenerator(IConfigReader config)
        {
            _interval = config.TokenGeneratorInt();
        }
        public void StartGenerating()
        {
            if(_isGenerating)
                 _isGenerating = true;
            _thread = new Thread(() =>
            {
                while(_isGenerating)
                {
                    for(int i = 0 ; i < _tokens.Count; i++)
                    {
                        _tokens.Enqueue(Guid.NewGuid().ToString());
                    }
                    Thread.Sleep(_interval);
                }
            });
            _thread.Start();
        }

        public void StopGenerating()
        {
            _isGenerating = false;
            _thread?.Join();
        }

        public bool TryGetToken(out string value)
        {
            return _tokens.TryDequeue(out value);   
        }
    }
}
