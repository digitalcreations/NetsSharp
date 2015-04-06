namespace NetsSharp
{
    public enum ResponseCodeError
    {
        TooFewDigits,
        TooManyDigits,
        ContainsIllegalCharacters,
        HasWrongCheckDigit,
        FormatError,
        IllegalValue,
        Required,
        IllegalLength,
        ExpiredCard
    }
}