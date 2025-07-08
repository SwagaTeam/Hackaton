namespace Domain.Entities;

public class TestEntity
{
    public int Id { get; set; }
    public virtual ICollection<QuestionEntity> Questions { get; set; }
}