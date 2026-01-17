using System.Diagnostics;
using DataAccessAPI.Interfaces;
using DataAccessAPI.Repositories;
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

    /// <summary>
    /// Adds the new grade.
    /// </summary>
    /// <param name="createdGrade">The created grade DTO.</param>
    /// <param name="userId">The user identifier from JWT.</param>
    /// <returns>
    /// The created game DTO.
    /// </returns>
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

    /// <summary>
    /// Gets grades by user identifier.
    /// </summary>
    /// <param name="id">The user identifier from JWT.</param>
    /// <returns>
    /// Collection of GradeDtos.
    /// </returns>
    public IEnumerable<GradeDto> GetGradesByUserId(int id)
    {
        List<GradeT> grades = _repository.GetGradesByUserId(id).ToList();
        if (!grades.Any())
        {
            return null;
        }
        List<GradeDto> gradesDto = new List<GradeDto>();

        foreach (GradeT gradeModel in grades)
        {
            GradeDto gradeDto = new GradeDto
            {
                Id = gradeModel.Id,
                ApproverName = $"{gradeModel.Approver.FirstName} {gradeModel.Approver.LastName}",
                Class = gradeModel.Class,
                CreatorName = $"{gradeModel.Creator.FirstName} {gradeModel.Creator.LastName}",
                CreationDate = gradeModel.CreationDate,
                FirstName = gradeModel.FirstName,
                LastName = gradeModel.LastName,
                Grade = gradeModel.Grade,
                Remark = gradeModel.Remark,
                Status = gradeModel.Status.Name,
                Subject = gradeModel.Subject,
                Rounding = gradeModel.Rounding.Name
            };
            gradesDto.Add(gradeDto);
        }
        return gradesDto;
    }

    /// <summary>
    /// Updates the status of the grade by identifier.
    /// </summary>
    /// <param name="updatedGrade">The updated grade.</param>
    /// <param name="id">The identifier.</param>
    /// <returns>
    /// 1 if success, 0 if not.
    /// </returns>
    public int UpdateGradeStatusById(UpdateGradeDto updatedGrade, int id, int userId)
    {
        if (updatedGrade == null)
        {
            return 0;
        }

        GradeT foundModel = _repository.GetGradeById(id);
        if (foundModel == null || foundModel.ApproverId != userId)
        {
            return 0;
        }

        foundModel.StatusId = updatedGrade.StatusId;

        _repository.UpdateGradeStatusById(foundModel);

        return 1;
    }
}
