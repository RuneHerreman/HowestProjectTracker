namespace HowestProjectTracker.Api.DTOs
{
    public record StudentDetailReadDto
    (
        int Id,
        string FirstName,
        string LastName,
        IEnumerable<CourseReadDto> EnrolledCourses // De collectie cursussen als DTO's [1]
    );
}
