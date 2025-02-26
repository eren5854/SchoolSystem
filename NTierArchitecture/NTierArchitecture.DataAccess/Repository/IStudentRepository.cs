﻿using NTierArchitecture.Entities.Models;
using System.Linq.Expressions;

namespace NTierArchitecture.DataAccess.Repository;
public interface IStudentRepository
{
    //Bu repositoryde Crud işlemleri bulunacak
    void Create(Student student);
    void Update(Student student);
    void DeleteById(Guid Id);
    IQueryable<Student> GetAll();
    Student? GetStudentById(Guid studentId);
    bool Any(Expression<Func<Student, bool>> predicate);
    int GetNewStudentNumber();
}
