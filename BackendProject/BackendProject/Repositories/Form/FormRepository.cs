using BackendProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Repositories.Form;

public class FormRepository(ApplicationDbContext _context) : IFormRepository
{
    public async Task<List<Models.Form.Form>> GetFormsAsync(string searchTerm = "")
    {
        var query = _context.Forms.Include(f => f.Fields).AsQueryable();
        if (!string.IsNullOrEmpty(searchTerm))query = query.Where(f => f.Name.Contains(searchTerm));       
        return await query.ToListAsync();
    }

    public async Task<Models.Form.Form> GetFormByIdAsync(int id)
    {
        return await _context.Forms.Include(f => f.Fields).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task AddFormAsync(Models.Form.Form form)
    {
        _context.Forms.Add(form);
        await _context.SaveChangesAsync();
    }
}
