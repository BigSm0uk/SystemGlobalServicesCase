namespace Core.Domain;

public class Currency : BaseEntity
{
    public required string NumCode { get; init; }
    public required string CharCode { get; init; }
    public required int Nominal { get; init; }
    public required string Name { get; init; }
    public required decimal Value { get; init; }
    public required decimal Previous { get; init; }
}
