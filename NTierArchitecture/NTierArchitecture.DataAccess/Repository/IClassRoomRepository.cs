using NTierArchitecture.Entities.Models;
using System.Linq.Expressions;

namespace NTierArchitecture.DataAccess.Repository;

public interface IClassRoomRepository
{
    //Bu repositoryde Crud işlemleri bulunacak
    void Create(ClassRoom classRoom);
    void Update(ClassRoom classRoom);
    void DeleteById(Guid Id);
    IQueryable<ClassRoom> GetAll();
    ClassRoom? GetClassRoomById(Guid studentId);
    bool Any(Expression<Func<ClassRoom, bool>> predicate);
}
