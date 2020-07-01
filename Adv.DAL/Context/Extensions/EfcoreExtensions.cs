using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.DAL.Context.Extensions
{
    public static class EfcoreExtensions
    {
        const byte SIZE = 20;
        /// <summary>
        /// получить Объявления постранично
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public static IQueryable<T> GetAdvertsByPage<T>(this IQueryable<T> query, int pageNumber)
        {
            var skip = (SIZE * pageNumber) - SIZE;
            query.Skip(skip).Take(SIZE);
            return query;
        }
    }
}
