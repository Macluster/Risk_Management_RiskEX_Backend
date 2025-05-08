﻿using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<bool> AddDepartment(DepartmentDTO departmentDto);

        Task<bool> UpdateDepartment(DepartmentUpdateDTO departmentUpdateDTO);

        Task<Department> GetDepartmentByName(string departmentName);
        Task<Department> GetDepartmentById(string departmentId);

    }
}
