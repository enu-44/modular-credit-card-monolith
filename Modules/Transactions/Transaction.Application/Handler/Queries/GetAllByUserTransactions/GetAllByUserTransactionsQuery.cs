using Common.SharedKernel.Application;
using Transaction.Domain;

namespace Transaction.Application;

public sealed record GetAllByUserTransactionsQuery(Guid UserId, string CardNumber): IQuery<IEnumerable<TransactionResponseDTO>>{}

