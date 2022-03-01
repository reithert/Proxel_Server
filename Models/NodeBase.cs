namespace Proxel_Server.Models;
using System.Collections.Concurrent;

public class NodeBase {

    private static ConcurrentDictionary<string, Node> _nodes
     = new ConcurrentDictionary<string, Node>();
    public static Node GetNode(string connectionID) {
        Node? node;
        _nodes.TryGetValue(connectionID, out node);
        if(node == null) {
            return new Node("null", "null", "null");
        } else {
            return node;
        }
    }

    // public static Node GetNodeByHostname(string hostname) {
    //     string? connectionID;
    //     connectionNames.TryGetValue(hostname, out connectionID);
    //     if(connectionID == null) {
    //         return new Node("null", "null", "null");
    //     } else {
    //         return GetNode(connectionID);
    //     }
    // }

    public static void AddNode(Node node) {
        _nodes.AddOrUpdate(node.ConnectionID, node, (k, v) => v = node);
    }

    public static void RemoveNode(string name) {
        Node? node;
        _nodes.TryRemove(name, out node);
    }

    public static bool NodeExists(string connectionID) {
        return _nodes.ContainsKey(connectionID);
    }

    // public static bool NodeExistsHostname(string hostname) {
    //     string? connectionID;
    //     connectionNames.TryGetValue(hostname, out connectionID);
    //     return connectionID != null;
    // }


    public static List<Node> GetAllNodes() {
        List<Node> nodeList;
        nodeList = _nodes.Values.ToList<Node>();
        return nodeList;
    }


}