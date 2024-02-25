namespace NTierArchitecture.Entities.DTOs;

public sealed record UpdateStudentDto(
    Guid Id,
    string Firstname,
    string LastName,
    string IdentityNumber,
    Guid ClassRoomId);
