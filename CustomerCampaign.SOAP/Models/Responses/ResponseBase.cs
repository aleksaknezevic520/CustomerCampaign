namespace CustomerCampaign.SOAP.Models.Responses
{
    public class ResponseBase
    {
        public ResponseBase(string errorMessage)
        {
            Success = string.IsNullOrEmpty(errorMessage);
            ErrorMessage = errorMessage;
        }

        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
