using InformationFlow.Entity;
using InformationFlow.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationFlow.BLL
{
    public class MessageBoardBll
    {
        public void Add(MessageBoard model)
        {
            using (var db = new CRMDBContext())
            {
                db.MessageBoards.Add(model);
                db.SaveChanges();
            }
        }
    }
}
