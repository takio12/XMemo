﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XMemo.Droid
{
	[Activity (Label = "XMemo.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            MemoHolder.Current.Memo = new Memo();
            {
                Date = DateTime.Now,
                Subject = "",
                Text = "",
            };
            DisplayMemo();
		}
        private void DisplayMemo()
        {
            var memo = MemoHolder.Curren.Memo;
            FindViewById<EditText>(Resource.Id.DateText).Text = string.
                Format("{0:yyyy/MM/dd}", memo.Date);
            FindViewById<EditText>(Resource.Id.SubjectText).Text = memo.Subject;
            FindViewById<TextView>(Resource.Id.MemoText).Text = memo.Text;
        }
    }
}


