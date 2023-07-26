using EnterComputers.Service.Validators;

namespace EnterComputers.UnitTest.ValidatorTests;

public class PhoneNumberValidatorTest
{
    [Theory]
    [InlineData("+998331211314")]
    [InlineData("+998331211315")]
    [InlineData("+998881211314")]
    [InlineData("+998331211304")]
    [InlineData("+998331211344")]
    [InlineData("+998331211214")]
    [InlineData("+998331211014")]
    [InlineData("+998991211314")]
    [InlineData("+998941211314")]
    public void ShouldReturnCorrect(string phone)
    {
        var result = PhoneNumberValidator.IsValed(phone);
        Assert.True(result);
    }

    [Theory]
    [InlineData("998976260619")]
    [InlineData("AADDHHFF")]
    [InlineData("+9989762606191")]
    [InlineData("+9989762601T9")]
    [InlineData("-9989762061T9")]
    [InlineData("@998976260619")]
    [InlineData("+99897626061")]
    [InlineData("+99897 626 06 19")]
    [InlineData("+9989 6260619")]

    public void ShouldReturnWrong(string phone)
    {
        var result = PhoneNumberValidator.IsValed(phone);
        Assert.False(result);
    }


} 
