namespace PlaceCheck.Worker.Interfaces;

public interface IPdfGeneratorService
{
    Task GeneratePdf(DateTime date);
}
