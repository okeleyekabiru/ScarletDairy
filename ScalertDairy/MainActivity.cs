using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Scalert_Dairy.Adapters;
using System;

namespace Scalert_Dairy
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private RecyclerView _noteRecyclerView;
        private RecyclerView.LayoutManager _notesLayoutManager;
        private NotesAdapter _notesAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            _noteRecyclerView = FindViewById<RecyclerView>(Resource.Id.notesRecyclerView);
            
            _notesLayoutManager = new LinearLayoutManager(this);
            //_pieLayoutManager = new GridLayoutManager(this, 2, GridLayoutManager.Horizontal, false);
            _noteRecyclerView.SetLayoutManager(_notesLayoutManager);

            _notesAdapter = new NotesAdapter();
            _notesAdapter.ItemClick += Notes_ItemClick;

            _noteRecyclerView.SetAdapter(_notesAdapter);


            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }

        private void Notes_ItemClick(object sender, int e)
        {
            //var intent = new Intent();
            //intent.SetClass(this, typeof(PieDetailActivity));
            //intent.PutExtra("selectedPieId", e);
            //StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    return true;
                case Resource.Id.navigation_dashboard:
                    return true;
                case Resource.Id.navigation_notifications:
                    return true;
            }
            return false;
        }
    }
}

