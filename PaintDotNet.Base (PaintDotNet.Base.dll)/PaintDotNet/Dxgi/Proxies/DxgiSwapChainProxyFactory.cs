﻿namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class DxgiSwapChainProxyFactory : ObjectRefProxyFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new DxgiSwapChainProxy((IDxgiSwapChain) objectRef, proxyOptions);
    }
}
