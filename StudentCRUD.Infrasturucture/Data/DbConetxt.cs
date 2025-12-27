using StudentCRUD.Domain.Models;

namespace StudentCRUD.Infrasturucture.Data;

public class DbConetxt
{
    public static List<Student> Students { get; set; } = new();
}
