using Microsoft.EntityFrameworkCore;

namespace Proxel_Server.Models;

public class NodeLog : DbContext {
    public DbSet<Node> Nodes {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        options.UseSqlServer("Server=CÉLINE\\PRXEL_SERVER;Database=Nodebase;Integrated Security=True;");
    }
}