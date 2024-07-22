using Common.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;

namespace Transaction.Domain;

public interface ITransactionMongoRepository<TContext>: IBaseMongoReadRepository<TransactionMongo, TContext>
    where TContext: DbContext, new()
{

}
