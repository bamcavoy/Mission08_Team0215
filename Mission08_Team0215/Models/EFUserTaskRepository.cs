namespace Mission08_Team0215.Models
{
    public class EFUserTaskRepository(UserTaskFormContext temp) : IUserTaskRepository
    {
        private UserTaskFormContext _context = temp;

        public object Category { get; internal set; }
        public object UserTask { get; internal set; }

        //public List<UserTask> UserTasks => _context.UserTasks.ToList();
        public void AddUserTask(UserTask userTask)
        {
            _context.Add(userTask);
            _context.SaveChanges();
        }


    } 
}
