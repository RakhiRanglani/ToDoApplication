using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPITest.Data
{
    public interface IDataAccessTest
    {
        List<ToDoItemModel> GetTask();
        ToDoItemModel AddTask(string ItemName, string ItemDescription, bool ItemStatus, string UserName, DateTime LastUpdated);

        void DeleteTask(int itemId);

        ToDoItemModel UpdateTask(int id, string ItemName, string ItemDescription, bool ItemStatus, string UserName, DateTime LastUpdated);

        ToDoItemModel GetTaskById(int itemId);
    }
}
