using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Transactions.Models
{
    public class TransactionRepository
    {
        SQLiteConnection database;

        public TransactionRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Transaction>();
        }

        public IEnumerable<Transaction> GetItems()
        {
            return database.Table<Transaction>().ToList();
        }

        public Transaction GetItem(int id)
        {
            return database.Get<Transaction>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Transaction>(id);
        }

        public int SaveItem(Transaction item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}

