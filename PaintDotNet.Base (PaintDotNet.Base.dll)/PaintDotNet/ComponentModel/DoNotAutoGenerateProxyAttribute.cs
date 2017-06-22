﻿namespace PaintDotNet.ComponentModel
{
    using System;

    [AttributeUsage(AttributeTargets.Interface, AllowMultiple=false, Inherited=false)]
    internal sealed class DoNotAutoGenerateProxyAttribute : Attribute
    {
    }
}

