﻿using System.ComponentModel.DataAnnotations;
using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public class TodoItemCreateFields
    {
        public int TodoListId { get; set; }
        public string Title { get; set; }
        public string TodoListTitle { get; set; }
        [Range(1,100)]
        public int Rank { get; set; }
        [Display(Name = "Owner")] public string ResponsiblePartyId { get; set; }
        public Importance Importance { get; set; } = Importance.Medium;

        public TodoItemCreateFields()
        {
        }

        public TodoItemCreateFields(int todoListId, string todoListTitle, string responsiblePartyId)
        {
            TodoListId = todoListId;
            TodoListTitle = todoListTitle;
            ResponsiblePartyId = responsiblePartyId;
        }
    }
}