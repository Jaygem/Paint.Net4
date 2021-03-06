﻿namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    [PrecacheAutoGeneratedProxyFactory, NativeInterfaceID("bb12d362-daee-4b9a-aa1d-14ba401cfa1f")]
    public interface IDirect2DFactory1 : IDirect2DFactory, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IGeometryFactory, IGeometryFactory1
    {
        IDrawingStateBlock1 CreateDrawingStateBlock(DrawingStateDescription1? drawingStateDescription = new DrawingStateDescription1?(), ITextRenderingParams textRenderingParams = null);
    }
}

