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
using Java.Lang;

namespace Photo_Gallery
{
	[Activity(Label = "Gallery")]
	public class Gallery : Activity
	{
		Random rnd = new Random();
		ImageView[] images;
		Button prev, next;
		LinearLayout container;
		int current;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Gallery);
			Init();
			AddClicks();
		}

        private void AddClicks()
        {
            prev.Click += Prev_Click;
            next.Click += Next_Click;
        }

        private void Next_Click(object sender, EventArgs e)
        {
			current++;
			container.RemoveAllViews();
			container.AddView(images[current]);
            if (current == images.Length - 1)
            {
                next.Enabled = false;
            }
            else
            {
                next.Enabled = true;
                prev.Enabled = true;
            }
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            current--;
            container.RemoveAllViews();
            container.AddView(images[current]);
            if (current == 0)
            {
				prev.Enabled = false;
            }
            else
            {
                prev.Enabled = true;
                next.Enabled = true;
            }
        }

        private void Init()
        {
			images = GenerateImages();
			prev = FindViewById<Button>(Resource.Id.prev);
			next = FindViewById<Button>(Resource.Id.next);
			container = FindViewById<LinearLayout>(Resource.Id.imageContainer);
			prev.Enabled = false;
			current = 0;
			container.AddView(images[current]);
        }

        ImageView[] GenerateImages()
		{
			char[] types = { 's', 'c', 'h', 'd' };
			string am = Intent.GetStringExtra("amount");
			int amount = am == "" ? 1 : int.Parse(am);
			var images = new ImageView[amount];
			for (int i = 0; i < amount; i++)
			{
				images[i] = new ImageView(this);
				int num = rnd.Next(1, 14);
				char type = types[rnd.Next(4)];
				images[i].SetImageResource(base.Resources.GetIdentifier($"img{num}{type}", "drawable", this.PackageName));
			}
			return images;
		}

	}
}

