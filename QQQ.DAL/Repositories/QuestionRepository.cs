using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QQQ.Model;
using QQQ.DAL.Data;


namespace QQQ.DAL.Repositories
{
    public class QuestionRepository:RepositoryBase<Question>
    {

        public QuestionRepository(DataContext context) : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
