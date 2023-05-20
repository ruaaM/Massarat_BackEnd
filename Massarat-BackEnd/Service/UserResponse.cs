namespace Massarat_BackEnd.Service
{
	public class UserResponse
	{
        public string Message { get; set; }
        public bool isSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
