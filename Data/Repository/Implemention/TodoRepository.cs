using Microsoft.EntityFrameworkCore;
using MyTodo.Data;
using MyTodo.Data.Repository;
using MyTodo.Data.Repository.Interface;
using MyTodo.Models;

namespace MyTodo.Data.Repository.Implemention;

public class TodoRepository : RepositoryBase<Todo>, ITodoRepository
{
    public TodoRepository(AppDbContext context)
        : base(context) { }
}
