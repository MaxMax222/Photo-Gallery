
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

namespace Photo_Gallery
{
	[Activity (Label = "Grid")]			
	public class Grid : Activity
	{
		LinearLayout main;
		Random rnd = new Random();
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Grid);
			main = FindViewById<LinearLayout>(Resource.Id.mainLayout);
            GenerateGrid(); 

		}

		void GenerateGrid()
		{
            string v = Intent.GetStringExtra("amount");
            int imgToShow = v == "" ? 0 : int.Parse(v);
            char[] types = { 's', 'c', 'h', 'd' };
            LinearLayout layout = new LinearLayout(this);
            for (int i = 0; i <= imgToShow; i++)
            {
                if (i % 5 == 0)
                {
                    if (i > 0)
                    {
                        //add image
                        GenerateImage(types, layout);
                    }
                    main.AddView(layout);
                    layout = new LinearLayout(this);
                    continue;
                }
                //add image
                GenerateImage(types, layout);
            }

            main.AddView(layout);

        }

        private void GenerateImage(char[] types, LinearLayout layout)
        {
            var img = new ImageView(this);
            int num1 = rnd.Next(1, 14);
            char type1 = types[rnd.Next(4)];
            img.SetImageResource(Resources.GetIdentifier($"img{num1}{type1}", "drawable", this.PackageName));
            img.LayoutParameters = new LinearLayout.LayoutParams(0, 400, 1);
            layout.AddView(img);
        }
    }
}

