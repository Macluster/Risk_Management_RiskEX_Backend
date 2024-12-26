﻿using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<bool> AddDepartment(Department department);

    }
}