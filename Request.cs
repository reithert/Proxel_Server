namespace Proxel_Server;

public class Request {

    public Request(string payload, string hostname) {
        this.HostName = hostname;
        this.Payload = payload;
    }
    public string Payload {get; set;}
    public string HostName {get; set;}
}