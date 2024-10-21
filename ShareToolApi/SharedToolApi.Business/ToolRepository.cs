using SharedToolApi.Business.DTOs;
using SharedToolApi.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SharedToolApi.Business
{
    public class ToolRepository
    {
        public async Task<List<ToolDto>> GetAllTools()
        {
            var context = new SharedToolDb();
            return await context.Tools.Include(t => t.BorrowedTools).Select(tool => new ToolDto
            {
                Id = tool.Id,
                Name = tool.Name,
                Quantity = tool.Quantity,
                ImageUrl = tool.ImageUrl,
                QtyReal = tool.Quantity - tool.BorrowedTools.Count(o => o.Approved) ?? 0,
            }).ToListAsync();
        }

        public async Task<ToolDto> GetToolById(int id)
        {
            var context = new SharedToolDb();
            return new ToolDto(await context.Tools.FindAsync(id));
        }

        public async Task Add(ToolDto tool)
        {
            var context = new SharedToolDb();
            context.Tools.Add(new Tool
            {
                Id = tool.Id,
                Name = tool.Name,
                Quantity = tool.Quantity,
                ImageUrl = tool.ImageUrl,
                Description = tool.Description

            });
            await context.SaveChangesAsync();
        }

        public async Task<string> Delete(int id)
        {
            var context = new SharedToolDb();
            var tool = await context.Tools.FindAsync(id);
            context.Tools.Remove(tool);
            await context.SaveChangesAsync();
            return tool.ImageUrl;
        }

        public async Task Update(Tool tool)
        {
            var context = new SharedToolDb();
            var oldTool = await context.Tools.FindAsync(tool.Id);
            context.Entry(oldTool).CurrentValues.SetValues(tool);
            await context.SaveChangesAsync();
        }
    }
}
