using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Queries;
using InitialEnterprise.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Repository
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task<IEnumerable<Document>> Query(DocumentQuery query);

        Task<Document> Insert(Document document);

        Document Update(Document document);

        Task<Document> Query(Guid id);
    }
}
