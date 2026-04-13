using HowestProjectTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HowestProjectTracker.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task DeleteAsync(int id);
    }
}
