namespace BackendProject.Repositories.Form;

public interface IFormRepository
{
    Task<List<Models.Form.Form>> GetFormsAsync(string searchTerm = "");
    Task<Models.Form.Form> GetFormByIdAsync(int id);
    Task AddFormAsync(Models.Form.Form form);
}
