using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SportsStore.Domain.Entities
{
    public partial class logDetail
    {
        [Key]
        public long ActionLogID { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public Nullable<System.DateTime> AccessDateTime { get; set; }
    }
}
