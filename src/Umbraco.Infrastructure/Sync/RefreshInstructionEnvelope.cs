﻿using System.Collections.Generic;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Sync;
using Umbraco.Core.Cache;

namespace Umbraco.Core.Sync
{
    /// <summary>
    /// Used for any 'Batched' <see cref="IServerMessenger"/> instances which specifies a set of <see cref="RefreshInstruction"/> targeting a collection of
    /// <see cref="IServerAddress"/>
    /// </summary>
    public sealed class RefreshInstructionEnvelope
    {
        public RefreshInstructionEnvelope(ICacheRefresher refresher, IEnumerable<RefreshInstruction> instructions)
        {
            Refresher = refresher;
            Instructions = instructions;
        }

        public ICacheRefresher Refresher { get; set; }
        public IEnumerable<RefreshInstruction> Instructions { get; set; }
    }
}
