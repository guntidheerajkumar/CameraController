using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace DocScanner
{
	// @interface IPDFCameraViewController : UIView
	[BaseType(typeof(UIView))]
	interface IPDFCameraViewController
	{
		// -(void)setupCameraView;
		[Export("setupCameraView")]
		void SetupCameraView();

		// -(void)start;
		[Export("start")]
		void Start();

		// -(void)stop;
		[Export("stop")]
		void Stop();

		// @property (getter = isBorderDetectionEnabled, assign, nonatomic) BOOL enableBorderDetection;
		[Export("enableBorderDetection")]
		bool EnableBorderDetection { [Bind("isBorderDetectionEnabled")] get; set; }

		// @property (getter = isTorchEnabled, assign, nonatomic) BOOL enableTorch;
		[Export("enableTorch")]
		bool EnableTorch { [Bind("isTorchEnabled")] get; set; }

		// @property (assign, nonatomic) IPDFCameraViewType cameraViewType;
		[Export("cameraViewType", ArgumentSemantic.Assign)]
		IPDFCameraViewType CameraViewType { get; set; }

		// -(void)focusAtPoint:(CGPoint)point completionHandler:(void (^)())completionHandler;
		[Export("focusAtPoint:completionHandler:")]
		void FocusAtPoint(CGPoint point, Action completionHandler);

		// -(void)captureImageWithCompletionHander:(void (^)(NSString *))completionHandler;
		[Export("captureImageWithCompletionHander:")]
		void CaptureImageWithCompletionHander(Action<NSString> completionHandler);
	}
}
