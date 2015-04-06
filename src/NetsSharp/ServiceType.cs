namespace NetsSharp
{
    using System;

    public sealed class ServiceType
    {
        private readonly string _value;

        public static readonly ServiceType MerchantHosted = new ServiceType("M");
        public static readonly ServiceType Hosted = new ServiceType("B");
        public static readonly ServiceType CallCenter = new ServiceType("C");

        private ServiceType(string value)
        {
            this._value = value;
        }

        public override String ToString()
        {
            return this._value;
        }
    }
}