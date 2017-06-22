﻿namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class DxgiResourceProxyFactory : ObjectRefProxyFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new DxgiResourceProxy((IDxgiResource) objectRef, proxyOptions);
    }
}

