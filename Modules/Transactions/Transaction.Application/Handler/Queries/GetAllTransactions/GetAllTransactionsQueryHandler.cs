using MediatR;
using Transaction.Domain;
namespace Transaction.Application;

public class GetAllTransactionsQueryHandler(ITransactionMongoService _transactionService) : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionResponseDTO>>
{
    Task<IEnumerable<TransactionResponseDTO>> IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionResponseDTO>>.Handle(
            GetAllTransactionsQuery request, CancellationToken cancel)
        => _transactionService.AllAsync(cancel);
}