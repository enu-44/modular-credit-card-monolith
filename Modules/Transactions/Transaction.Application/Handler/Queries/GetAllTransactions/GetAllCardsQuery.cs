using Common.SharedKernel.Application;
using Transaction.Domain;

namespace Transaction.Application;

public sealed record GetAllTransactionsQuery(): IQuery<IEnumerable<TransactionResponseDTO>>{}

