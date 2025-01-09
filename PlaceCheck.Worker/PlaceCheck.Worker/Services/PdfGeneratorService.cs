using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlaceCheck.Worker.Configuration;
using PlaceCheck.Worker.Interfaces;

namespace PlaceCheck.Worker.Services;

public class PdfGeneratorService : IPdfGeneratorService
{
    private readonly IApplicationDbContext _dbContext;
    private readonly DirectoriesSettings _options;

    public PdfGeneratorService(IApplicationDbContext dbContext, IOptions<DirectoriesSettings> options)
    {
        _dbContext = dbContext;
        _options = options.Value;
    }
    
    public async Task GeneratePdf(DateTime date)
    {
        var outputPath = Path.Combine(_options.PdfReportsPath, $"{date.ToString("yyyyMMdd_HHmmss")}.pdf");

        var data = await _dbContext.SearchedPlaces
            .Where(x => x.InsertedOn.Date == date.Date)
            .ToListAsync();

        if (!data.Any())
        {
            return;
        }

        using (var pdfWriter = new PdfWriter(outputPath))
        using (var pdf = new PdfDocument(pdfWriter))
        using (var document = new Document(pdf))
        {
            var table = new Table(UnitValue.CreatePercentArray([70 ,30]));
            table.SetWidth(UnitValue.CreatePercentValue(100));
            table.SetPaddingLeft(5);
            table.SetPaddingRight(5);
            
            table.AddHeaderCell("Search Phase").SetPadding(5);
            table.AddHeaderCell("Inserted On").SetPadding(5);

            foreach (var p in data)
            {
                table.AddCell(p.SearchPhase);
                table.AddCell(p.InsertedOn.ToString("dd/MM/yyyy HH:mm:ss"));
                table.StartNewRow();
            }
            
            document.Add(table);
        }

    }
}
