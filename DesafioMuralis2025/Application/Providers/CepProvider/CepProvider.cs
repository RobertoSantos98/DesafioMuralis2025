using DesafioMuralis2025.Domain.DTOs;
using System.Text.Json;


namespace DesafioMuralis2025.Application.Providers.CepProvider
{
    public class CepProvider : ICepProvider
    {
        private readonly HttpClient _httpClient;
        public CepProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<EnderecoDTO?> GetAddressByCepAsync(string cep)
        {
            try
            {

                string URL = $"https://viacep.com.br/ws/{cep}/json/";

                var response = await _httpClient.GetAsync(URL);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Endereço não encontrado para o CEP informado.");
                }

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ApiResponse>(content);

                var enderecoDTO = new EnderecoDTO
                (
                    result.cep,
                    result.logradouro ?? string.Empty,
                    result.localidade ?? string.Empty,
                    string.Empty,
                    result.complemento ?? string.Empty
                );

                return enderecoDTO;


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter o endereço pelo CEP.", ex);
            }

        }

        public class ApiResponse()
        {
            public string cep { get; set; }
            public string? logradouro { get; set; }
            public string? complemento { get; set; }
            public string? unidade { get; set; }
            public string? bairro { get; set; }
            public string? localidade { get; set; }
            public string? uf { get; set; }
            public string? estado { get; set; }
            public string? regiao { get; set; }
            public string? ibge { get; set; }
            public string? gia { get; set; }
            public string? ddd { get; set; }
            public string? siafi { get; set; }
        }
    }
}
