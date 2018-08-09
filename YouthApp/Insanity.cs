//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace YouthApp
//{
//    public class Insanity
//    {
//        public async Task<IEnumerable> Quarterly(byte start, byte end)
//        {
//            //return await new ApplicationDbContext(dco).Revenues.Select(x => new
//            {
//                x.AccountName,
//                x.AccountNumber,
//                x.Bank,
//                x.Source,
//                Revenue = x.Transactions.Where(t => t.TransactionDate.Year == DateTime.Now.Year && t.TransactionDate.Month >= start && t.TransactionDate.Month <= end && t.TransactionsTypesID == (short)TranTypes.Revenue).GroupBy(t => t.TransactionItems, (k, v) => new
//                {
//                    Item = k,
//                    Amount = v.Sum(t => t.Amount)
//                }).ToList(),
//                Expenditure = x.Transactions.Where(t => t.TransactionDate.Year == DateTime.Now.Year && t.TransactionDate.Month >= start && t.TransactionDate.Month <= end && t.TransactionsTypesID == (short)TranTypes.Expenditure).GroupBy(t => t.TransactionItems, (k, v) => new
//                {
//                    Item = k,
//                    Amount = v.Sum(t => t.Amount)
//                }).ToList()
//            }).ToListAsync();
//        }
//    }
//}
