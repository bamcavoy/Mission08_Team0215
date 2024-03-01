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

    public void EditUserTask(UserTask editUserTask)
    {
        _context.Update(editUserTask);
        _context.SaveChanges();
    }
    public void DeleteUserTask(UserTask deleteUserTask)
    {
        _context.Remove(deleteUserTask);
        _context.SaveChanges();
    }

} 
