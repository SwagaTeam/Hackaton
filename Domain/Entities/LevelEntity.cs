using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LevelEntity
    {
        public int Id { get; set; }
        public int LevelNumber { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int? NextLevelId { get; set; }
        public int TestId { get; set; }
        public int TheoryId { get; set; }
        public virtual TheoryEntity Theory { get;set; }
        public virtual TestEntity Test { get; set; }

        public virtual LevelEntity? NextLevel { get; set; }
    }
}
