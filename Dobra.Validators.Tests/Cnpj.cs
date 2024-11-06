namespace Dobra.Validators.Tests;

public class CnpjTests {
    [TestCase("03081416000170")]
    [TestCase("94523007000131")]
    [TestCase("87491461000192")]
    [TestCase("31411114000158")]
    [TestCase("72264924000106")]
    public void ValidCnpj(string cnpj) {
        var res = CnpjValidator.Validate(cnpj);

        Assert.That(res, Is.True);
    }

    [TestCase("11111111111111")]
    [TestCase("77777777777777")]
    [TestCase("03081416000171")]
    [TestCase("3141111400015n")]
    [TestCase("030814160001700")]
    public void InvalidCnpj(string cnpj) {
        var res = CnpjValidator.Validate(cnpj);

        Assert.That(res, Is.False);
    }
}
