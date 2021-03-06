﻿namespace PaintDotNet.Functional
{
    using System;

    public interface IAction<in TArg1, in TArg2, in TArg3>
    {
        void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3);
    }
}

