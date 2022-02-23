using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskApp.Model
{
    [Table("TaskTable")]
    class TaskDataTable
    {
        [Column("TaskId")]
        [PrimaryKey,AutoIncrement]
        public int taskid { get; set; }

        [Column("TaskName")]
        public string taskName { get; set; }
    }
}