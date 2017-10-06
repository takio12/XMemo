using System;

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

            MemoHolder.Current.Memo = new Memo()
            {
                Date = DateTime.Now,
                Subject = "",
                Text = "",
            };
            DisplayMemo();

            var subjectText = FindViewById<EditText>(Resource.Id.SubjectText);
            subjectText.TextChanged += (s, e) =>
            {
                MemoHolder.Current.Memo.Subject = subjectText.Text;
            };
            var memoText = FindViewById<EditText>(Resource.Id.MemoText);
            memoText.TextChanged += (s, e) =>
            {
                MemoHolder.Current.Memo.Text = memoText.Text;
            };

            FindViewById<EditText>(Resource.Id.DateText).Click += DateText_Click;
        }

        private void DateText_Click(object sender,EventArgs e)
        {
            var datePicker = new MyDatePicker();
            datePicker.InitialDate = MemoHolder.Current.Memo.Date;
            datePicker.Selected += (s2, e2) =>
            {
                MemoHoldre.Current.Memo.Date = e2.SelectedDate;
                DisplayMemo();
            };
            datePicker.show(FragmentManager, "tag");
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


