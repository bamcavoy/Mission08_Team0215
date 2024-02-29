namespace Mission08_Team0215.Models
{
    public class EFUserTaskRepository : IUserTaskRepository
    {
        private UserTaskFormContext _context;
        
        public EFUserTaskRepository(UserTaskFormContext temp)
        {
            _context = temp;
        }
        //public List<UserTask> UserTasks => _context.UserTasks.ToList();
        public void AddUserTask(UserTask userTask)
        {
            _context.Add(userTask);
            _context.SaveChanges();
        }


    } 
}
