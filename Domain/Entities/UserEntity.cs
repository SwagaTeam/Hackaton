namespace Domain.Entities;

namespace Domain.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsAdmin { get; set; }
        public int CurrentLevelNumber { get; set; }
    }
}
