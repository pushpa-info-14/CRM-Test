using CRMTest.Domain.Entities;

namespace CRMTest.Services;

public class CustomerApiService
{
	private readonly HttpClient _http;

	public CustomerApiService(HttpClient http)
	{
		_http = http;
	}

	public async Task<List<Customer>?> GetCustomersAsync()
		=> await _http.GetFromJsonAsync<List<Customer>>("api/customer");

	public async Task<Customer?> GetCustomerAsync(int id)
		=> await _http.GetFromJsonAsync<Customer>($"api/customer/{id}");

	public async Task<bool> CreateCustomerAsync(Customer customer)
	{
		var response = await _http.PostAsJsonAsync("api/customer", customer);
		return response.IsSuccessStatusCode;
	}

	public async Task<bool> UpdateCustomerAsync(Customer customer)
	{
		var response = await _http.PutAsJsonAsync($"api/customer/{customer.AccountId}", customer);
		return response.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteCustomerAsync(int id)
	{
		var response = await _http.DeleteAsync($"api/customer/{id}");
		return response.IsSuccessStatusCode;
	}
}