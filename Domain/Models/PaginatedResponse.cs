using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PaginatedResponse<T>
    {
      
        public int Total { get; set; }

        public int TotalPages { get; set; }
        
        public int CurrentPage { get; set; }
        
        public int PageSize { get; set; }
       
        public List<T> Data { get; set; }

        public PaginatedResponse(List<T> data, int total, int currentPage, int pageSize)
        {
            Total = total;
            PageSize = pageSize;
            CurrentPage = currentPage;
            Data = data;
            TotalPages = (int)Math.Ceiling(total / (double)pageSize);
        }
    }
}
