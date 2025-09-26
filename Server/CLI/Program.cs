using System.Threading.Tasks;

class Program
{
        static async Task Main(string[] args)
        {
              CLI.UI.CLI cxl = new CLI.UI.CLI();
              await cxl.Run();
        }
}