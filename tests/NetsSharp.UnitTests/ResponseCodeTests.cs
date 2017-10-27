namespace NetsSharp.UnitTests
{
    using System.Collections.Generic;
    using Exceptions;
    using Xunit;

    public class ResponseCodeTests
    {
        public static IEnumerable<IEnumerable<object>> InterpretResponseCodeData
        {
            get
            {
                yield return
                    new object[]
                    {
                        "Cardnumber:TooManyDigits",
                        new[]
                        {
                            new KeyValuePair<ResponseCodeField, ResponseCodeError>(
                                ResponseCodeField.CardNumber,
                                ResponseCodeError.TooManyDigits)
                        }
                    };

                yield return
                    new object[]
                    {
                        "Cardnumber:TooManyDigits,SecurityCode:TooFewDigits",
                        new[]
                        {
                            new KeyValuePair<ResponseCodeField, ResponseCodeError>(
                                ResponseCodeField.CardNumber,
                                ResponseCodeError.TooManyDigits),
                            new KeyValuePair<ResponseCodeField, ResponseCodeError>(
                                ResponseCodeField.SecurityCode,
                                ResponseCodeError.TooFewDigits)
                        }
                    };
            }
        }

        [Theory, MemberData("InterpretResponseCodeData")]
        public void InterpretResponseCode(string responseCode,
            IEnumerable<KeyValuePair<ResponseCodeField, ResponseCodeError>> errors)
        {
            var exception = Assert.Throws<InvalidResponseException>(() => Nets.InterpretResponseCode(responseCode));
            Assert.Equal(errors, exception.Errors);
        }
    }
}