using SharedToolApi.Business.DTOs;
using SharedToolApi.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SharedToolApi.Business
{
    public class BorrowedToolRepository
    {
        public async Task<List<BorrowedToolDto>> GetAllBorrowedTools()
        {
            var context = new SharedToolDb();
            return await context.BorrowedTools.Select(b => new BorrowedToolDto
            {
                Id = b.Id,
                UserId = b.UserId,
                ToolId = b.ToolId,
                Approved = b.Approved,
                Date = b.Date
            }).ToListAsync();
        }

        public async Task<BorrowedToolDto> GetBorrowedToolById(int id, SharedToolDb context = null)
        {
            context = context ?? new SharedToolDb();
            return new BorrowedToolDto(await context.BorrowedTools.FindAsync(id));
        }

        public async Task Add(BorrowedToolDto borrowedTool)
        {
            var context = new SharedToolDb();
            var toolRepo = new ToolRepository();
            var tool = await toolRepo.GetToolById(borrowedTool.ToolId);

            if (tool.QtyReal <= 0)
                throw new Exception(Resources.SharedTool_Business.ToolOutOfStock);

            context.BorrowedTools.Add(new BorrowedTool
            {
                Id = borrowedTool.Id,
                UserId = borrowedTool.UserId,
                ToolId = borrowedTool.ToolId,
                Approved = borrowedTool.Approved,
                Date = borrowedTool.Date
            });
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var context = new SharedToolDb();
            var borrowedTool = context.BorrowedTools.Find(id);
            context.BorrowedTools.Remove(borrowedTool);
            await context.SaveChangesAsync();
        }

        public async Task Update(BorrowedTool borrowedTool)
        {
            var context = new SharedToolDb();
            var oldBorrowedTool = context.BorrowedTools.Find(borrowedTool.Id);
            context.Entry(oldBorrowedTool).CurrentValues.SetValues(borrowedTool);
            await context.SaveChangesAsync();
        }

        public async Task ApproveBorrowTool(int id)
        {
            var context = new SharedToolDb();
            var borrowedTool = await GetBorrowedToolById(id, context);
            if (borrowedTool.Tool.QtyReal <= 0) throw new Exception(Resources.SharedTool_Business.ToolOutOfStock);
            borrowedTool.Approved = true;
            await context.SaveChangesAsync();
        }
    }
}
