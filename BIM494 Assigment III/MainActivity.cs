using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Org.Json;
using System.Collections.Generic;

namespace BIM494_Assigment_III
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView textView;
        private Button button;
        ItemManager itemManager;
        string s = "";
        List<Item> items = new List<Item>();
        private ListView listView;
        private ItemAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            itemManager = new ItemManager();
            listView = FindViewById<ListView>(Resource.Id.listview);
            adapter = new ItemAdapter(ApplicationContext, items);
            listView.Adapter = adapter;
            OnSendButtonClicked();
        }


        private async void OnSendButtonClicked()
        {
            s = await itemManager.GetData();
            JSONObject obj = new JSONObject(s);
            var arr = obj.GetJSONArray("features");
            for (int i = 0; i < arr.Length(); i++)
            {
                string country = arr.GetJSONObject(i).GetJSONObject("attributes").GetString("Country_Region");
                int confirmed = Int32.Parse(arr.GetJSONObject(i).GetJSONObject("attributes").GetString("Confirmed"));
                int recovered = Int32.Parse(arr.GetJSONObject(i).GetJSONObject("attributes").GetString("Recovered"));
                int deaths = Int32.Parse(arr.GetJSONObject(i).GetJSONObject("attributes").GetString("Deaths"));
                Item item = new Item(country, confirmed, recovered, deaths);
                items.Add(item);
            }
            adapter.NotifyDataSetChanged();
        }
    }
}