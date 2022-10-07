public class MultiplyEndpoint : Endpoint<Nums,String>
{
    public override void Configure()
    {
        Get("/math/{Num1}/{Num2}/{Amount}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Nums nums, CancellationToken ct)
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        for (int i = 0; i < nums.Amount; i++){
            var temp = nums.Num1*nums.Num2;
        }
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        await SendAsync("Done");
    }
}