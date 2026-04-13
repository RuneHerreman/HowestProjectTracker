using HowestProjectTracker.Api.DTOs;
using HowestProjectTracker.Domain.Models;

namespace HowestProjectTracker.Api.Extensions
{
    public static class StudentMappingExtensions
    {
        public static IEnumerable<StudentReadDto> ToStudentReadDtos(this IEnumerable<Student> students)
            => students.Select(s => s.ToReadDto());

        public static StudentReadDto ToReadDto(this Student s)
        {
            return new StudentReadDto(
                s.StudentId,
                s.FirstName,
                s.LastName,
                s.Email,
                s.Paid == 1 ? true : false
            );
        }

        public static StudentDetailReadDto ToDetailDto(this Student s)
        {
            return new StudentDetailReadDto(
                s.StudentId,
                s.FirstName ?? "",
                s.LastName ?? "",
                s.StudentsCourses.Select(sc => new CourseReadDto(
                    sc.Course.CourseId,
                    sc.Course.CourseName ?? ""
                )) // Map de geneste entiteiten naar DTO's [6, 8]
            );
        }
    }

}
