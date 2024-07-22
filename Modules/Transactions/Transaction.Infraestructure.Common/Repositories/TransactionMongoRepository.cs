using Common.SharedKernel.Infraestructure;
using Transaction.Domain;
using Transaction.Infraestructure.Persistence;

namespace Transaction.Infraestructure.Common;


public class TransactionMongoRepository(TransactionMongoDbContext dbContext) :BaseMongoReadRepository<TransactionMongo, TransactionMongoDbContext>(dbContext), ITransactionMongoRepository<TransactionMongoDbContext>
{
}
