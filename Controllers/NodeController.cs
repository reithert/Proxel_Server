using Microsoft.AspNetCore.Mvc;

namespace Proxel_Server.Controllers;

[ApiController]
[Route("[controller]")]
public class NodeController : ControllerBase
{

    private List<Node> _nodes;


    private readonly ILogger<NodeController> _logger;

    public NodeController(ILogger<NodeController> logger)
    {
        _logger = logger;
        _nodes = new List<Node>();
        _nodes.Add(new Node("Home Laptop", "Windows"));
        _nodes.Add(new Node("Raspberry Pi", "Linux"));
        _nodes.Add(new Node("Desktop", "Linux"));
        _nodes.Add(new Node("Docker", "Ubuntu"));
    }

    [HttpGet]
    public List<Node> GetNodes() {
        return _nodes;
    }

    [HttpPost]
    public Request ExecuteRequest(Request request) {
        request.Payload += ":::EXECUTED";
        return request;
    }



}
