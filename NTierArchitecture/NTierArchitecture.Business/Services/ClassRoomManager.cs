using AutoMapper;
using NTierArchitecture.Business.Constants;
using NTierArchitecture.Business.Validator;
using NTierArchitecture.DataAccess.Repository;
using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;
using ValidationException = FluentValidation.ValidationException;
using ValidationResult = FluentValidation.Results.ValidationResult;


namespace NTierArchitecture.Business.Services;
public sealed class ClassRoomManager
    (IClassRoomRepository classRoomRepository, IMapper mapper) : IClassRoomService
{
    public string Create(CreateClassRoomDto request)
    {
        CreateClassRoomDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);
        if (!result.IsValid)
        {
            throw new ArgumentException(string.Join(", ", result.Errors.Select(s => s.ErrorMessage).ToList()));
        }

        bool isClassRoomNameExists = classRoomRepository.Any(p => p.Name == request.Name);

        if (isClassRoomNameExists)
        {
            throw new ArgumentException(MessageConstants.NameAlreadyExists);
        }

        ClassRoom classRoom = mapper.Map<ClassRoom>(request);
        classRoom.CreatedBy = "Admin";
        classRoom.CreatedDate = DateTime.Now;

        classRoomRepository.Create(classRoom);
        return MessageConstants.CreateIsSuccessfully;
    }

    public string DeleteById(Guid id)
    {
        classRoomRepository.DeleteById(id);
        return MessageConstants.DeleteIsSuccessfully;
    }

    public List<ClassRoom> GetAll()
    {
        List<ClassRoom> classRooms = classRoomRepository
            .GetAll()
            .OrderBy(p => p.Name)
            .ToList();
        return classRooms;
    }

    public string Update(UpdateClassRoomDto request)
    {
        UpdateClassRoomDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);
        if(!result.IsValid)
        {
            throw new ValidationException(string.Join(", ", result.Errors.Select(s => s.ErrorMessage).ToList()));
        }

        ClassRoom? classRoom = classRoomRepository.GetClassRoomById(request.Id);
        if (classRoom is null)
        {
            throw new ArgumentException(MessageConstants.DataNotFound);
        }

        if(classRoom.Name != request.Name)
        {
            bool isClassRoomNameExists = classRoomRepository.Any(p => p.Name == request.Name);
            if (isClassRoomNameExists)
            {
                throw new ArgumentException(MessageConstants.NameAlreadyExists);
            }
        }

        mapper.Map(request, classRoom);
        classRoom.UpdatedDate = DateTime.Now;
        classRoom.UpdatedBy = "Admin";

        classRoomRepository.Update(classRoom);
        return MessageConstants.UpdateIsSuccessfully;
    }
}
