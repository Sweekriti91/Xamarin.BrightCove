using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace NativeLibrary
{
    [Native]
	public enum BCOVEconomics : long
	{
		AdSupported = 0,
		Free,
		PublisherPays,
		PayMedia
	}

	[Native]
	public enum BCOVPlaybackServiceErrorCode : long
	{
		NoError,
		CodeConnectionError,
		CodeJSONDeserializationError,
		CodeAPIError
	}

	[Native]
	public enum BCOVVideo360SourceFormat : long
	{
		None = 0,
		Equirectangular = 1
	}

	[Native]
	public enum BCOVVideo360ProjectionStyle : long
	{
		Normal = 0,
		VRGoggles = 1
	}

	[Native]
	public enum BCOVBufferOptimizerMethod : long
	{
		None = 0,
		Default = 1
	}

	[Native]
	public enum BCOVProgressPolicyCuePointsToProcess : long
	{
		AllCuePoints,
		FinalCuePoint,
		FirstCuePoint
	}

	[Native]
	public enum BCOVProgressPolicyResumePosition : long
	{
		ContentPlayhead,
		LastProcessedCuePoint
	}

    [Native]
	public enum BCOVPUIViewTag : long
	{
		Unknown,
		ButtonPlayback = 1,
		ButtonJumpBack = 2,
		ButtonClosedCaption = 3,
		ButtonScreenMode = 4,
		LabelCurrentTime = 5,
		LabelTimeSeparator = 6,
		LabelDuration = 7,
		SliderProgress = 8,
		ViewExternalRoute = 9,
		ButtonLive = 10,
		ViewEmpty = 11,
		ButtonAdPodCountdown = 12,
		ButtonLearnMore = 13,
		ButtonSkipAdCountdown = 14,
		ViewButtonSkip = 15,
		ButtonVideo360 = 16,
		ButtonPreferredBitrate = 17,
		ButtonPictureInPicture = 18,
		ReservedEnd = 200
	}

	[Native]
	public enum BCOVPUIVideoType : ulong
	{
		Unknown,
		Vod,
		Live,
		LiveDVR
	}

	[Native]
	public enum BCOVPUIButtonIcon : ulong
	{
		Play,
		Pause,
		JumpBack,
		ZoomIn,
		ZoomOut,
		ClosedCaption,
		ExternalRoute,
		Video360,
		PreferredBitrate,
		Reserved
	}

	[Native]
	public enum BCOVPUIScreenMode : ulong
	{
		Normal,
		Full
	}

	[Native]
	public enum BCOVPUILearnMoreButtonBrowserStyle : ulong
	{
		ExternalBrowser,
		InAppBrowser
	}

	[Native]
	public enum BCOVPUIVideo360NavigationMethod : ulong
	{
		None,
		FingerTracking,
		DeviceMotionTracking
	}

	[Native]
	public enum BCOVOfflineVideoDownloadState : long
	{
		StateRequested = 0,
		StateDownloading = 1,
		StateSuspended = 2,
		StateCancelled = 3,
		StateCompleted = 4,
		StateError = 5,
		LicensePreloaded = 6,
		StateTracksRequested = 7,
		StateTracksDownloading = 8,
		StateTracksSuspended = 9,
		StateTracksCancelled = 10,
		StateTracksCompleted = 11,
		StateTracksError = 12
	}

}

