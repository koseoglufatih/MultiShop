﻿using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", createContactDto);

        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("contacs?id=" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var responseMessage = await _httpClient.GetAsync("contacts");
            responseMessage.EnsureSuccessStatusCode();

            var values = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultContactDto>>(values);


        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
            return values;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("contacts", updateContactDto);
        }
    }
}
