namespace Xolit.Whatsapp.DataTransferObjects.QueryObjects.Base
{
    public class PageResultBase
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int CurrentPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
