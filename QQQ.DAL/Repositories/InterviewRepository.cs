using QQQ.DAL.Data;
using QQQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QQQ.DAL.Repositories
{
    public class InterviewRepository : RepositoryBase<Interview>
    {
        public InterviewRepository(DataContext context)
            : base(context)
        {
            if (context==null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
