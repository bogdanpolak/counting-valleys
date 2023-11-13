using CountingValleysReact.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests;

public class SolutionControllerTests
{
    private readonly SolutionController _sut = new();

    [Test]
    [TestCase("", 0)]
    [TestCase("UD", 0)]
    [TestCase("DU", 1)]
    [TestCase("DDUDUU", 1)]
    [TestCase("UDDUUDDU", 2)]
    [TestCase("UUUDDUDD", 0)]
    [TestCase("UDDDUDUU", 1)]
    [TestCase("DDUDDUUDUU",1)]
    [TestCase("DUUUDUDDUUDDDU", 2)]
    [TestCase("DDDUUDUUUUUDDUDDDU", 2)]
    [TestCase("DDDUUDUUUUUUDDDUUDDDDUDDDUUUUUDDDU", 4)]
    public void ResponseOkTests(string path, int valleys)
    {
        var actionResult = _sut.Get(path);
        var countResponse = ((actionResult.Result as OkObjectResult)!.Value as CountResponse)!;

        countResponse.Valleys.Should().Be(valleys);
    }
}