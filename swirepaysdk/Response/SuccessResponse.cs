using Newtonsoft.Json.Linq;
using swirepaysdk.Model.Payments;
using System;
using System.Collections.Generic;

namespace swirepaysdk.Model
{
    public class SuccessResponse<T>: BaseResponse<T>
    {
       
    }


    public class SuccessPageResponse<T> : BaseResponse<T> { }

    public class BaseResponse<T>
    {
        public string message { get; set; }
        public int responseCode { get; set; }
        public string status { get; set; }
        public T entity { get; set; }
    }

    class ContentResponse<T> : PageResponse
    {
        List<T> content = null;
    }

    class PageResponse
    {
     string pageable = null;
     string first = null;
     String number= null;
     bool last = false;
     string totalElements = null;
     string totalPages=null;
     string size = null;
     string numberOfElements= null;
     string sort = null;
     bool empty = false;
}
}