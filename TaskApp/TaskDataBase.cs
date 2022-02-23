using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskApp.Model;
using Environment = System.Environment;

namespace TaskApp
{
    class TaskDataBase
    {
        public static string DBNAme = "SQLite.db3";
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBNAme);

        SQLiteConnection sqliteConnection;

        public TaskDataBase()
        {
            try
            {
                Console.WriteLine(DBPath);
                sqliteConnection = new SQLiteConnection(DBPath);
                Console.WriteLine("Succefully Database Created!....");



            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }
        }

        public void TaskTable()
        {
            try
            {
                var created = sqliteConnection.CreateTable<TaskDataTable>();
                Console.WriteLine("Succefully Table Created!....");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }

        }

        public bool InstertTask(TaskDataTable taskDataTable)
        {


            long result = sqliteConnection.Insert(taskDataTable);



            if (result == -1)
            {

                return false;
            }

            else
            {
                Console.WriteLine("Succefully Inserted Data ");
                return true;
            }


        }
        public bool DeleteTask(TaskDataTable taskDataTable)
        {


            long result = sqliteConnection.Delete(taskDataTable);



            if (result == -1)
            {

                return false;
            }

            else
            {
                Console.WriteLine("Succefully Deleted Data ");
                return true;
            }


        }


        public List<TaskDataTable> ReadTask()
        {
            try
            {
                var staskDetails = sqliteConnection.Table<TaskDataTable>().ToList();
                return staskDetails;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                return null;
            }

        }

        public TaskDataTable GetByUserId(int tId)
        {
            var userId = sqliteConnection.Table<TaskDataTable>().Where(u => u.taskid == tId).FirstOrDefault();

            return userId;

        }

    }
}