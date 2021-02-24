using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testService.Model
{
    public class RightTab
    {
        [Key]
        public int Id { get; set; }
      
        public string RepoTitle { get; set; }
        
        public string RepoDesp { get; set; }
       
        public string RepoUrl { get; set; }
        public string SendMail { get; set; }
        public DateTime SendTime { get; set; }
    }
}
