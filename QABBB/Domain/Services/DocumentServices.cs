using QABBB.API.Models.Document;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.Models;

namespace QABBB.Domain.Services
{
    public class DocumentServices
    {
        private readonly QABBBContext _context;
        private readonly DocumentRepository _documentRepository;

        public DocumentServices(QABBBContext context)
        {
            _context = context;
            _documentRepository = new DocumentRepository(_context);
        }

        public Document? findById(int id)
        {
            return _documentRepository.findById(id);
        }

        public Document? findByUuid(string uuid)
        {
            return _documentRepository.findByUuid(uuid);
        }

        public ICollection<Document> editProject(ICollection<Document> documents, List<DocumentInputDTOForPutProject>? inputDocuments)
        {
            foreach (var item in documents.Select((value, index) => new { value, index }))
            {
                if (!inputDocuments.Exists(x => x.IdDocument == item.value.IdDocument))
                    documents.Remove(item.value);
            }

            foreach (DocumentInputDTOForPutProject item in inputDocuments)
            {
                if (item.IdDocument == 0)
                {
                    Document? pd = this.findById(item.IdDocument);
                    if (pd != null)
                        documents.Add(pd);
                }
            }

            return documents;
        }

    }
}
