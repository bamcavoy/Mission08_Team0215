namespace Mission08_Team0215.Models
{
    public interface IUserTaskRepository
    {
        //template for the template
        List<UserTask> UserTask { get; }
        List<Category> Category { get; }
        public void AddUserTask(UserTask userTask);
    }
}