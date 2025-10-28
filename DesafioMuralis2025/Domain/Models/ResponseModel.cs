namespace DesafioMuralis2025.Domain.Models
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public T? Data { get; set; }

        public ResponseModel(bool success, string errorMessage, T dados)
        {
            IsSuccess = success;
            ErrorMessage = errorMessage;
            Data = dados;
        }

        public ResponseModel(bool sucess)
        {
            IsSuccess = sucess;
        }

        public static ResponseModel<T> Success(T data) => new ResponseModel<T>(true, string.Empty, data);

        public static ResponseModel<T> Failure(string errorMessage) => new ResponseModel<T>(false, errorMessage, default!);
    }
}
