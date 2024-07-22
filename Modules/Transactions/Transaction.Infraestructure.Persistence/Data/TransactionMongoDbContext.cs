using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using Transaction.Domain;

namespace Transaction.Infraestructure.Persistence;

public class TransactionMongoDbContext : DbContext
{
    public TransactionMongoDbContext(): base(){}
    public  TransactionMongoDbContext(DbContextOptions<TransactionMongoDbContext> options): base(options)
    {
    }
     protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<TransactionMongo>().ToCollection("transactions");
    }
}

