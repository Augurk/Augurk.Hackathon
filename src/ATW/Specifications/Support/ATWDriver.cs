using System;
using System.Collections.Generic;
using Augurk.Hackathon.ATW.Regels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Augurk.Hackathon.ATW.Specifications.Support
{
    public class ATWDriver
    {
        private readonly ATWLogDriver _log;
        private readonly InrichtingProvider _inrichtingProvider;
        private bool? _result;

        public ATWDriver(ATWLogDriver log, InrichtingProvider inrichtingProvider)
        {
            _log = log;
            _inrichtingProvider = inrichtingProvider;
        }

        public int Leeftijd { get; set; }

        public List<Dienst> Diensten { get; set; }

        public void VoerRegelUit(IATWRegel regel)
        {
            _result = regel.Valideer(Leeftijd, _inrichtingProvider, Diensten, _log);
        }

        public void AssertRegelNietOverschreden()
        {
            if (_result.HasValue)
            {
                _result.Value.ShouldBeTrue();
            }
            else
            {
                Assert.Inconclusive("Regel is nog niet uitgevoerd!");
            }            
        }

        public void AssertRegelOverschreden()
        {
            if (_result.HasValue)
            {
                _result.Value.ShouldBeFalse();
            }
            else
            {
                Assert.Inconclusive("Regel is nog niet uitgevoerd!");
            }
        }
    }
}
