namespace Dobra.Validators.Tests;

public class CpfTests {
    [TestCase("03829800002")]
    [TestCase("29541460011")]
    [TestCase("95908795003")]
    [TestCase("63019392047")]
    public void ValidCpf(string cpf) {
        var res = CpfValidator.Validate(cpf);

        Assert.That(res, Is.True);
    }

    [TestCase("03829800001")]
    [TestCase("29541460012")]
    [TestCase("11111111111")]
    [TestCase("77777777777")]
    [TestCase("959087950030")]
    [TestCase("9590879500b")]
    public void InvalidCpf(string cpf) {
        var res = CpfValidator.Validate(cpf);

        Assert.That(res, Is.False);
    }
}
