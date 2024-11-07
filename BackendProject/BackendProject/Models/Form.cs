﻿namespace BackendProject.Models;

public class Form
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public List<FormField> Fields { get; set; }
}
