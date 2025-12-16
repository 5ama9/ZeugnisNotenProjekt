using DataAccessAPI.Interfaces;
using ServiceAPI.Interfaces;
using Shared.Models;
using Shared.Models.DTOs;

namespace ServiceAPI.Services;

public class GradeService : IGradeService
{
    IGradeRepository _repository;
    public GradeService(IGradeRepository repository)
    {
        _repository = repository;
    }

    public GradeDto AddNewGrade(CreateGradeDto createdGrade, int userId)
    {
        if (createdGrade == null)
        {
            return null;
        }

        GradeT createGradeModel = new GradeT
        {
            ApproverId = createdGrade.ApproverId,
            Class = createdGrade.Class,
            Subject = createdGrade.Subject,
            CreationDate = DateTime.Now,
            CreatorId = userId,
            StatusId = 1,
            RoundingId = createdGrade.RoundingId,
            Grade = createdGrade.Grade,
            Remark = createdGrade.Remark,
            FirstName = createdGrade.FirstName,
            LastName = createdGrade.LastName
        };
        GradeT gradeModel = _repository.CreateNewGrade(createGradeModel);
        if (gradeModel == null)
        {
            return null;
        }

        GradeDto result = new GradeDto
        {
            Id = gradeModel.Id,
            ApproverName = $"{gradeModel.Approver.FirstName} {gradeModel.Approver.LastName}",
            Class = gradeModel.Class,
            CreatorName = $"{gradeModel.Creator.FirstName} {gradeModel.Creator.LastName}",
            CreationDate = gradeModel.CreationDate,
            FirstName = gradeModel.FirstName,
            LastName = gradeModel.LastName,
            Grade = gradeModel.Grade,
            Remark= gradeModel.Remark,
            Status = gradeModel.Status.Name,
            Subject = gradeModel.Subject,
            Rounding = gradeModel.Rounding.Name
        };
        return result;
    }
}
