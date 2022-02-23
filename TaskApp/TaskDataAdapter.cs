using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskApp.Model;

namespace TaskApp
{
    class TaskDataAdapter : RecyclerView.Adapter
    {
        private List<TaskDataTable> viewatalist;
        private MainActivity mainActivity;
        private TaskDataBase tDB;
        private TaskDataTable taskdatatable;

        public TaskDataAdapter(List<TaskDataTable> viewatalist, MainActivity mainActivity)
        {
            this.viewatalist = viewatalist;
            this.mainActivity = mainActivity;
        }

        public override int ItemCount => viewatalist.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TaskViewHolder taskViewHolder = holder as TaskViewHolder;
            taskViewHolder.BindData(viewatalist[position]);
            taskViewHolder.mycancelbutton.Click += (s, e) => 
            {

                tDB = new TaskDataBase();
                taskdatatable = tDB.GetByUserId(viewatalist[position].taskid);

                if(taskdatatable != null)
                {

                    var isDeleted = tDB.DeleteTask(taskdatatable);
                    if (isDeleted== true)
                    {

                        Toast.MakeText(mainActivity, "Data Deleted Succesfully", ToastLength.Short).Show();

                    }
                    else
                    {

                        Toast.MakeText(mainActivity, "No action performed", ToastLength.Short).Show();


                    }

                }
                Intent j = new Intent(mainActivity, typeof(MainActivity));
                mainActivity.StartActivity(j);
                mainActivity.Finish();


            };

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.viewdataLayoutList,parent,false);
            return new TaskViewHolder(view);

        }
    }

    class TaskViewHolder : RecyclerView.ViewHolder
    {
        public TextView mytextView;
        public ImageView mycancelbutton;
        public TaskViewHolder(View itemView) : base(itemView)
        {
            mytextView = itemView.FindViewById<TextView>(Resource.Id.tasktext);
            mycancelbutton = itemView.FindViewById<ImageView>(Resource.Id.deletetext);
        }

        internal void BindData(TaskDataTable taskDataTable)
        {
            mytextView.Text = taskDataTable.taskName;
        }
    }
}