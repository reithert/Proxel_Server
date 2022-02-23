namespace Proxel_Server;

public class Request {

    public Request(string payload) {
        this.Payload = payload;
    }
    public string Payload {get; set;}
}