using Gusto.Entities.Responses.Abstract;

namespace Gusto.Entities.Responses.Concrete
{
    public class DataResponse : IViewResponse
    {
        public object Data { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}