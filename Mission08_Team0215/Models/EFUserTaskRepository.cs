using Microsoft.Extensions.Logging;
using System;
using System.Linq;
namespace Mission08_Team0215.Models;
public class EFUserTaskRepository : IUserTaskRepository
{
    private readonly UserTaskFormContext _context; // Only declare _context once and make it readonly
    private readonly ILogger _logger; // Declare _logger as readonly as well
    // Constructor
    public EFUserTaskRepository(UserTaskFormContext temp, ILogger<EFUserTaskRepository> logger)
    {
        _context = temp; // Assign the constructor parameter to the _context field
        _logger = logger; // Assign the constructor parameter to the _logger field
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
    public void DeleteUserTask(int taskId)
    {
        var taskToDelete = _context.UserTask.FirstOrDefault(t => t.TaskId == taskId);
        if (taskToDelete != null)
        {
            _logger.LogInformation($"Deleting UserTask with TaskId: {taskId}");
            _context.UserTask.Remove(taskToDelete);
            _context.SaveChanges();
            _logger.LogInformation($"UserTask with TaskId: {taskId} has been successfully deleted.");
        }
        else
        {
            _logger.LogWarning($"Attempted to delete UserTask with TaskId: {taskId}, but it was not found.");
            // Handle the case where the task is not found. You could throw an exception or handle it differently.
        }
    }
}
