using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly TaskSystemDBContext _dbContext;

        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<List<TaskModel>> SearchAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> SearchTaskById(int id)
        {

            TaskModel task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                throw new Exception($"Task with Id: {id} was not found!");
            }

            return task;
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel taskById = await SearchTaskById(id);

            if(taskById == null)
            {
                throw new Exception($"Task with Id: {id} was not found!");
            }

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;

        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskById = await SearchTaskById(id);

            if (taskById == null)
            {
                throw new Exception($"Task with Id: {id} was not found!");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
