using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public interface ITask
    {
        void Addtask(Task_Ex1 task);
        void Removetask(int indexTask);
        void CompleteTask(int indexTask);
        void DisplayTask();
    }

    public class Task_Ex1
    {
        public string Titel { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class TaskList : ITask
    {
        public List<Task_Ex1> ListTask { get; set; }

        public void Addtask(Task_Ex1 task)
        {
            ListTask.Add(task);
        }
        public void Removetask(int indexTask)
        {
            ListTask.Remove(ListTask[indexTask - 1]);
        }
        public void CompleteTask(int indexTask)
        {
            Console.WriteLine(ListTask.Select(item => ListTask[indexTask].IsCompleted));
        }
        public void DisplayTask()
        {
            foreach (var item in ListTask)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TaskList taskList = new TaskList();
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Удалить задачу");
                Console.WriteLine("3. Отметить задачу как выполненную");
                Console.WriteLine("4. Вывести список задач");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите название задачи: ");
                        var titel = Console.ReadLine();
                        Console.WriteLine("Введите описание задачи: ");
                        var description = Console.ReadLine();
                        taskList.Addtask(new Task_Ex1()
                        {
                            Titel = titel,
                            Description = description,
                            IsCompleted = false
                        });
                        break;
                    case "2":
                        Console.WriteLine("Введите номер задачи: ");
                        var index = Console.ReadLine();
                        taskList.Removetask(Convert.ToInt32(index));
                        break;
                    case "3":
                        Console.WriteLine("Введите номер задачи: ");
                        var indexComp = Console.ReadLine();
                        taskList.Removetask(Convert.ToInt32(indexComp));
                        break;
                    case "4":
                        taskList.DisplayTask();
                        break;
                    case "5":
                        break;
                }
            }
        }
    }
}