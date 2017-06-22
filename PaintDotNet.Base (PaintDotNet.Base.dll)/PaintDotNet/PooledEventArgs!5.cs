﻿namespace PaintDotNet
{
    using System;

    public abstract class PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4> : PooledEventArgs<TDerivedArgs> where TDerivedArgs: PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4>, new()
    {
        private TValue1 value1;
        private TValue2 value2;
        private TValue3 value3;
        private TValue4 value4;

        protected override void ClearValues()
        {
            this.value1 = default(TValue1);
            this.value2 = default(TValue2);
            this.value3 = default(TValue3);
            this.value4 = default(TValue4);
        }

        public override TDerivedArgs Clone() => 
            PooledEventArgs<TDerivedArgs, TValue1, TValue2, TValue3, TValue4>.Get(this.Value1, this.Value2, this.Value3, this.Value4);

        protected internal static TDerivedArgs Get(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4)
        {
            TDerivedArgs local1 = PooledEventArgs<TDerivedArgs>.Get();
            local1.SetValues(value1, value2, value3, value4);
            local1.Validate();
            return local1;
        }

        private void SetValues(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
        }

        protected TValue1 Value1
        {
            get
            {
                base.VerifyIsValid();
                return this.value1;
            }
            set
            {
                base.VerifyIsValid();
                this.value1 = value;
            }
        }

        protected TValue2 Value2
        {
            get
            {
                base.VerifyIsValid();
                return this.value2;
            }
            set
            {
                base.VerifyIsValid();
                this.value2 = value;
            }
        }

        protected TValue3 Value3
        {
            get
            {
                base.VerifyIsValid();
                return this.value3;
            }
            set
            {
                base.VerifyIsValid();
                this.value3 = value;
            }
        }

        protected TValue4 Value4
        {
            get
            {
                base.VerifyIsValid();
                return this.value4;
            }
            set
            {
                base.VerifyIsValid();
                this.value4 = value;
            }
        }
    }
}

