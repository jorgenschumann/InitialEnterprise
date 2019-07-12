using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework;
using InitialEnterprise.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IMainDbContext mainDbContext;

        public DocumentRepository(IMainDbContext context)
        {
            mainDbContext = context;
        }

        public IUnitOfWork UnitOfWork => mainDbContext;

        public Document Update(Document document)
        {
            var addedDocument = mainDbContext.Document.Update(document);
            mainDbContext.SaveEntitiesAsync();
            return addedDocument.Entity;
        }

        public async Task<Document> Query(Guid id)
        {
            return await mainDbContext.Document.SingleAsync(c => c.Id == id);
        }

        public async Task<Document> Insert(Document document)
        {
            var addedCurrency = await mainDbContext.Document.AddAsync(document);
            await mainDbContext.SaveEntitiesAsync();
            return addedCurrency.Entity;
        }

        public async Task<IEnumerable<Document>> Query(DocumentQuery query)
        {
            return await mainDbContext.Document.ToListAsync();
        }
    }
}
