using CRMTest.Domain.Entities;
using CRMTest.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRMTest.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerRepository repository) : ControllerBase
{
	private readonly ICustomerRepository _repository = repository;

	[HttpGet]
	public async Task<IActionResult> GetAll() =>
		Ok(await _repository.GetAllAsync());

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var customer = await _repository.GetByIdAsync(id);
		return customer == null ? NotFound() : Ok(customer);
	}

	[HttpPost]
	public async Task<IActionResult> Create(Customer customer)
	{
		var created = await _repository.AddAsync(customer);
		return CreatedAtAction(nameof(GetById), new { id = created.AccountId }, created);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, Customer customer)
	{
		if (id != customer.AccountId) return BadRequest();
		await _repository.UpdateAsync(customer);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		await _repository.DeleteAsync(id);
		return NoContent();
	}
}