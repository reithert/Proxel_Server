using System.ComponentModel.DataAnnotations;

namespace Proxel_Server.Models;
public class Node {

    public Node() {

    }

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

    [Key]
    public string ConnectionID {get; set;}
    public string OS {get; set;}
    public string HostName{get; set;}
    public string Output{get; set;} = "No output receieved.";
}