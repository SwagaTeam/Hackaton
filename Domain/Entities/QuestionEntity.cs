using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuestionEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TestId { get; set; }
        public int? CorrectAnswerId { get; set; }
        public virtual TestEntity Test { get; set; }
        public virtual ICollection<AnswerEntity> Answers { get; set; } // Варианты ответов
        public virtual AnswerEntity CorrectAnswer { get; set; } // Навигация к правильному ответу
    }
}
