using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testService.Model
{
    public class LeftTab
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string RepoTitle { get; set; }
        [Required, MaxLength(255)]
        public string RepoDesp { get; set; }
        [Required, MaxLength(255)]
        public string RepoUrl { get; set; }
        public DateTime AddTime { get; set; }
        
    }
}
