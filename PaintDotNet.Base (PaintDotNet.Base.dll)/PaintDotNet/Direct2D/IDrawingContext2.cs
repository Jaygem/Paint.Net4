﻿namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.ObjectModel;
    using System;

    public interface IDrawingContext2 : IDrawingContext1, IDrawingContext, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IDeviceResourceFactory, IResourceCache, IDeviceResourceFactory1, IDeviceResourceFactory2
    {
        void DrawGeometryRealization(IGeometryRealization geometryRealization, IBrush brush);
    }
}

