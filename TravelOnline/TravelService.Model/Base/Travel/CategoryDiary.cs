using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model.Base.Travel
{
    public class CategoryDiary
    {
        public long categoryId { get; set; }

        public List<TravelDiarySummary> diares { get; set; }
    }
}
