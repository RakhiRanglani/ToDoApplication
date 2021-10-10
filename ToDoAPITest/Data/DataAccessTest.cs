using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPITest.Data
{
    public class DataAccessTest : IDataAccessTest
    {
        private List<ToDoItemModel> _todorepo = new()
        {
            new ToDoItemModel()
            {
                ItemId = 1,
                ItemName = "Orange Juice",
                ItemDescription = "Orange Tree",
                UserName = "Test",
                LastUpdated = DateTime.Now
            },
            new ToDoItemModel()
            {
                ItemId = 2,
                ItemName = "cloths shopping",
                ItemDescription = "need new pair shoes",
                UserName = "Test",
                LastUpdated = DateTime.Now
            },
        };
        public ToDoItemModel AddTask(string ItemName="medicine", string ItemDescription="Need to buy paracetamol", bool ItemStatus=true, string UserName="Test", DateTime LastUpdated=default(DateTime))
        {
            ToDoItemModel taskModel = new()
            {
                ItemName = ItemName,
                ItemDescription = ItemDescription,
                ItemStatus = ItemStatus,
                UserName = UserName,
                LastUpdated = LastUpdated
            };

            taskModel.ItemId = _todorepo.Any() ? _todorepo.Max(c => c.ItemId) + 1 : 0;

            _todorepo.Add(taskModel);
            return taskModel;
        }

        public void DeleteTask(int itemId=1)
        {
            var existing = _todorepo.First(a => a.ItemId == itemId);
            _todorepo.Remove(existing);
        }

        public List<ToDoItemModel> GetTask()
        {
            return _todorepo;
        }

        public ToDoItemModel GetTaskById(int itemId=1)
        {
            return _todorepo.Where(a => a.ItemId == itemId).FirstOrDefault();
        }

        public ToDoItemModel UpdateTask(int id, string ItemName, string ItemDescription, bool ItemStatus, string UserName, DateTime LastUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
