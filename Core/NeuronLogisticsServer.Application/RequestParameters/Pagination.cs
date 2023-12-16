
namespace NeuronLogisticsServer.Application.RequestParameters
{
    //data ön planda olduğundan nesne olmasına gerek yok 
    public record Pagination
    {
        public int Page { get; set; } = 0;

        public int Size { get; set; } = 5;
    }
}