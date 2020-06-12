using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class LogProcessToDB : Ilogger
    {
        public void LoginDb(logDetail logDetails)
        {
            try
            {
                EFDbcontext EF = new EFDbcontext();
              //  EF.logDetail.Add(logDetails);
                EF.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
          
           // throw new NotImplementedException();
        }
    }
}
