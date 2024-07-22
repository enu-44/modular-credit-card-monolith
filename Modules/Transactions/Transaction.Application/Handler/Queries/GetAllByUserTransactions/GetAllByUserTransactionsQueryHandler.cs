using MediatR;
using Transaction.Domain;
namespace Transaction.Application;

public class GetAllByUserTransactionsQueryHandler(ITransactionService _transactionService) : IRequestHandler<GetAllByUserTransactionsQuery, IEnumerable<TransactionResponseDTO>>
{
    Task<IEnumerable<TransactionResponseDTO>> IRequestHandler<GetAllByUserTransactionsQuery, IEnumerable<TransactionResponseDTO>>.Handle(
            GetAllByUserTransactionsQuery request, CancellationToken cancel)
        => _transactionService.AllAsync(request.UserId, request.CardNumber,cancel);
}