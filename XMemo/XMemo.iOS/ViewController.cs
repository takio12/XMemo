using System;

using UIKit;

namespace XMemo.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            MemoHolder.Current.Memo = new InsufficientMemoryException()
            {
                Date = DateTime.Now,
                Subject = "",
                Text = "",
            };
            DisplayMemo();
		}

        private void DisplayMemo()
        {
            var memo = MemoHolder.Current.Memo;
            DateText.Text = string.Format("{0:yyyy/MM/dd}", memo.Date);
            SubjectText.Text = memo.Subject;
            MemoText.Text = memo.Text;
        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

