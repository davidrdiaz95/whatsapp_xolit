using System.Collections.Generic;
using Xolit.Whatsapp.DataTransferObjects.QueryObjects.Base;

namespace Xolit.Whatsapp.DataTransferObjects.QueryObjects
{
    public class PagedResultDTO<T> : PageResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResultDTO()
        {
            Results = new List<T>();
        }
    }
}
