using SearchEngine.Contract.V1.Response;

namespace SearchEngine.Service;

public interface IDocumentService
{
    Task<IEnumerable<DocumentResponse>> GetDocumentByKeyword(string query);
}