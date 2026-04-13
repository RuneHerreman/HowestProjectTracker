namespace HowestProjectTracker.Api.DTOs
{
    public record StudentReadDto(
        int Id,
        string FirstName,
        string LastName,
        string Email,
        bool IsPaid
    );
}
