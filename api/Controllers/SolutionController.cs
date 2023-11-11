using Microsoft.AspNetCore.Mvc;

namespace CountingValleysReact.Controllers;

[ApiController]
[Route("[controller]")]
public class SolutionController : ControllerBase
{
    [HttpGet("CountingValleys({path})")]
    public ActionResult<CountResponse> Get(string path)
    {
        return Ok(new CountResponse{Path = path, Valleys = path.Length+1});
    }
}

public class CountResponse
{
    public string Path { get; set; }
    public int Valleys { get; set; }
}
