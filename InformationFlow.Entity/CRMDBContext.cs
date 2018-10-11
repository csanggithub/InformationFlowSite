using InformationFlow.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationFlow.Entity
{
    public class CRMDBContext : DbContext
    {
        public CRMDBContext() : base("name=CRMDB")
        {
        }
        public DbSet<MessageBoard> MessageBoards { get; set; }
        public DbSet<SendSmsLog> SendSmsLogs { get; set; }
    }
}
