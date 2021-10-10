﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Command;
using ToDoAPI.Models;
using ToDoAPI.Queries;

namespace ToDoAPI.Data
{
    public class DataAccess : IDataAccess
    {
        private List<ToDoItemModel> _todorepo = new();
        private readonly ApplicationDbContext _context;

        public DataAccess(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddTask(ToDoItemModel taskModel)
        {
            _context.ToDoItems.Add(taskModel);
            await _context.SaveChangesAsync();
            return taskModel.ItemId;

        }

        public List<ToDoItemModel> GetTask()
        {
            _todorepo = _context.ToDoItems.ToList();
            return _todorepo;
        }


        public async Task<int> DeleteTask(int itemId)
        {
            var toDoItemModel =  _context.ToDoItems.Where(a => a.ItemId == itemId).FirstOrDefault();
            if (toDoItemModel == null) return default;
            _context.ToDoItems.Remove(toDoItemModel);
            await _context.SaveChangesAsync();
            return itemId;
           
        }

        public async Task<ToDoItemModel> GetTaskById(int itemId)
        {
            var toDoItemModel = await _context.ToDoItems.FindAsync(itemId);
            return toDoItemModel;
        }

        public ToDoItemModel AddTask(string ItemName, string ItemDescription, bool ItemStatus, string UserName, DateTime LastUpdated)
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

            _context.ToDoItems.Add(taskModel);
            _context.SaveChangesAsync();
            return taskModel;

        }

        public ToDoItemModel UpdateTask(int id, string ItemName, string ItemDescription, bool ItemStatus, string UserName, DateTime LastUpdated)
        {
            ToDoItemModel taskModel = new()
            {
                ItemName = ItemName,
                ItemDescription = ItemDescription,
                ItemStatus = ItemStatus,
                UserName = UserName,
                LastUpdated = LastUpdated
            };
            taskModel.ItemId = id;

            _context.Entry(taskModel).State = EntityState.Modified;
            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return taskModel;
        }
    }
}
