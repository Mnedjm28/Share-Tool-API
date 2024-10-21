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
        public async Task<List<BorrowedTool>> GetAllBorrowedTools()
        {
            var context = new SharedToolDb();
            var borrowedTools = await context.BorrowedTools.ToListAsync();
            return borrowedTools;
        }

        public async Task<BorrowedTool> GetBorrowedToolById(int id, SharedToolDb context = null)
        {
            context = context ?? new SharedToolDb();
            var borrowedTool = await context.BorrowedTools.FindAsync(id);
            return borrowedTool;
        }

        public async Task Add(BorrowedTool borrowedTool)
        {
            var context = new SharedToolDb();
            var toolRepo = new ToolRepository();
            var tool = await toolRepo.GetToolById(borrowedTool.ToolId);

            if (tool.QtyReal <= 0)
                throw new Exception(Resources.SharedTool_Business.ToolOutOfStock);

            context.BorrowedTools.Add(borrowedTool);
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
