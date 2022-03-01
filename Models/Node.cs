namespace Proxel_Server.Models;

public class Node {

    public Node(string connectionID, SystemInfo sysInfo) {
        this.ConnectionID = connectionID;
        this.OS = sysInfo.OS;
        this.HostName = sysInfo.HostName;
    }

    
    public Node(string connectionID, string os, string hostname) {
        this.ConnectionID = connectionID;
        this.OS = os;
        this.HostName = hostname;
    }

    public string ConnectionID {get;}
    public string OS {get;}
    public string HostName{get;}
    public string Output{get; set;} = "No output receieved.";
}