﻿using System.ComponentModel.DataAnnotations;
using AzJobNest.Database.DomainModels;
using AzJobNest.Helpers.Enums;
namespace AzJobNest.ViewModels.Account.Advanced;

public class EditProfileViewModel
{
    [Required]
    [MinLength(3)]
    [Display(Name = "Username")]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    [Display(Name = "First Name")]
    public string? Name { get; set; }

    [MinLength(2, ErrorMessage = "Middle name must be at least 2 characters long")]
    [MaxLength(50, ErrorMessage = "Middle name cannot exceed 50 characters")]
    [Display(Name = "Middle Name")]
    public string? MiddleName { get; set; }

    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
    [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Display(Name = "CV/Resume")]
    [DataType(DataType.Upload)]
    public IFormFile? CVFile { get; set; }  // For file upload

    public string? CV { get; set; }  // Keep this to store the path/URL if needed

    [Display(Name = "Profile Picture")]
    [DataType(DataType.Upload)]
    public IFormFile? ProfilePictureFile { get; set; } //For profile picture upload
    public string? ProfilePicture { get; set; } //Keep this to store the path/URL if needed

    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Url(ErrorMessage = "Please enter a valid URL")]
    [MaxLength(100, ErrorMessage = "LinkedIn URL cannot exceed 100 characters")]
    [Display(Name = "LinkedIn Profile")]
    public string? LinkedInUrl { get; set; }

    [Url(ErrorMessage = "Please enter a valid URL")]
    [MaxLength(100, ErrorMessage = "GitHub URL cannot exceed 100 characters")]
    [Display(Name = "GitHub Profile")]
    public string? GitHubUrl { get; set; }

    [Display(Name = "Gender")]
    public Gender? Gender { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Birth Date")]
    public DateTime? BirthDate { get; set; }

    // Project properties
    public int? ProjectId { get; set; }

    [Required]
    [Display(Name = "Project Name")]
    public string ProjectName { get; set; }

    [Display(Name = "Project Description")]
    public string ProjectDescription { get; set; }

    [Required]
    [Url]
    [Display(Name = "Repository URL")]
    public string RepositoryUrl { get; set; }

    [Url]
    [Display(Name = "Deployment URL")]
    public string DeploymentUrl { get; set; }

    [Required]
    [Display(Name = "Source")]
    public string ProjectSource { get; set; }
}