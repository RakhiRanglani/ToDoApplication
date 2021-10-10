using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPI.Data
{
    public interface IDataAccess
    {
        List<ToDoItemModel> GetTask(string user);
        ToDoItemModel AddTask(string ItemName, string ItemDescription, bool ItemStatus, string UserName, DateTime LastUpdated);

        Task<int> DeleteTask(int itemId);

        ToDoItemModel UpdateTask(int id , string ItemName, string ItemDescription, bool ItemStatus, string UserName, DateTime LastUpdated);

      
    }
}
