public class CoordinateEndpoint : Endpoint<Nums,List<Coordinate>>
{
    public override void Configure()
    {
        Get("/coordinates/{Amount}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Nums nums, CancellationToken ct)
    {
        Random rnd = new Random();
        for (var i = 0; i<nums.Amount; i++){
            var lattitude = rnd.NextDouble()*180-90;
            var longitude = rnd.NextDouble()*360-180;
            var coordinate = new Coordinate(){
                lattitude = lattitude,
                longitude = longitude,
                nsHemisphere = lattitude>0? "North":"South",
                ewHemisphere = longitude>0? "East":"West"
            };
            CoordinateList.Coordinates.Add(coordinate);
        }
        await SendAsync(CoordinateList.Coordinates);
    }
}