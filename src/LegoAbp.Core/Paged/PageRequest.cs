using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LegoAbp.Paged
{
    public class PageRequest
    {
        public PageRequest()
        {
            Current = 1;
            Sorter = "creationTime";
            PageSize = 10;
            SortDirection = "descend";
        }
        private int _pageSize;
        [Display(Name = "current")]
        [JsonProperty("current")]
        public int Current { get; set; }
        [JsonProperty("pageSize")]
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value > 50)
                {
                    _pageSize = 50;
                }
                else
                {
                    _pageSize = value;
                }
            }
        }
        [JsonProperty("sorter")]
        public string Sorter { get; set; }
        [JsonProperty("order")]
        public string SortDirection { get; set; }
    }
}
