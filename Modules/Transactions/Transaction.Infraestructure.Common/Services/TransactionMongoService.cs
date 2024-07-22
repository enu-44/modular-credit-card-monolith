using AutoMapper;
using Transaction.Domain;
using Transaction.Infraestructure.Persistence;

namespace Transaction.Infraestructure.Common;

public class TransactionMongoService(IMapper mapper, ITransactionMongoRepository<TransactionMongoDbContext> repository) : ITransactionMongoService
{
    public async Task<IEnumerable<TransactionResponseDTO>> AllAsync(CancellationToken cancellation)
    {
        var data = await  repository.AllAsync();
        IEnumerable<TransactionResponseDTO> empty = data.Select(item=> new TransactionResponseDTO{
            Type= $"{item.Id} : {item.Type}",
            Amount = item.Amount,
            Date= item.Date,
            Description = item.Description
        });
        return empty;
    }
}
