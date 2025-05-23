﻿using System.Text.Json.Serialization;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ReviewerDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Type { get; set; } 

        public bool IsActive {  get; set; }

       
    }

    public class AllReviewersResponseDto
    {
        public List<ReviewerDTO> Reviewers { get; set; }
    }
}
