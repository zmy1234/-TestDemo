using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testService.View
{
    public class SaveDataDto
    {
        public string SendEmail { get; set; }
        public List<int> LeftTabIds { get; set; }
    }
}
