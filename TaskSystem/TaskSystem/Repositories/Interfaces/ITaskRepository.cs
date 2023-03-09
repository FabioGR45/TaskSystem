using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    public interface ITaskRepository
    {

        Task<List<TaskModel>> SearchAllTasks();
        Task<TaskModel> SearchTaskById(int taskId);
        Task<TaskModel> AddTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task, int taskId);
        Task<bool> DeleteTask(int taskId);

    }
}
