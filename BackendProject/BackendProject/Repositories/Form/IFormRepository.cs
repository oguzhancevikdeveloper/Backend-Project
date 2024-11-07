namespace BackendProject.Repositories.Form;

public interface IFormRepository
{
    Task<List<Models.Form>> GetFormsAsync(string searchTerm = "");
    Task<Models.Form> GetFormByIdAsync(int id);
    Task AddFormAsync(Models.Form form);
}
