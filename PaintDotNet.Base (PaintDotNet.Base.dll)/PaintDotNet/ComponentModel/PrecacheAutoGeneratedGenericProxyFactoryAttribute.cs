﻿namespace PaintDotNet.ComponentModel
{
    using System;
    using System.Runtime.CompilerServices;

    [AttributeUsage(AttributeTargets.Interface, AllowMultiple=true, Inherited=false)]
    internal sealed class PrecacheAutoGeneratedGenericProxyFactoryAttribute : Attribute
    {
        public PrecacheAutoGeneratedGenericProxyFactoryAttribute()
        {
        }

        public PrecacheAutoGeneratedGenericProxyFactoryAttribute(Type type1)
        {
            this.Type1 = type1;
        }

        public PrecacheAutoGeneratedGenericProxyFactoryAttribute(Type type1, Type type2) : this(type1)
        {
            this.Type2 = type2;
        }

        public PrecacheAutoGeneratedGenericProxyFactoryAttribute(Type type1, Type type2, Type type3) : this(type1, type2)
        {
            this.Type3 = type3;
        }

        public Type Type1 { get; set; }

        public Type Type2 { get; set; }

        public Type Type3 { get; set; }

        public Type[] TypeParameters
        {
            get
            {
                if (this.Type3 != null)
                {
                    return new Type[] { this.Type1, this.Type2, this.Type3 };
                }
                if (this.Type2 != null)
                {
                    return new Type[] { this.Type1, this.Type2 };
                }
                if (this.Type1 != null)
                {
                    return new Type[] { this.Type1 };
                }
                return Array.Empty<Type>();
            }
        }

        public int TypeParametersCount =>
            ((((this.Type1 != null) ? 1 : 0) + ((this.Type2 != null) ? 1 : 0)) + ((this.Type3 != null) ? 1 : 0));
    }
}

