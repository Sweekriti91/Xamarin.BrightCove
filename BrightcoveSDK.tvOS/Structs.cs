using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace BrightcoveSDK.tvOS
{
    [Flags]
    public enum CMTimeFlags : ulong
    {
        Valid = 1u << 0,
        HasBeenRounded = 1u << 1,
        PositiveInfinity = 1u << 2,
        NegativeInfinity = 1u << 3,
        Indefinite = 1u << 4,
        ImpliedValueFlagsMask = PositiveInfinity | NegativeInfinity | Indefinite
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CMTime
    {
        public long value;

        public int timescale;

        public CMTimeFlags flags;

        public long epoch;
    }

    [Native]
    public enum BCOVEconomics : long
    {
        AdSupported = 0,
        Free,
        PublisherPays,
        PayMedia
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
    public enum BCOVTVPlayerType : ulong
    {
        Vod,
        Live,
        LiveDVR
    }

    [Native]
    public enum BCOVTVShowViewType : ulong
    {
        None,
        VoiceOverEnabledAndPaused,
        Controls,
        Settings
    }
}
