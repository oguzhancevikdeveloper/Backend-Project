namespace BackendProject.Models;

public class FormField
{
    public int Id { get; set; }
    public bool Required { get; set; }
    public string Name { get; set; }
    public string DataType { get; set; }
}
