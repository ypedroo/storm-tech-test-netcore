using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Data.Entities;

namespace Todo.Services
{
    public static class ApplicationDbContextConvenience
    {
        public static IQueryable<TodoList> RelevantTodoLists(this ApplicationDbContext dbContext, string userId)
        {
            var userTodoLists = dbContext.TodoLists.Include(tl => tl.Owner)
                .Include(tl => tl.Items)
                .ThenInclude(ti => ti.ResponsibleParty)
                .Where(tl => tl.Owner.Id == userId || tl.Items.Any(ti => ti.ResponsibleParty.Id == userId));

            return userTodoLists;
        }

        public static TodoList SingleTodoList(this ApplicationDbContext dbContext, int todoListId)
        {
            var list = dbContext.TodoLists.Include(tl => tl.Owner)
                .Include(tl => tl.Items)
                .ThenInclude(ti => ti.ResponsibleParty)
                .Single(tl => tl.TodoListId == todoListId);
            list.Items = list.Items.OrderBy(i => i.Importance).ToList();

            return list;
        }

        public static TodoItem SingleTodoItem(this ApplicationDbContext dbContext, int todoItemId)
        {
            return dbContext.TodoItems.Include(ti => ti.TodoList).Single(ti => ti.TodoItemId == todoItemId);
        }
    }
}