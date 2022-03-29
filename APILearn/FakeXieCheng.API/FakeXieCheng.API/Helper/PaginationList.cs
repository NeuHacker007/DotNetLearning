using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.API.Helper
{
    public class PaginationList<T> : List<T>
    {
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public PaginationList(
            int currentPage,
            int pageSize,
            int totalCount,
            List<T> items
            )
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            AddRange(items);

            TotalPages = (int) Math.Ceiling(totalCount/ (double) pageSize);

        }

        public static async Task<PaginationList<T>> CreateAsync(

            int currentPage,
            int pageSize,
             IQueryable<T> result
            )
        {
            var totalCount = await result.CountAsync();
            var skip = (currentPage - 1) * pageSize;
            result = result.Skip(skip);

            result = result.Take(pageSize);
            //include vs join --> eager load
            var items = await result.ToListAsync();
            return new PaginationList<T>(currentPage, pageSize, totalCount, items);
        }
    }
}
