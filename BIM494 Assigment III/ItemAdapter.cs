using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace BIM494_Assigment_III
{
    public class ItemAdapter : BaseAdapter
    {
        private LayoutInflater inflater;
        private List<Item> items;
        private Context context;

        public ItemAdapter(Context context, List<Item> items)
        {
            this.items = items;
            this.context = context;
            inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
        }

        public override int Count => items.Count;

        public override Object GetItem(int position)
        {
            return (Object)items.ElementAt(position);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = inflater.Inflate(Resource.Layout.listview_single_row, null, false);
            TextView countryTW = view.FindViewById<TextView>(Resource.Id.country_textview);
            TextView recoveredTW = view.FindViewById<TextView>(Resource.Id.recovered_textview);
            TextView confirmedTW = view.FindViewById<TextView>(Resource.Id.confirmed_textview);
            TextView deathsTW = view.FindViewById<TextView>(Resource.Id.deaths_textview);
            Item item = items[position];
            countryTW.Text = item.country;
            recoveredTW.Text = item.recovered + "";
            confirmedTW.Text = item.confirmed + "";
            deathsTW.Text = item.deaths + "";
            return view;
        }
    }
}