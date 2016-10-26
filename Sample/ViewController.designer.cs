// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Sample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton BtnCapture { get; set; }

		[Outlet]
		UIKit.UIButton BtnFilter { get; set; }

		[Outlet]
		UIKit.UIButton BtnFlash { get; set; }

		[Outlet]
		DocScanner.IPDFCameraViewController CameraController { get; set; }

		[Outlet]
		UIKit.UILabel TitleLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}

			if (BtnFlash != null) {
				BtnFlash.Dispose ();
				BtnFlash = null;
			}

			if (BtnCapture != null) {
				BtnCapture.Dispose ();
				BtnCapture = null;
			}

			if (BtnFilter != null) {
				BtnFilter.Dispose ();
				BtnFilter = null;
			}

			if (CameraController != null) {
				CameraController.Dispose ();
				CameraController = null;
			}
		}
	}
}
