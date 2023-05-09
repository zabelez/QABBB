using QABBB.API.Models.Document;
using QABBB.Models;
namespace QABBB.API.Assemblers
{
    public class DocumentAssembler
    {
        public DocumentDTO toDocumentDTO(Document document)
        {
            DocumentDTO documentDTO = new DocumentDTO();
            documentDTO.IdDocument = document.IdDocument;
            documentDTO.Type = document.IdDocumentTypeNavigation.Name;
            documentDTO.Label = document.Label;
            documentDTO.Uuid = document.Uuid;

            return documentDTO;
        }
        public Document toDocument(Document document, DocumentEditDTO documentEditInputDTO)
        {
            document.IdDocument = documentEditInputDTO.IdDocument;
            document.IdProject = documentEditInputDTO.IdProject;
            document.Label = documentEditInputDTO.Label;
            document.Uuid = documentEditInputDTO.Uuid;
            return document;
        }
        public List<DocumentDTO> toDocumentDTO(IEnumerable<Document> companies)
        {
            List<DocumentDTO> documentDTO = new List<DocumentDTO>();
            foreach (Document document in companies)
            {
                documentDTO.Add(toDocumentDTO(document));
            }
            return documentDTO;
        }
        public Document toDocument(DocumentInputDTO documentInputDTO)
        {
            Document document = new Document();
            document.IdProject = documentInputDTO.IdProject;
            document.Label = documentInputDTO.Label;
            document.IdDocumentType = documentInputDTO.DocumentType;
            document.Url = documentInputDTO.Url;
            return document;
        }
    }
}