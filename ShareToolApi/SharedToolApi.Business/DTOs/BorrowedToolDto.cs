using SharedToolApi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedToolApi.Business.DTOs
{
    public class BorrowedToolDto
    {
        public BorrowedToolDto()
        {
        }

        public BorrowedToolDto(BorrowedTool borrowedTool)
        {
            Id = borrowedTool.Id;
            UserId = borrowedTool.UserId;
            ToolId = borrowedTool.ToolId;
            Approved = borrowedTool.Approved;
            Date = borrowedTool.Date;

            //AspNetUser = borrowedTool.AspNetUser;
            //Tool = borrowedTool.Tool;
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public int ToolId { get; set; }
        public bool Approved { get; set; }
        public DateTime Date { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
