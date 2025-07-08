using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TestEntity
    {
        public int Id { get; set; }
        public virtual ICollection<QuestionEntity> Questions { get; set; }

    }
}
