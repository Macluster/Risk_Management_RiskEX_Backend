﻿using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddUserToDepartment(UsersDTO userDto, int? currentUserId = null);
    }
}