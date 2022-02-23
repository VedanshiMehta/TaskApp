using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskApp.Model;

namespace TaskApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class AddtaskActivity : Activity
    {
        private EditText myedittext;
        private Button mybutton;
        private TaskDataBase tDB;
        private TaskDataTable taskDataTable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addDataLayout);
            tDB = new TaskDataBase();
            tDB.TaskTable();

            myedittext = FindViewById<EditText>(Resource.Id.taskedts);
            mybutton = FindViewById<Button>(Resource.Id.taskadd);

            mybutton.Click += Mybutton_Click;

        }

        private void Mybutton_Click(object sender, EventArgs e)
        {
            string taskname = myedittext.Text;

            if (taskname != string.Empty)
            {
                taskDataTable = new TaskDataTable();

                taskDataTable.taskName = myedittext.Text;

                var ischeckinserted = tDB.InstertTask(taskDataTable);
                if (ischeckinserted == true)
                {

                    Toast.MakeText(this, "Data Inserted Succesfully", ToastLength.Short).Show();

                }
                else
                {

                    Toast.MakeText(this, "No action performed", ToastLength.Short).Show();


                }
                Intent k = new Intent(this, typeof(MainActivity));
                StartActivity(k);
            }
            else
            {

                Toast.MakeText(this, "Enter Task", ToastLength.Short).Show();

            }



        }
    }
}