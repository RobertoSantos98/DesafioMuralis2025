namespace DesafioMuralis2025.Application.Utils
{
    public static class CepValidator
    {
        public static bool IsValidCep(string cep)
        {
            // Aqui vai remover qalquer caractere que não seja dígito
            var cleanedCep = new string(cep.Where(char.IsDigit).ToArray());
            // Aqui vai chegcar se o CEP tem exatamente 8 dígitos
            if (cleanedCep.Length != 8)
            {
                return false;
            }
            return true;
        }
    }
}
