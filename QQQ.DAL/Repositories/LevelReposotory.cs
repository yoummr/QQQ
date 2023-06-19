using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QQQ.Contracts.Repositories;
using QQQ.Model;
using QQQ.DAL.Data;

namespace QQQ.DAL.Repositories
{
    public class LevelReposotory : RepositoryBase<Level>
    {
        public LevelReposotory(DataContext context):base(context)
        {
            if (context==null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
