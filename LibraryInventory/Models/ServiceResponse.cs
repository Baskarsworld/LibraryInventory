using System.Net;

namespace LibraryInventory.Models
{
    public class ServiceResponse<T>
    {
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        public string? Error { get; set; }
        public T? Data { get; set; }
    }
}
