using Microsoft.AspNetCore.Mvc;
using Proxel_Server.Hubs;
using Proxel_Server.Models;
namespace Proxel_Server.Controllers;
using Microsoft.AspNetCore.SignalR;


[ApiController]
[Route("[controller]")]
public class NodeController : ControllerBase
{

    private IHubContext<NodeHub> _hubContext;

    private readonly ILogger<NodeController> _logger;

    public NodeController(ILogger<NodeController> logger, IHubContext<NodeHub> hubContext)
    {
        _logger = logger;
        _hubContext = hubContext;

    }

    [HttpGet]
    public ActionResult<List<Node>> GetNodes() {
        return NodeBase.GetAllNodes();
    }

    [HttpPost]
    public async Task<ActionResult<Response>> ExecuteRequest(Request request) {
        if(!NodeBase.NodeExists(request.HostName)) {
            return new Response("Requested Node is not connected.");
        }
        Node node = NodeBase.GetNode(request.HostName);
        string oldOutput = node.Output;
        await _hubContext.Clients.Client(request.HostName).SendAsync("ExecuteRequest", request.Payload);
        string output = NodeBase.GetNode(request.HostName).Output;
        while(output == oldOutput) {
            Thread.Sleep(50);
            output = NodeBase.GetNode(request.HostName).Output;
        }
        node.Output = "null";
        return new Response(output);
    }



}
