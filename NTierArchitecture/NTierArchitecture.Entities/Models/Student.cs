using NTierArchitecture.Entities.Abstractions;

namespace NTierArchitecture.Entities.Models;
public sealed class Student : Entity
{
    public string FirstName {  get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", this.FirstName, this.LastName); //Action Metodu
    public int StudentNumber { get; set; } = 0;
    public string IdentityNumber { get; set; } = string.Empty;

    public Guid ClassRoomId { get; set; }
    public ClassRoom? ClassRoom { get; set; }
}
