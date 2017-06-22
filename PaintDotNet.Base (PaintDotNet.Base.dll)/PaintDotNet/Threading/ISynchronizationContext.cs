﻿namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Concurrency;
    using System;
    using System.Threading;

    [PrecacheAutoGeneratedProxyFactory]
    public interface ISynchronizationContext : IDispatcher, IObjectRef, IDisposable, IIsDisposed, IAsyncWorkQueue, IThreadAffinitizedObject
    {
        void Post(SendOrPostCallback d, object state);
        void Send(SendOrPostCallback d, object state);
    }
}

