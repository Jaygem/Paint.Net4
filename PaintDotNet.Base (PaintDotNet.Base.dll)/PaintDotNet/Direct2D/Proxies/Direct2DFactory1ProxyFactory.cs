﻿namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class Direct2DFactory1ProxyFactory : ObjectRefProxyFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new Direct2DFactory1Proxy((IDirect2DFactory1) objectRef, proxyOptions);
    }
}

