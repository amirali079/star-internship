using SampleLibrary;
using SearchEngine.Contract.V1.Response;

namespace SearchEngine.Service;

public class DocumentService : IDocumentService
{
    private readonly IQueryManager _queryManager;

    public DocumentService(IFileReader fileReader, IIndexer indexer, IQueryManager queryManager)
    {
        _queryManager = queryManager;

        _queryManager.SetInvertedIndex(indexer.GetInvertedIndex(fileReader.ReadFile(@"../EnglishData")));
    }


    public async Task<IEnumerable<DocumentResponse>> GetDocumentByKeyword(string query)
    {
        var result = new HashSet<DocumentResponse>();
        
        if (query!=null)
        {
            var docs = _queryManager.Search(query);
            docs.ToList().ForEach(docName => result.Add(new DocumentResponse { Name = docName }));
        }
        
        return result;
    }
}