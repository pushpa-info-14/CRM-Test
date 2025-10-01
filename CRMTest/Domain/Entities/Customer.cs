using System.ComponentModel.DataAnnotations;

namespace CRMTest.Domain.Entities;

public class Customer
{
	[Key]
	public int AccountId { get; set; }

	[Required]
	public string FirstName { get; set; } = string.Empty;

	[Required]
	public string LastName { get; set; } = string.Empty;

	[Required]
	[EmailAddress]
	public string Email { get; set; } = string.Empty;

	public string? PhoneNumber { get; set; }

	public string? Address { get; set; }

	public string? City { get; set; }

	public string? State { get; set; }

	public string? Country { get; set; }

	public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}