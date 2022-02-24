using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using TaskApp.Model;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace TaskApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Toolbar toolbar;
        private ImageView addData;
        private RecyclerView myreV;
        private List<TaskDataTable> viewatalist;
        private TaskDataBase tDB;
        private TaskDataAdapter taskapater;
        private RecyclerView.LayoutManager mypreview;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

        
            toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar1);
            addData = FindViewById<ImageView>(Resource.Id.addB);
            myreV = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            addData.Click += AddData_Click;

            GetTaskData();

            myreV.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Vertical));
            mypreview = new LinearLayoutManager(this);
            myreV.SetLayoutManager(mypreview);

            taskapater = new TaskDataAdapter(viewatalist, this);
            myreV.SetAdapter(taskapater);

           
        }

        private List<TaskDataTable> GetTaskData()
        {
          
           
                tDB = new TaskDataBase();
                var taskdata = tDB.ReadTask();

                viewatalist = new List<TaskDataTable>();

                viewatalist.AddRange(taskdata);

                return viewatalist;
            
        }

        private void AddData_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(AddtaskActivity));
            StartActivity(i);
      
        }


    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}