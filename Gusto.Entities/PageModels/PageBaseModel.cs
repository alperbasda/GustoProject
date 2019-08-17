namespace Gusto.Entities.PageModels
{
    public class PageBaseModel
    {

        public object TableData { get; set; }

        public int TotalPage { get; set; }

        public int TotalData { get; set; }

        public int CurrentPage { get; set; }
        
    }
}