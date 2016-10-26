using System;
using DocScanner;
using CoreAnimation;
using Foundation;
using CoreGraphics;
using UIKit;

namespace Sample
{
	public partial class ViewController : UIViewController
	{
		UITapGestureRecognizer dismissTap;
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CameraController.SetupCameraView();
			CameraController.EnableBorderDetection = true;
			UpdateHeading();

			BtnCapture.TouchUpInside += BtnCapture_TouchUpInside;

			BtnFlash.TouchUpInside += BtnFlash_TouchUpInside;

			BtnFilter.TouchUpInside += BtnFilter_TouchUpInside;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			CameraController.Start();
		}

		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.LightContent;
		}

		private void UpdateHeading()
		{
			var animation = new CATransition();
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseOut);
			animation.Type = "kCATransitionPush";
			animation.Subtype = "kCATransitionFromBottom";
			animation.Duration = 0.35f;

			TitleLabel.Layer.AddAnimation(animation, "kCATransitionFade");
			var filterMode = CameraController.CameraViewType == IPDFCameraViewType.BlackAndWhite ?
											 "Text Filter" : "Color Filter";
			TitleLabel.Text = string.Concat(filterMode, " ", CameraController.EnableBorderDetection == true ? "Auto Crop On" : "Auto Crop Off");
		}

		void BtnCapture_TouchUpInside(object sender, EventArgs e)
		{
			CameraController.CaptureImageWithCompletionHander((imageFilePath) => {
				var captureImageView = new UIImageView();
				captureImageView.Image = UIImage.FromFile(imageFilePath);
				captureImageView.BackgroundColor = UIColor.FromWhiteAlpha(0.0f, 0.7f);
				captureImageView.Frame = this.View.Bounds;
				captureImageView.Alpha = 1.0f;
				captureImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
				captureImageView.UserInteractionEnabled = true;
				this.View.AddSubview(captureImageView);

				dismissTap = new UITapGestureRecognizer(dismissPreview);
				captureImageView.AddGestureRecognizer(dismissTap);

				UIView.AnimateNotify(0.7f, 0.0f, 0.8f, 0.7f, UIViewAnimationOptions.AllowUserInteraction, () => {
					captureImageView.Frame = this.View.Bounds;
				}, (finished) => { });
			});
		}

		void BtnFlash_TouchUpInside(object sender, EventArgs e)
		{
			var enableTorch = CameraController.EnableTorch;
			BtnFlash.SetTitle(enableTorch ? "Flash On" : "Flash Off", UIControlState.Normal);
			CameraController.EnableTorch = enableTorch;
		}

		void BtnFilter_TouchUpInside(object sender, EventArgs e)
		{
			CameraController.CameraViewType = CameraController.CameraViewType == IPDFCameraViewType.BlackAndWhite ? IPDFCameraViewType.Normal : IPDFCameraViewType.BlackAndWhite;
			UpdateHeading();
		}

		void dismissPreview()
		{
			UIView.AnimateNotify(0.7f, 0.0f, 0.8f, 1.0f, UIViewAnimationOptions.AllowUserInteraction, () => {
				if (dismissTap != null) {
					dismissTap.View.RemoveFromSuperview();
				}
			}, (finished) => { });
		}


	}
}
