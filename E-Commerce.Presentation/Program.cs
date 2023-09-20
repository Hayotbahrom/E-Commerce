namespace E_Commerce.Presentation;

public class Program
{
    static async Task Main(string[] args)
    {
        UI ui = new UI();
        await ui.RunCodeAsync();
    }
}