public class FactorialEndpoint : Endpoint<Nums,ulong>
{
    public override void Configure()
    {
        Get("/factorial/{Num1}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Nums nums, CancellationToken ct)
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        if(FactorialMemory.Factorials.ContainsKey(nums.Num1)){
            var previousCalculation = FactorialMemory.Factorials[nums.Num1];
            await SendAsync(previousCalculation);
        }else{
            ulong result = 1;
            for (int i = 1; i <= nums.Num1; i++){
                result *= (ulong)i;
            }
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            FactorialMemory.Factorials.Add(nums.Num1,result);
            await SendAsync(result);
        }
    }
}