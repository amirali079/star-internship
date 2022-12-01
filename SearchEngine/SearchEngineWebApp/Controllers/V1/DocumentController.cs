using Microsoft.AspNetCore.Mvc;
using SearchEngine.Contract.V1;
using SearchEngine.Service;

namespace SearchEngine.Controllers.V1;

public class DocumentController : Controller
{
    private readonly IDocumentService _service;

    public DocumentController(IDocumentService service)
    {
        _service = service;
    }

    [HttpGet(ApiRoutes.Documents.Search)]
    public async Task<IActionResult> GetByKeyword([FromQuery] string query)
    {
        var docs = await _service.GetDocumentByKeyword(query);

        if (docs.Count().Equals(0))
            return NotFound();

        return Ok(docs);
    }
}