namespace Breakfast.Scenarios
{
    public interface IBreakfast
    {
        Task MakeBreakfast(CancellationToken cancellationToken = default);
    }
}
