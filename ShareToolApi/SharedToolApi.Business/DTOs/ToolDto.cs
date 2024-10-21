using SharedToolApi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedToolApi.Business.DTOs
{
    public class ToolDto
    {
        public ToolDto() { }

        public ToolDto(Tool tool)
        {
            Id = tool.Id;
            Name = tool.Name;
            Quantity = tool.Quantity;
            ImageUrl = tool.ImageUrl;
            Description = tool.Description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int QtyReal { get; set; }

        //public virtual ICollection<BorrowedTool> BorrowedTools { get; set; }
    }
}
