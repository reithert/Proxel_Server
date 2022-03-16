namespace Proxel_Server.Hubs;
using Proxel_Server.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class NodeHub : Hub {

    public Task PrintMessage(string request) {
        // Console.WriteLine(request);
        return Clients.All.SendAsync("PrintOutput", request);
    }

    public void ConnectToServer(SystemInfo nodeInfo) {
        Node node = new Node(Context.ConnectionId, nodeInfo);
        NodeBase.AddNode(node);
    }

    public void SaveOutput(String output) {
        Node node = NodeBase.GetNode(Context.ConnectionId);
        node.Output = output;
    }

    public override async Task OnDisconnectedAsync(Exception? exception) {
        Node node = NodeBase.GetNode(Context.ConnectionId);
        NodeBase.RemoveNode(Context.ConnectionId);
        await Clients.All.SendAsync("PrintOutput", "Node Disconnected: " + node.HostName);
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
        await base.OnDisconnectedAsync(exception);
    }

}