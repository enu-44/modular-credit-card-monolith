namespace Transaction.Domain;

public interface ITransactionMongoService
{
    Task<IEnumerable<TransactionResponseDTO>> AllAsync(CancellationToken cancellation);
}
