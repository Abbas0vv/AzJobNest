﻿using System.ComponentModel.DataAnnotations;
using AzJobNest.Database.Abstracts;
using AzJobNest.Helpers.Enums;
using Microsoft.AspNetCore.Identity;

namespace AzJobNest.Database.DomainModels;

public class AzJobNestUser : IdentityUser
{

    [MinLength(2), MaxLength(50)]
    public string? Name { get; set; }

    [MinLength(2), MaxLength(50)]
    public string? MiddleName { get; set; }

    [MinLength(2), MaxLength(50)]
    public string? LastName { get; set; }

    [MaxLength(250)]
    public string? CV { get; set; }

    [MaxLength(250)]
    public string? ProfilePicture { get; set; }

    [Phone]
    [MaxLength(20)]
    public override string? PhoneNumber { get; set; }

    [Url]
    [MaxLength(100)]
    public string? LinkedInUrl { get; set; }

    [Url]
    [MaxLength(100)]
    public string? GitHubUrl { get; set; }

    public Gender? Gender { get; set; }

    [DataType(DataType.Date)]
    public DateTime? BirthDate { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public List<Project> Projects { get; set; }     
}

