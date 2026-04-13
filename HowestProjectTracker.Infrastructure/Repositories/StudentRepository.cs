using HowestProjectTracker.Domain.Models;
using HowestProjectTracker.Domain.Repositories;
using HowestProjectTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace HowestProjectTracker.Infrastructure.Repositories
{
    public class StudentRepository(SchoolContext context)
        : IStudentRepository
    {
        public async Task AddAsync(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student is not null)
            {
                student.Deleted = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await context.Students
                .Include(s => s.StudentsCourses)
                    .ThenInclude(sc => sc.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await context.Students
                .AsNoTracking()
                .OrderBy(s => s.LastName)
                .ToListAsync();
        }
    }
}
