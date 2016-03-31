
using System;

using Foundation;
using UIKit;
using CoreGraphics;
using System.Drawing;

namespace YComponents
{
	public partial class MainViewController : UIViewController
	{
		public MainViewController () : base ("MainViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.


			View.BackgroundColor = UIColor.Gray; 

			//fro adding the parallax scroll
			//addView ();
 
			/*var ele2 = new LODiamondElement (){Frame = new CGRect(200,0,300,400)}; 
			View.Add (ele2);

			UITapGestureRecognizer tap2 = new UITapGestureRecognizer(OnTap_2) {
				NumberOfTapsRequired = 1 // double tap
			};
			ele2.AddGestureRecognizer(tap2);

			var ele = new LODiamondElement (){Frame = new CGRect(0,0,300,400)}; 
			View.Add (ele);

			UITapGestureRecognizer tap1 = new UITapGestureRecognizer(OnTap_1) {
				NumberOfTapsRequired = 1 // double tap
			};
			ele.AddGestureRecognizer(tap1);*/



			//addSkewElement ();

			/*** test of PageIndexView
			UIView mainview = new UIView (new CGRect(0,0,1024,768));
			View.Add (mainview);
			PageIndexView pi = new PageIndexView (100, 0); 
			for (int i = 0; i < 7; i++) 
				pi.addSlideButton(new UISlideButton(40 * i,0,36,36){ImageUrl =  "assets/icons/contenido"+(i+1)+".png"}) ; 
			mainview.Add (pi);

			PageIndexView pi2 = new PageIndexView (510	, 0); 
			for (int i = 0; i < 7; i++) 
				pi2.addSlideButton(new UISlideButton(40 * i,0,36,36){ImageUrl =  "assets/icons/contenido"+(i+1)+".png"}) ; 
			mainview.Add (pi2);


			/**********/

			UIView mainview = new UIView (new CGRect(0,0,1024,768));
			View.Add (mainview);
			IpadIndexView indexView = new IpadIndexView ();
			mainview.Add (indexView);


//			UISlideButton bt = new UISlideButton (100, 100, 100, 100);
//			View.Add (bt);
		}


		private void OnTap_2 (UIGestureRecognizer gesture) {
			int a =9 ;
		}


		private void OnTap_1 (UIGestureRecognizer gesture) {
			int b =0 ;
		}


 
		void addSkewElement()
		{ 
			nfloat h = 768;
 
			var eview2 = new UIView (new CGRect(100,0,390,h));
			eview2.BackgroundColor = UIColor.Blue; 
			eview2.Transform = CGAffineTransformMakeSkew ((nfloat)0.19, h);
			View.Add (eview2);

			nfloat deltax = 55;
			var path = new CGPath ();

			path.AddLines (new CGPoint[]{ 
				new CGPoint (0, 280),
				new CGPoint (260, 280),
				new CGPoint (260+deltax , 0),
				new CGPoint (deltax, 0)
			});

			path.CloseSubpath ();
			 
			string str = "LOL Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua";
	 

			nfloat nh = 280;

			CGRect frame = new CGRect (60, 256, 310, 280);
			//eview2.Bounds
			var ele = new UIFormatedText (){Frame = frame, Text = str, Foreground = UIColor.Yellow, 
				FontSize = 28, FontName = "HelveticaNeue-Light", TextHeight = nh ,  
				TextAligment= CoreText.CTTextAlignment.Left, Path = path };
			ele.Transform = CGAffineTransformMakeSkew ((nfloat)(-0.19), nh);
			ele.BackgroundColor = UIColor.Clear; 
			eview2.Add (ele);
 

		}

		CGAffineTransform CGAffineTransformMakeSkew(nfloat skewAmount , nfloat height)
		{
			CGAffineTransform skewTransform = CGAffineTransform.MakeIdentity();
			skewTransform = CGAffineTransform.MakeTranslation ((nfloat)skewAmount * height /2 , 0);
			skewTransform.xy = skewAmount;
			return skewTransform;
		}

		void addView()
		{
			var topview = new UIView (new CGRect (0,0,2000,768)){BackgroundColor = UIColor.Clear};
			var topsubview = new UIView (new CGRect (300,0,2000-300,768)){BackgroundColor = UIColor.Blue};
			topview.Add (topsubview);

			var backview = new UIView (new CGRect (0,0,1000,768)){BackgroundColor = UIColor.Clear};
			var backsubview = new UIImageView (new CGRect (0,0,800,768)){ContentMode= UIViewContentMode.ScaleToFill};
			backsubview.Image = UIImage.FromFile ("MyImage.png");
			backview.Add (backsubview);

			GTParallaxScroll pscroll = new GTParallaxScroll (0, 0, 1024, 768, GTScrollOrientation.Horizontal);
			pscroll.SetContent (topview, 3000);
			pscroll.SetBackContent (backview, 1500);
			View.Add (pscroll);
		}

 
 
	}
}

