namespace NTierArchitecture.Entities.DTOs;
public sealed record PaginationRequestDto(
    Guid? Id,
    int PageNumber = 1,
    int PageSize = 30,
    string Search = "");
