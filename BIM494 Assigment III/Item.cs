using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BIM494_Assigment_III
{
    public class Item : Java.Lang.Object
    {
        //public int OBJECTID { get; set; }
        //public string Province_State { get; set; }
        public string country { get; set; }
        //public object Last_Update { get; set; }
        //public double? Lat { get; set; }
        //public double? Long_ { get; set; }
        public int confirmed { get; set; }
        public int recovered { get; set; }
        public int deaths { get; set; }
        //public int Active { get; set; }
        //public object Admin2 { get; set; }
        //public object FIPS { get; set; }
        //public string Combined_Key { get; set; }

        public Item(string country, int confirmed, int recovered, int deaths)
        {
            this.country = country;
            this.confirmed = confirmed;
            this.recovered = recovered;
            this.deaths = deaths;

        }
    }

    
}