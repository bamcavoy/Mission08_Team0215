namespace Mission08_Team0215.Models;

public class EFUserTaskRepository : IUserTaskRepository
{
    private UserTaskFormContext _context;
    
    public EFUserTaskRepository(UserTaskFormContext temp)
    {
        _context = temp;
    }
    public List<UserTask> UserTask => _context.UserTask.ToList();

    public List<Category> Category => _context.Category.ToList();
    public void AddUserTask(UserTask userTask)
    {
        _context.Add(userTask);
        _context.SaveChanges();
    }


} 
