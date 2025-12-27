using StudentCRUD.Domain.Models;
using StudentCRUD.Infrasturucture.Data;
using System.Linq;

namespace StudentCRUD.Appllication.Service;

public class StudentService
{
    public bool Add(Student student)
    {
        if (DbConetxt.Students.Any(s => s.Id == student.Id))
            return false;

        DbConetxt.Students.Add(student);
        return true;
    }

    public bool UpdateStudent(Student student)
    {
        var existingStudent = GetByIdStudent(student.Id);
        if (existingStudent == null)
            return false;

        existingStudent.FirstName = student.FirstName;
        existingStudent.LastName = student.LastName;
        existingStudent.Age = student.Age;
        return true;
    }

    public bool DeleteStudent(int id)
    {
        var student = GetByIdStudent(id);
        if (student == null)
            return false;

        DbConetxt.Students.Remove(student);
        return true;
    }

    public Student GetByIdStudent(int id)
    {
        return DbConetxt.Students.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> GetByName(string name)
    {
        return DbConetxt.Students
            .Where(s => s.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Student> GetAllStudents()
    {
        return DbConetxt.Students.ToList();
    }
}
