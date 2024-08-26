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
        private readonly ITokenRepo _repo;
        public TokenGenerator(IConfigReader config, ITokenRepo repo)
        {
            _interval = config.TokenGeneratorInt();
            _repo = repo;
        }
        public void StartGenerating()
        {
            _isGenerating = true;
            _thread = new Thread(GeneratingToken);
            _thread.Start();
        }

        public void StopGenerating()
        {
            _isGenerating = false;
            _thread?.Join();
        }

        public void GeneratingToken()
        {
            while(_isGenerating)
            {
                _repo.DecreaseToken();
                Thread.Sleep(1000 / _interval);
            }
        }
    }
}
