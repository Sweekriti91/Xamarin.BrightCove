using System;
using AVFoundation;
using AVKit;
using CoreMedia;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace BrightcoveSDK.iOS
{

    // @interface BCOVPlaybackService : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackService
    {
        // @property (nonatomic, strong) NSURLSession * sharedURLSession;
        [Export("sharedURLSession", ArgumentSemantic.Strong)]
        NSUrlSession SharedURLSession { get; set; }

        // -(instancetype)initWithAccountId:(NSString *)accountId policyKey:(NSString *)policyKey;
        [Export("initWithAccountId:policyKey:")]
        IntPtr Constructor(string accountId, string policyKey);

        // -(instancetype)initWithRequestFactory:(BCOVPlaybackServiceRequestFactory *)requestFactory __attribute__((objc_designated_initializer));
        [Export("initWithRequestFactory:")]
        [DesignatedInitializer]
        IntPtr Constructor(BCOVPlaybackServiceRequestFactory requestFactory);

        // -(void)findPlaylistWithPlaylistID:(NSString *)playlistID parameters:(NSDictionary *)parameters completion:(void (^)(int *, NSDictionary *, NSError *))completionHandler;
        [Export("findPlaylistWithPlaylistID:parameters:completion:")]
        void FindPlaylistWithPlaylistID(string playlistID, NSDictionary parameters, Action<NSObject, NSDictionary, NSError> completionHandler);

        // -(void)findPlaylistWithPlaylistID:(NSString *)playlistID authToken:(NSString *)authToken parameters:(NSDictionary *)parameters completion:(void (^)(int *, NSDictionary *, NSError *))completionHandler;
        [Export("findPlaylistWithPlaylistID:authToken:parameters:completion:")]
        void FindPlaylistWithPlaylistID(string playlistID, string authToken, NSDictionary parameters, Action<NSObject, NSDictionary, NSError> completionHandler);

        // -(void)findPlaylistWithReferenceID:(NSString *)referenceID parameters:(NSDictionary *)parameters completion:(void (^)(int *, NSDictionary *, NSError *))completionHandler;
        [Export("findPlaylistWithReferenceID:parameters:completion:")]
        void FindPlaylistWithReferenceID(string referenceID, NSDictionary parameters, Action<NSObject, NSDictionary, NSError> completionHandler);

        // -(void)findPlaylistWithReferenceID:(NSString *)referenceID authToken:(NSString *)authToken parameters:(NSDictionary *)parameters completion:(void (^)(int *, NSDictionary *, NSError *))completionHandler;
        [Export("findPlaylistWithReferenceID:authToken:parameters:completion:")]
        void FindPlaylistWithReferenceID(string referenceID, string authToken, NSDictionary parameters, Action<NSObject, NSDictionary, NSError> completionHandler);

        // -(void)findVideoWithVideoID:(NSString *)videoID parameters:(NSDictionary *)parameters completion:(void (^)(int *, NSDictionary *, NSError *))completionHandler;
        [Export("findVideoWithVideoID:parameters:completion:")]
        void FindVideoWithVideoID(string videoID, NSDictionary parameters, Action<NSObject, NSDictionary, NSError> completionHandler);

        // -(void)findVideoWithVideoID:(NSString *)videoID authToken:(NSString *)authToken parameters:(NSDictionary *)parameters completion:(void (^)(int *, NSDictionary *, NSError *))completionHandler;
        [Export("findVideoWithVideoID:authToken:parameters:completion:")]
        void FindVideoWithVideoID(string videoID, string authToken, NSDictionary parameters, Action<NSObject, NSDictionary, NSError> completionHandler);

        // -(void)findVideoWithReferenceID:(NSString *)referenceID parameters:(NSDictionary *)parameters completion:(void (^)(int *, NSDictionary *, NSError *))completionHandler;
        [Export("findVideoWithReferenceID:parameters:completion:")]
        void FindVideoWithReferenceID(string referenceID, NSDictionary parameters, Action<NSObject, NSDictionary, NSError> completionHandler);

        // -(void)findVideoWithReferenceID:(NSString *)referenceID authToken:(NSString *)authToken parameters:(NSDictionary *)parameters completion:(void (^)(int *, NSDictionary *, NSError *))completionHandler;
        [Export("findVideoWithReferenceID:authToken:parameters:completion:")]
        void FindVideoWithReferenceID(string referenceID, string authToken, NSDictionary parameters, Action<NSObject, NSDictionary, NSError> completionHandler);

        // +(id)sourceFromJSONDictionary:(NSDictionary *)json;
        [Static]
        [Export("sourceFromJSONDictionary:")]
        BCOVSource SourceFromJSONDictionary(NSDictionary json);

        // +(id)cuePointFromJSONDictionary:(NSDictionary *)json;
        [Static]
        [Export("cuePointFromJSONDictionary:")]
        BCOVCuePoint CuePointFromJSONDictionary(NSDictionary json);

        // +(id)playlistFromJSONDictionary:(NSDictionary *)json;
        [Static]
        [Export("playlistFromJSONDictionary:")]
        BCOVPlaylist PlaylistFromJSONDictionary(NSDictionary json);

        // +(id)videoFromJSONDictionary:(NSDictionary *)json;
        [Static]
        [Export("videoFromJSONDictionary:")]
        BCOVVideo VideoFromJSONDictionary(NSDictionary json);
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const kBCOVEdgePlaybackAuthServiceBaseURL;
    // 	[Field ("kBCOVEdgePlaybackAuthServiceBaseURL", "__Internal")]
    // 	NSString kBCOVEdgePlaybackAuthServiceBaseURL { get; }
    // }

    // @interface BCOVPlaybackServiceRequestFactory : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackServiceRequestFactory
    {
        // @property (readonly, copy, nonatomic) NSString * accountId;
        [Export("accountId")]
        string AccountId { get; }

        // @property (readonly, copy, nonatomic) NSString * policyKey;
        [Export("policyKey")]
        string PolicyKey { get; }

        // @property (readwrite, copy, nonatomic) NSDictionary * additionalHTTPRequestHeaders;
        [Export("additionalHTTPRequestHeaders", ArgumentSemantic.Copy)]
        NSDictionary AdditionalHTTPRequestHeaders { get; set; }

        // -(instancetype)initWithAccountId:(NSString *)accountId policyKey:(NSString *)policyKey;
        [Export("initWithAccountId:policyKey:")]
        IntPtr Constructor(string accountId, string policyKey);

        // -(instancetype)initWithAccountId:(NSString *)accountId policyKey:(NSString *)policyKey baseURLStr:(NSString *)baseURLStr __attribute__((objc_designated_initializer));
        [Export("initWithAccountId:policyKey:baseURLStr:")]
        [DesignatedInitializer]
        IntPtr Constructor(string accountId, string policyKey, string baseURLStr);

        // -(NSURLRequest *)requestForPlaylistWithPlaylistID:(NSString *)playlistId parameters:(NSDictionary *)parameters;
        [Export("requestForPlaylistWithPlaylistID:parameters:")]
        NSUrlRequest RequestForPlaylistWithPlaylistID(string playlistId, NSDictionary parameters);

        // -(NSURLRequest *)requestForPlaylistWithPlaylistID:(NSString *)playlistId authToken:(NSString *)authToken parameters:(NSDictionary *)parameters;
        [Export("requestForPlaylistWithPlaylistID:authToken:parameters:")]
        NSUrlRequest RequestForPlaylistWithPlaylistID(string playlistId, string authToken, NSDictionary parameters);

        // -(NSURLRequest *)requestForPlaylistWithReferenceID:(NSString *)referenceId parameters:(NSDictionary *)parameters;
        [Export("requestForPlaylistWithReferenceID:parameters:")]
        NSUrlRequest RequestForPlaylistWithReferenceID(string referenceId, NSDictionary parameters);

        // -(NSURLRequest *)requestForPlaylistWithReferenceID:(NSString *)referenceId authToken:(NSString *)authToken parameters:(NSDictionary *)parameters;
        [Export("requestForPlaylistWithReferenceID:authToken:parameters:")]
        NSUrlRequest RequestForPlaylistWithReferenceID(string referenceId, string authToken, NSDictionary parameters);

        // -(NSURLRequest *)requestForVideoWithVideoID:(NSString *)videoId parameters:(NSDictionary *)parameters;
        [Export("requestForVideoWithVideoID:parameters:")]
        NSUrlRequest RequestForVideoWithVideoID(string videoId, NSDictionary parameters);

        // -(NSURLRequest *)requestForVideoWithVideoID:(NSString *)videoId authToken:(NSString *)authToken parameters:(NSDictionary *)parameters;
        [Export("requestForVideoWithVideoID:authToken:parameters:")]
        NSUrlRequest RequestForVideoWithVideoID(string videoId, string authToken, NSDictionary parameters);

        // -(NSURLRequest *)requestForVideoWithReferenceID:(NSString *)referenceId parameters:(NSDictionary *)parameters;
        [Export("requestForVideoWithReferenceID:parameters:")]
        NSUrlRequest RequestForVideoWithReferenceID(string referenceId, NSDictionary parameters);

        // -(NSURLRequest *)requestForVideoWithReferenceID:(NSString *)referenceId authToken:(NSString *)authToken parameters:(NSDictionary *)parameters;
        [Export("requestForVideoWithReferenceID:authToken:parameters:")]
        NSUrlRequest RequestForVideoWithReferenceID(string referenceId, string authToken, NSDictionary parameters);
    }

    // @interface BCOVGlobalConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface BCOVGlobalConfiguration
    {
        // +(BCOVGlobalConfiguration * _Nonnull)sharedConfig;
        [Static]
        [Export("sharedConfig")]
        BCOVGlobalConfiguration SharedConfig { get; }

        // @property (nonatomic) NSString * _Nullable domainNameForChinaDelivery;
        [NullAllowed, Export("domainNameForChinaDelivery")]
        string DomainNameForChinaDelivery { get; set; }
    }

    // @interface BCOVPlayerSDKManager : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVPlayerSDKManager : BCOVPlayerSDKManager_BCOVFPSAdditions, BCOVPlayerSDKManager_BCOVSSAdditions
    {
        // +(NSString *)version;
        [Static]
        [Export("version")]
        string Version { get; }

        // @property (readonly, nonatomic, strong) NSString * sessionID;
        [Export("sessionID", ArgumentSemantic.Strong)]
        string SessionID { get; }

        // -(id)createPlaybackController;
        [Export("createPlaybackController")]
        //[Verify(MethodToProperty)]
        BCOVPlaybackController CreatePlaybackController();

        // -(id)createPlaybackControllerWithViewStrategy:(id)viewStrategy;
        [Export("createPlaybackControllerWithViewStrategy:")]
        NSObject CreatePlaybackControllerWithViewStrategy(NSObject viewStrategy);

        // -(id)createPlaybackControllerWithSessionProvider:(id<BCOVPlaybackSessionProvider>)provider viewStrategy:(id)viewStrategy;
        [Export("createPlaybackControllerWithSessionProvider:viewStrategy:")]
        NSObject CreatePlaybackControllerWithSessionProvider(BCOVPlaybackSessionProvider provider, NSObject viewStrategy);

        // -(id<BCOVPlaybackSessionProvider>)createBasicSessionProviderWithOptions:(BCOVBasicSessionProviderOptions *)options;
        [Export("createBasicSessionProviderWithOptions:")]
        BCOVPlaybackSessionProvider CreateBasicSessionProviderWithOptions(BCOVBasicSessionProviderOptions options);

        // -(void)registerComponent:(id<BCOVComponent>)component;
        [Export("registerComponent:")]
        void RegisterComponent(BCOVComponent component);

        // +(BCOVPlayerSDKManager *)sharedManager;
        [Static]
        [Export("sharedManager")]
        //Hack
        // BCOVPlayerSDKManager SharedManager { get; }
        BCOVPlayerSDKManager SharedManager();

        // +(BCOVPlayerSDKManager *)sharedManagerWithOptions:(NSDictionary *)options;
        [Static]
        [Export("sharedManagerWithOptions:")]
        BCOVPlayerSDKManager SharedManagerWithOptions(NSDictionary options);
    }

    // @protocol BCOVComponentIdentity <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BCOVComponentIdentity
    {
        // @required @property (readonly, nonatomic) Class componentClass;
        [Abstract]
        [Export("componentClass")]
        Class ComponentClass { get; }

        // @required @property (readonly, nonatomic) NSString * versionIdentifier;
        [Abstract]
        [Export("versionIdentifier")]
        string VersionIdentifier { get; }
    }

    // @protocol BCOVComponent <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Model, Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVComponent
    {
        // @required @property (readonly, nonatomic) id<BCOVComponentIdentity> bcov_componentIdentity;
        [Abstract]
        [Export("bcov_componentIdentity")]
        BCOVComponentIdentity Bcov_componentIdentity { get; }

        // @optional -(void)bcov_setComponentContext:(NSDictionary *)componentContext;
        [Export("bcov_setComponentContext:")]
        void Bcov_setComponentContext(NSDictionary componentContext);
    }

    // typedef BCOVSource * (^BCOVBasicSessionProviderSourceSelectionPolicy)(BCOVVideo *);
    delegate BCOVSource BCOVBasicSessionProviderSourceSelectionPolicy(BCOVVideo arg0);

    // @interface BCOVBasicSessionProvider : NSObject <BCOVPlaybackSessionProvider>
    [BaseType(typeof(NSObject))]
    interface BCOVBasicSessionProvider : BCOVPlaybackSessionProvider
    {
        // -(instancetype)initWithOptions:(BCOVBasicSessionProviderOptions *)options;
        [Export("initWithOptions:")]
        IntPtr Constructor(BCOVBasicSessionProviderOptions options);
    }

    // @interface BCOVBasicSourceSelectionPolicy : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface BCOVBasicSourceSelectionPolicy : INSCopying
    {
        // +(BCOVBasicSessionProviderSourceSelectionPolicy)sourceSelectionHLSWithScheme:(NSString *)scheme;
        [Static]
        [Export("sourceSelectionHLSWithScheme:")]
        BCOVBasicSessionProviderSourceSelectionPolicy SourceSelectionHLSWithScheme(string scheme);

        // +(BCOVBasicSessionProviderSourceSelectionPolicy)sourceSelectionHLS;
        [Static]
        [Export("sourceSelectionHLS")]
        // [Verify (MethodToProperty)]
        BCOVBasicSessionProviderSourceSelectionPolicy SourceSelectionHLS { get; }
    }

    // @interface BCOVBasicSessionProviderOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVBasicSessionProviderOptions
    {
        // @property (copy, nonatomic) BCOVSource * (^sourceSelectionPolicy)(BCOVVideo *);
        [Export("sourceSelectionPolicy", ArgumentSemantic.Copy)]
        Func<BCOVVideo, BCOVSource> SourceSelectionPolicy { get; set; }
    }

    // @interface BCOVCuePointProgressPolicy : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVCuePointProgressPolicy
    {
        // -(BCOVCuePointProgressPolicyResult *)applyToEvent:(NSDictionary *)cuePointEvent;
        [Export("applyToEvent:")]
        BCOVCuePointProgressPolicyResult ApplyToEvent(NSDictionary cuePointEvent);

        // @property (readonly, nonatomic) BOOL ignoringPreviouslyProcessedCuePoints;
        [Export("ignoringPreviouslyProcessedCuePoints")]
        bool IgnoringPreviouslyProcessedCuePoints { get; }

        // +(instancetype)progressPolicyProcessingCuePoints:(BCOVProgressPolicyCuePointsToProcess)cuePointsToProcess resumingPlaybackFrom:(BCOVProgressPolicyResumePosition)resumePosition ignoringPreviouslyProcessedCuePoints:(BOOL)ignorePrevious;
        [Static]
        [Export("progressPolicyProcessingCuePoints:resumingPlaybackFrom:ignoringPreviouslyProcessedCuePoints:")]
        BCOVCuePointProgressPolicy ProgressPolicyProcessingCuePoints(BCOVProgressPolicyCuePointsToProcess cuePointsToProcess, BCOVProgressPolicyResumePosition resumePosition, bool ignorePrevious);
    }

    // @interface BCOVCuePointProgressPolicyResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVCuePointProgressPolicyResult
    {
        // -(instancetype)initWithCuePoints:(BCOVCuePointCollection *)cuePoints resumeCuePoint:(BCOVCuePoint *)resumeCuePoint;
        [Export("initWithCuePoints:resumeCuePoint:")]
        IntPtr Constructor(BCOVCuePointCollection cuePoints, BCOVCuePoint resumeCuePoint);

        // @property (readonly, copy, nonatomic) BCOVCuePoint * resumeCuePoint;
        [Export("resumeCuePoint", ArgumentSemantic.Copy)]
        BCOVCuePoint ResumeCuePoint { get; }

        // @property (readonly, copy, nonatomic) BCOVCuePointCollection * cuePoints;
        [Export("cuePoints", ArgumentSemantic.Copy)]
        BCOVCuePointCollection CuePoints { get; }
    }

    // @interface BCOVVideo360ViewProjection : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVVideo360ViewProjection
    {
        // @property (nonatomic) CGFloat pan;
        [Export("pan")]
        nfloat Pan { get; set; }

        // @property (nonatomic) CGFloat tilt;
        [Export("tilt")]
        nfloat Tilt { get; set; }

        // @property (nonatomic) CGFloat zoom;
        [Export("zoom")]
        nfloat Zoom { get; set; }

        // @property (nonatomic) CGFloat roll;
        [Export("roll")]
        nfloat Roll { get; set; }

        // @property (assign, nonatomic) CGFloat xOffset;
        [Export("xOffset")]
        nfloat XOffset { get; set; }

        // @property (assign, nonatomic) CGFloat yOffset;
        [Export("yOffset")]
        nfloat YOffset { get; set; }

        // @property (nonatomic) BCOVVideo360SourceFormat sourceFormat;
        [Export("sourceFormat", ArgumentSemantic.Assign)]
        BCOVVideo360SourceFormat SourceFormat { get; set; }

        // @property (nonatomic) BCOVVideo360ProjectionStyle projectionStyle;
        [Export("projectionStyle", ArgumentSemantic.Assign)]
        BCOVVideo360ProjectionStyle ProjectionStyle { get; set; }

        // +(instancetype)viewProjection;
        [Static]
        [Export("viewProjection")]
        BCOVVideo360ViewProjection ViewProjection();
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const kBCOVBufferOptimizerMethodKey;
    // 	[Field ("kBCOVBufferOptimizerMethodKey", "__Internal")]
    // 	NSString kBCOVBufferOptimizerMethodKey { get; }

    // 	// extern NSString *const kBCOVBufferOptimizerMinimumDurationKey;
    // 	[Field ("kBCOVBufferOptimizerMinimumDurationKey", "__Internal")]
    // 	NSString kBCOVBufferOptimizerMinimumDurationKey { get; }

    // 	// extern NSString *const kBCOVBufferOptimizerMaximumDurationKey;
    // 	[Field ("kBCOVBufferOptimizerMaximumDurationKey", "__Internal")]
    // 	NSString kBCOVBufferOptimizerMaximumDurationKey { get; }

    // 	// extern NSString *const kBCOVAVPlayerViewControllerCompatibilityKey;
    // 	[Field ("kBCOVAVPlayerViewControllerCompatibilityKey", "__Internal")]
    // 	NSString kBCOVAVPlayerViewControllerCompatibilityKey { get; }
    // }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const kBCOVDefaultFairPlayApplicationCertificateIdentifier;
    // 	[Field ("kBCOVDefaultFairPlayApplicationCertificateIdentifier", "__Internal")]
    // 	NSString kBCOVDefaultFairPlayApplicationCertificateIdentifier { get; }
    // }

    // typedef UIView * (^BCOVPlaybackControllerViewStrategy)(UIView *, id<BCOVPlaybackController>);
    delegate UIView BCOVPlaybackControllerViewStrategy(UIView arg0, BCOVPlaybackController arg1);

    // @protocol BCOVPlaybackController <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackController
    {
        // [Wrap ("WeakDelegate"), Abstract]
        //Hack
        [Wrap("WeakDelegate")]
        BCOVPlaybackControllerDelegate Delegate { get; set; }

        // @required @property (assign, nonatomic) id<BCOVPlaybackControllerDelegate> delegate;
        // [Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @required @property (getter = isAutoAdvance, assign, nonatomic) BOOL autoAdvance;
        // [Abstract]
        [Export("autoAdvance")]
        bool AutoAdvance { [Bind("isAutoAdvance")] get; set; }

        // @required @property (getter = isAutoPlay, assign, nonatomic) BOOL autoPlay;
        // [Abstract]
        [Export("autoPlay")]
        bool AutoPlay { [Bind("isAutoPlay")] get; set; }

        // @required @property (readonly, nonatomic, strong) UIView * view;
        // [Abstract]
        [Export("view", ArgumentSemantic.Strong)]
        UIView View { get; }

        // @required @property (readwrite, copy, nonatomic) NSDictionary * options;
        // [Abstract]
        [Export("options", ArgumentSemantic.Copy)]
        NSDictionary Options { get; set; }

        // @required @property (readonly, copy, nonatomic) id<BCOVMutableAnalytics> analytics;
        // [Abstract]
        [Export("analytics", ArgumentSemantic.Copy)]
        BCOVMutableAnalytics Analytics { get; }

        // @required @property (readwrite, nonatomic) BOOL adsDisabled;
        // [Abstract]
        [Export("adsDisabled")]
        bool AdsDisabled { get; set; }

        // @required @property (readwrite, nonatomic) BOOL allowsBackgroundAudioPlayback;
        // [Abstract]
        [Export("allowsBackgroundAudioPlayback")]
        bool AllowsBackgroundAudioPlayback { get; set; }

        // @required @property (readwrite, nonatomic) BOOL allowsExternalPlayback;
        // [Abstract]
        [Export("allowsExternalPlayback")]
        bool AllowsExternalPlayback { get; set; }

        // @required @property (readwrite, nonatomic) BOOL usesExternalPlaybackWhileExternalScreenIsActive;
        // [Abstract]
        [Export("usesExternalPlaybackWhileExternalScreenIsActive")]
        bool UsesExternalPlaybackWhileExternalScreenIsActive { get; set; }

        // @required @property (getter = isPictureInPictureActive, assign, readwrite, nonatomic) BOOL pictureInPictureActive;
        // [Abstract]
        [Export("pictureInPictureActive")]
        bool PictureInPictureActive { [Bind("isPictureInPictureActive")] get; set; }

        // @required -(void)setPreferredPeakBitRate:(double)preferredPeakBitRate;
        // [Abstract]
        [Export("setPreferredPeakBitRate:")]
        void SetPreferredPeakBitRate(double preferredPeakBitRate);

        // @required -(void)updateAudienceSegmentTargetingValues:(NSDictionary *)audienceSegmentTargetingValues;
        // [Abstract]
        [Export("updateAudienceSegmentTargetingValues:")]
        void UpdateAudienceSegmentTargetingValues(NSDictionary audienceSegmentTargetingValues);

        // @required @property (assign, readwrite, nonatomic) BOOL thumbnailScrubbingEnabled;
        // [Abstract]
        [Export("thumbnailScrubbingEnabled")]
        bool ThumbnailScrubbingEnabled { get; set; }

        // @required @property (readwrite, nonatomic) BOOL shutter;
        // [Abstract]
        [Export("shutter")]
        bool Shutter { get; set; }

        // @required @property (readwrite, nonatomic) NSTimeInterval shutterFadeTime;
        // [Abstract]
        [Export("shutterFadeTime")]
        double ShutterFadeTime { get; set; }

        // @required @property (readwrite, copy, nonatomic) BCOVVideo360ViewProjection * viewProjection;
        // [Abstract]
        [Export("viewProjection", ArgumentSemantic.Copy)]
        BCOVVideo360ViewProjection ViewProjection { get; set; }

        // @required -(void)addSessionConsumer:(id<BCOVPlaybackSessionConsumer>)consumer;
        // [Abstract]
        [Export("addSessionConsumer:")]
        void AddSessionConsumer(BCOVPlaybackSessionConsumer consumer);

        // @required -(void)removeSessionConsumer:(id<BCOVPlaybackSessionConsumer>)consumer;
        // [Abstract]
        [Export("removeSessionConsumer:")]
        void RemoveSessionConsumer(BCOVPlaybackSessionConsumer consumer);

        // @required -(void)advanceToNext;
        // [Abstract]
        [Export("advanceToNext")]
        void AdvanceToNext();

        // @required -(void)play;
        // [Abstract]
        [Export("play")]
        void Play();

        // @required -(void)pause;
        // [Abstract]
        [Export("pause")]
        void Pause();

        // @required -(void)seekToTime:(CMTime)time completionHandler:(void (^)(BOOL))completionHandler;
        // [Abstract]
        [Export("seekToTime:completionHandler:")]
        void SeekToTime(CMTime time, Action<bool> completionHandler);

        // @required -(void)seekToTime:(CMTime)time toleranceBefore:(CMTime)toleranceBefore toleranceAfter:(CMTime)toleranceAfter completionHandler:(void (^)(BOOL))completionHandler;
        // [Abstract]
        [Export("seekToTime:toleranceBefore:toleranceAfter:completionHandler:")]
        void SeekToTime(CMTime time, CMTime toleranceBefore, CMTime toleranceAfter, Action<bool> completionHandler);

        // @required -(void)seekWithoutAds:(CMTime)time completionHandler:(void (^)(BOOL))completionHandler;
        // [Abstract]
        [Export("seekWithoutAds:completionHandler:")]
        void SeekWithoutAds(CMTime time, Action<bool> completionHandler);

        // @required -(void)resumeVideoAtTime:(CMTime)time withAutoPlay:(BOOL)autoPlay;
        // [Abstract]
        [Export("resumeVideoAtTime:withAutoPlay:")]
        void ResumeVideoAtTime(CMTime time, bool autoPlay);

        // @required -(void)setVideos:(id<NSFastEnumeration>)videos;
        // [Abstract]
        [Export("setVideos:")]
        //void SetVideos(NSFastEnumeration videos);
        //Hack
        void SetVideos(NSArray videos);

        // @required -(void)resumeAd;
        // [Abstract]
        [Export("resumeAd")]
        void ResumeAd();

        // @required -(void)pauseAd;
        // [Abstract]
        [Export("pauseAd")]
        void PauseAd();

        // @required -(void)addFairPlayApplicationCertificate:(NSData *)applicationCertificateData identifier:(NSString *)identifier;
        // [Abstract]
        [Export("addFairPlayApplicationCertificate:identifier:")]
        void AddFairPlayApplicationCertificate(NSData applicationCertificateData, string identifier);
    }

    // @protocol BCOVPlaybackSessionConsumer <BCOVPlaybackSessionBasicConsumer>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackSessionConsumer : BCOVPlaybackSessionBasicConsumer
    {
    }

    // @protocol BCOVPlaybackSessionBasicConsumer <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackSessionBasicConsumer
    {
        // @optional -(void)didAdvanceToPlaybackSession:(id<BCOVPlaybackSession>)session;
        [Export("didAdvanceToPlaybackSession:")]
        void DidAdvanceToPlaybackSession(BCOVPlaybackSession session);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didChangeDuration:(NSTimeInterval)duration;
        [Export("playbackSession:didChangeDuration:")]
        void PlaybackSession(BCOVPlaybackSession session, double duration);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didChangeExternalPlaybackActive:(BOOL)externalPlaybackActive;
        [Export("playbackSession:didChangeExternalPlaybackActive:")]
        void PlaybackSession(BCOVPlaybackSession session, bool externalPlaybackActive);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didPassCuePoints:(NSDictionary *)cuePointInfo;
        [Export("playbackSession:didPassCuePoints:")]
        void PlaybackSession(BCOVPlaybackSession session, NSDictionary cuePointInfo);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didProgressTo:(NSTimeInterval)progress;
        [Export("playbackSession:didProgressTo:")]
        void PlaybackSessiondidProgressTo(BCOVPlaybackSession session, double progress);

        // @optional -(void)didCompletePlaylist:(id<NSFastEnumeration>)playlist;
        [Export("didCompletePlaylist:")]
        //void DidCompletePlaylist(NSFastEnumeration playlist);
        //Hack
        void DidCompletePlaylist(NSObject playlist);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didReceiveLifecycleEvent:(BCOVPlaybackSessionLifecycleEvent *)lifecycleEvent;
        [Export("playbackSession:didReceiveLifecycleEvent:")]
        void PlaybackSession(BCOVPlaybackSession session, BCOVPlaybackSessionLifecycleEvent lifecycleEvent);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didChangeSeekableRanges:(NSArray *)seekableRanges;
        [Export("playbackSession:didChangeSeekableRanges:")]
        // [Verify (StronglyTypedNSArray)]
        void PlaybackSession(BCOVPlaybackSession session, NSObject[] seekableRanges);
    }

    // @protocol BCOVPlaybackControllerDelegate <BCOVPlaybackControllerBasicDelegate>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackControllerDelegate : BCOVPlaybackControllerBasicDelegate
    {
    }

    // @protocol BCOVPlaybackControllerBasicDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackControllerBasicDelegate
    {
        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller didAdvanceToPlaybackSession:(id<BCOVPlaybackSession>)session;
        [Export("playbackController:didAdvanceToPlaybackSession:")]
        void DidAdvanceToPlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didChangeDuration:(NSTimeInterval)duration;
        [Export("playbackController:playbackSession:didChangeDuration:")]
        void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, double duration);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didChangeExternalPlaybackActive:(BOOL)externalPlaybackActive;
        [Export("playbackController:playbackSession:didChangeExternalPlaybackActive:")]
        void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, bool externalPlaybackActive);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didPassCuePoints:(NSDictionary *)cuePointInfo;
        [Export("playbackController:playbackSession:didPassCuePoints:")]
        void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, NSDictionary cuePointInfo);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didProgressTo:(NSTimeInterval)progress;
        [Export("playbackController:playbackSession:didProgressTo:")]
        void PlaybackSessiondidProgressTo(BCOVPlaybackController controller, BCOVPlaybackSession session, double progress);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller didCompletePlaylist:(id<NSFastEnumeration>)playlist;
        [Export("playbackController:didCompletePlaylist:")]
        //void DidCompletePlaylist(BCOVPlaybackController controller, NSFastEnumeration playlist);
        //Hack
        void DidCompletePlaylist(BCOVPlaybackController controller, NSObject playlist);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didReceiveLifecycleEvent:(BCOVPlaybackSessionLifecycleEvent *)lifecycleEvent;
        [Export("playbackController:playbackSession:didReceiveLifecycleEvent:")]
        void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVPlaybackSessionLifecycleEvent lifecycleEvent);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didChangeSeekableRanges:(NSArray *)seekableRanges;
        [Export("playbackController:playbackSession:didChangeSeekableRanges:")]
        //[Verify(StronglyTypedNSArray)]
        void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, NSObject[] seekableRanges);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller noPlayableVideosFound:(id<NSFastEnumeration>)unplayableVideos;
        [Export("playbackController:noPlayableVideosFound:")]
        //void NoPlayableVideosFound(BCOVPlaybackController controller, NSFastEnumeration unplayableVideos);
        //Hack
        void NoPlayableVideosFound(BCOVPlaybackController controller, NSObject unplayableVideos);


        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller determinedVideoType:(BCOVVideoType)videoType forVideo:(BCOVVideo *)video;
        [Export("playbackController:determinedVideoType:forVideo:")]
        void DeterminedVideoType(BCOVPlaybackController controller, BCOVVideoType videoType, BCOVVideo video);
    }

    // @protocol BCOVMutableAnalytics <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVMutableAnalytics
    {
        // @required @property (copy, nonatomic) NSString * account;
        [Abstract]
        [Export("account")]
        string Account { get; set; }

        // @required @property (copy, nonatomic) NSString * destination;
        [Abstract]
        [Export("destination")]
        string Destination { get; set; }

        // @required @property (copy, nonatomic) NSString * source;
        [Abstract]
        [Export("source")]
        string Source { get; set; }

        // @required @property (getter = isUniqueIdentifierEnabled, assign, nonatomic) BOOL uniqueIdentifierEnabled;
        [Abstract]
        [Export("uniqueIdentifierEnabled")]
        bool UniqueIdentifierEnabled { [Bind("isUniqueIdentifierEnabled")] get; set; }
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventReady;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventReady", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventReady { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventFail;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventFail", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventFail { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlay;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventPlay", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventPlay { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventPause;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventPause", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventPause { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlayRequest;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventPlayRequest", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventPlayRequest { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventPauseRequest;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventPauseRequest", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventPauseRequest { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventFailedToPlayToEndTime;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventFailedToPlayToEndTime", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventFailedToPlayToEndTime { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventResumeBegin;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventResumeBegin", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventResumeBegin { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventResumeComplete;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventResumeComplete", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventResumeComplete { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventResumeFail;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventResumeFail", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventResumeFail { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventEnd;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventEnd", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventEnd { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlaybackStalled;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventPlaybackStalled", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventPlaybackStalled { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlaybackRecovered;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventPlaybackRecovered", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventPlaybackRecovered { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlaybackBufferEmpty;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventPlaybackBufferEmpty", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventPlaybackBufferEmpty { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlaybackLikelyToKeepUp;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventPlaybackLikelyToKeepUp", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventPlaybackLikelyToKeepUp { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventTerminate;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventTerminate", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventTerminate { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventError;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventError", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventError { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventAdSequenceEnter;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventAdSequenceEnter", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventAdSequenceEnter { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventAdSequenceExit;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventAdSequenceExit", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventAdSequenceExit { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventAdEnter;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventAdEnter", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventAdEnter { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventAdExit;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventAdExit", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventAdExit { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventAdProgress;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventAdProgress", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventAdProgress { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventAdPause;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventAdPause", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventAdPause { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventAdResume;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventAdResume", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventAdResume { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionEventKeyError;
    // 	[Field ("kBCOVPlaybackSessionEventKeyError", "__Internal")]
    // 	NSString kBCOVPlaybackSessionEventKeyError { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionEventKeyPreviousTime;
    // 	[Field ("kBCOVPlaybackSessionEventKeyPreviousTime", "__Internal")]
    // 	NSString kBCOVPlaybackSessionEventKeyPreviousTime { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionEventKeyCurrentTime;
    // 	[Field ("kBCOVPlaybackSessionEventKeyCurrentTime", "__Internal")]
    // 	NSString kBCOVPlaybackSessionEventKeyCurrentTime { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionEventKeyCuePoints;
    // 	[Field ("kBCOVPlaybackSessionEventKeyCuePoints", "__Internal")]
    // 	NSString kBCOVPlaybackSessionEventKeyCuePoints { get; }

    // 	// extern NSString *const kBCOVPlaybackSessionErrorDomain;
    // 	[Field ("kBCOVPlaybackSessionErrorDomain", "__Internal")]
    // 	NSString kBCOVPlaybackSessionErrorDomain { get; }

    // 	// extern const NSInteger kBCOVPlaybackSessionErrorCodeLoadFailed;
    // 	[Field ("kBCOVPlaybackSessionErrorCodeLoadFailed", "__Internal")]
    // 	nint kBCOVPlaybackSessionErrorCodeLoadFailed { get; }

    // 	// extern const NSInteger kBCOVPlaybackSessionErrorCodeFailedToPlayToEnd;
    // 	[Field ("kBCOVPlaybackSessionErrorCodeFailedToPlayToEnd", "__Internal")]
    // 	nint kBCOVPlaybackSessionErrorCodeFailedToPlayToEnd { get; }

    // 	// extern const NSInteger kBCOVPlaybackSessionErrorCodeNoPlayableSource;
    // 	[Field ("kBCOVPlaybackSessionErrorCodeNoPlayableSource", "__Internal")]
    // 	nint kBCOVPlaybackSessionErrorCodeNoPlayableSource { get; }
    // }

    // @protocol BCOVPlaybackSession <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackSession
    {
        // @required @property (readonly, copy, nonatomic) BCOVVideo * video;
        // [Abstract]
        [Export("video", ArgumentSemantic.Copy)]
        BCOVVideo Video { get; }

        // @required @property (readonly, copy, nonatomic) BCOVSource * source;
        // [Abstract]
        [Export("source", ArgumentSemantic.Copy)]
        BCOVSource Source { get; }

        // @required @property (readonly, nonatomic, strong) AVPlayer * player;
        // [Abstract]
        [Export("player", ArgumentSemantic.Strong)]
        AVPlayer Player { get; }

        // @required @property (readonly, nonatomic, strong) AVPlayerLayer * playerLayer;
        // [Abstract]
        [Export("playerLayer", ArgumentSemantic.Strong)]
        AVPlayerLayer PlayerLayer { get; }

        // @required @property (readonly, nonatomic) AVMediaSelectionGroup * audibleMediaSelectionGroup;
        // [Abstract]
        [Export("audibleMediaSelectionGroup")]
        AVMediaSelectionGroup AudibleMediaSelectionGroup { get; }

        // @required @property (readwrite, nonatomic) AVMediaSelectionOption * selectedAudibleMediaOption;
        // [Abstract]
        [Export("selectedAudibleMediaOption", ArgumentSemantic.Assign)]
        AVMediaSelectionOption SelectedAudibleMediaOption { get; set; }

        // @required @property (readonly, nonatomic) AVMediaSelectionGroup * legibleMediaSelectionGroup;
        // [Abstract]
        [Export("legibleMediaSelectionGroup")]
        AVMediaSelectionGroup LegibleMediaSelectionGroup { get; }

        // @required @property (readwrite, nonatomic) AVMediaSelectionOption * selectedLegibleMediaOption;
        // [Abstract]
        [Export("selectedLegibleMediaOption", ArgumentSemantic.Assign)]
        AVMediaSelectionOption SelectedLegibleMediaOption { get; set; }

        // @required @property (readonly, nonatomic, strong) BCOVSessionProviderExtension * providerExtension;
        // [Abstract]
        [Export("providerExtension", ArgumentSemantic.Strong)]
        BCOVSessionProviderExtension ProviderExtension { get; }

        // @required -(void)selectAudibleMediaOptionAutomatically;
        // [Abstract]
        [Export("selectAudibleMediaOptionAutomatically")]
        void SelectAudibleMediaOptionAutomatically();

        // @required -(void)selectLegibleMediaOptionAutomatically;
        // [Abstract]
        [Export("selectLegibleMediaOptionAutomatically")]
        void SelectLegibleMediaOptionAutomatically();

        // @required -(NSString *)displayNameFromAudibleMediaSelectionOption:(AVMediaSelectionOption *)option;
        // [Abstract]
        [Export("displayNameFromAudibleMediaSelectionOption:")]
        string DisplayNameFromAudibleMediaSelectionOption(AVMediaSelectionOption option);

        // @required -(NSString *)displayNameFromLegibleMediaSelectionOption:(AVMediaSelectionOption *)option;
        // [Abstract]
        [Export("displayNameFromLegibleMediaSelectionOption:")]
        string DisplayNameFromLegibleMediaSelectionOption(AVMediaSelectionOption option);

        // @required -(void)terminate;
        // [Abstract]
        [Export("terminate")]
        void Terminate();
    }

    // @interface BCOVPlaybackSessionLifecycleEvent : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackSessionLifecycleEvent : INSCopying
    {
        // @property (readonly, nonatomic) NSString * eventType;
        [Export("eventType")]
        string EventType { get; }

        // @property (readonly, nonatomic) NSDictionary * properties;
        [Export("properties")]
        NSDictionary Properties { get; }

        // -(instancetype)initWithEventType:(NSString *)eventType properties:(NSDictionary *)properties;
        [Export("initWithEventType:properties:")]
        IntPtr Constructor(string eventType, NSDictionary properties);

        // -(BOOL)isEqualToPlaybackSessionLifecycleEvent:(BCOVPlaybackSessionLifecycleEvent *)event;
        [Export("isEqualToPlaybackSessionLifecycleEvent:")]
        bool IsEqualToPlaybackSessionLifecycleEvent(BCOVPlaybackSessionLifecycleEvent @event);

        // +(instancetype)eventWithType:(NSString *)eventType;
        [Static]
        [Export("eventWithType:")]
        BCOVPlaybackSessionLifecycleEvent EventWithType(string eventType);
    }

    // @interface BCOVSessionProviderExtension : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVSessionProviderExtension
    {
    }

    // @protocol BCOVPlaybackSessionProvider <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackSessionProvider
    {
        // @optional -(id)playbackSessionsForVideos:(id<NSFastEnumeration>)videos __attribute__((deprecated("Do not use")));
        [Export("playbackSessionsForVideos:")]
        //Hack
        NSObject PlaybackSessionsForVideos(NSObject videos);
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const _Nonnull kBCOVFPSErrorDomain;
    // 	[Field ("kBCOVFPSErrorDomain", "__Internal")]
    // 	NSString kBCOVFPSErrorDomain { get; }

    // 	// extern const NSInteger kBCOVFPSErrorCodeStreamingContentKeyRequest;
    // 	[Field ("kBCOVFPSErrorCodeStreamingContentKeyRequest", "__Internal")]
    // 	nint kBCOVFPSErrorCodeStreamingContentKeyRequest { get; }

    // 	// extern const NSInteger kBCOVFPSErrorCodeApplicationCertificateRequest;
    // 	[Field ("kBCOVFPSErrorCodeApplicationCertificateRequest", "__Internal")]
    // 	nint kBCOVFPSErrorCodeApplicationCertificateRequest { get; }
    // }

    // @protocol BCOVFPSAuthorizationProxy <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BCOVFPSAuthorizationProxy
    {
        // @optional -(NSData * _Nullable)contentIdentifierFromLoadingRequest:(AVAssetResourceLoadingRequest * _Nonnull)loadingRequest;
        [Export("contentIdentifierFromLoadingRequest:")]
        [return: NullAllowed]
        NSData ContentIdentifierFromLoadingRequest(AVAssetResourceLoadingRequest loadingRequest);

        // @required -(void)encryptedContentKeyForContentKeyIdentifier:(NSString * _Nonnull)contentKeyIdentifier contentKeyRequest:(NSData * _Nonnull)keyRequest source:(BCOVSource * _Nonnull)source options:(NSDictionary * _Nullable)options completionHandler:(void (^ _Nonnull)(NSURLResponse * _Nullable, NSData * _Nullable, NSDate * _Nullable, NSError * _Nullable))completionHandler;
        //[Abstract]
        [Export("encryptedContentKeyForContentKeyIdentifier:contentKeyRequest:source:options:completionHandler:")]
        void EncryptedContentKeyForContentKeyIdentifier(string contentKeyIdentifier, NSData keyRequest, BCOVSource source, [NullAllowed] NSDictionary options, Action<NSUrlResponse, NSData, NSDate, NSError> completionHandler);
    }

    //Hack: FPS Fix
    interface IBCOVFPSAuthorizationProxy { }


    // @interface BCOVFPSAdditions (BCOVPlayerSDKManager)
    //Hack: FPS fix
    // [Category]
    // [BaseType (typeof(BCOVPlayerSDKManager))]
    interface BCOVPlayerSDKManager_BCOVFPSAdditions
    {
        // -(id<BCOVPlaybackController> _Nonnull)createFairPlayPlaybackControllerWithAuthorizationProxy:(id<BCOVFPSAuthorizationProxy> _Nonnull)proxy;
        [Export("createFairPlayPlaybackControllerWithAuthorizationProxy:")]
        BCOVPlaybackController CreateFairPlayPlaybackControllerWithAuthorizationProxy(IBCOVFPSAuthorizationProxy proxy);

        // -(id<BCOVPlaybackSessionProvider> _Nonnull)createFairPlaySessionProviderWithAuthorizationProxy:(id<BCOVFPSAuthorizationProxy> _Nonnull)proxy upstreamSessionProvider:(id<BCOVPlaybackSessionProvider> _Nullable)provider;
        [Export("createFairPlaySessionProviderWithAuthorizationProxy:upstreamSessionProvider:")]
        BCOVPlaybackSessionProvider CreateFairPlaySessionProviderWithAuthorizationProxy(IBCOVFPSAuthorizationProxy proxy, [NullAllowed] BCOVPlaybackSessionProvider provider);

        // -(id<BCOVPlaybackController> _Nonnull)createFairPlayPlaybackControllerWithApplicationCertificate:(NSData * _Nullable)appCert authorizationProxy:(id<BCOVFPSAuthorizationProxy> _Nonnull)proxy viewStrategy:(BCOVPlaybackControllerViewStrategy _Nullable)viewStrategy;
        [Export("createFairPlayPlaybackControllerWithApplicationCertificate:authorizationProxy:viewStrategy:")]
        BCOVPlaybackController CreateFairPlayPlaybackControllerWithApplicationCertificate([NullAllowed] NSData appCert, IBCOVFPSAuthorizationProxy proxy, [NullAllowed] BCOVPlaybackControllerViewStrategy viewStrategy);

        // -(id<BCOVPlaybackSessionProvider> _Nonnull)createFairPlaySessionProviderWithApplicationCertificate:(NSData * _Nullable)appCert authorizationProxy:(id<BCOVFPSAuthorizationProxy> _Nonnull)proxy upstreamSessionProvider:(id<BCOVPlaybackSessionProvider> _Nullable)provider;
        [Export("createFairPlaySessionProviderWithApplicationCertificate:authorizationProxy:upstreamSessionProvider:")]
        BCOVPlaybackSessionProvider CreateFairPlaySessionProviderWithApplicationCertificate([NullAllowed] NSData appCert, IBCOVFPSAuthorizationProxy proxy, [NullAllowed] BCOVPlaybackSessionProvider provider);
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const _Nonnull kBCOVSourceKeySystemFairPlayV1;
    // 	[Field ("kBCOVSourceKeySystemFairPlayV1", "__Internal")]
    // 	NSString kBCOVSourceKeySystemFairPlayV1 { get; }

    // 	// extern NSString *const _Nonnull kBCOVSourceKeySystemFairPlayKeyRequestURLKey;
    // 	[Field ("kBCOVSourceKeySystemFairPlayKeyRequestURLKey", "__Internal")]
    // 	NSString kBCOVSourceKeySystemFairPlayKeyRequestURLKey { get; }

    // 	// extern NSString *const _Nonnull kBCOVFPSAuthProxyErrorDomain;
    // 	[Field ("kBCOVFPSAuthProxyErrorDomain", "__Internal")]
    // 	NSString kBCOVFPSAuthProxyErrorDomain { get; }

    // 	// extern const NSInteger kBCOVFPSAuthProxyErrorCodeApplicationCertificateRequestFailed;
    // 	[Field ("kBCOVFPSAuthProxyErrorCodeApplicationCertificateRequestFailed", "__Internal")]
    // 	nint kBCOVFPSAuthProxyErrorCodeApplicationCertificateRequestFailed { get; }

    // 	// extern const NSInteger kBCOVFPSAuthProxyErrorCodeContentKeyRequestFailed;
    // 	[Field ("kBCOVFPSAuthProxyErrorCodeContentKeyRequestFailed", "__Internal")]
    // 	nint kBCOVFPSAuthProxyErrorCodeContentKeyRequestFailed { get; }

    // 	// extern const NSInteger kBCOVFPSAuthProxyErrorCodeContentKeyGenerationFailed;
    // 	[Field ("kBCOVFPSAuthProxyErrorCodeContentKeyGenerationFailed", "__Internal")]
    // 	nint kBCOVFPSAuthProxyErrorCodeContentKeyGenerationFailed { get; }
    // }

    // @interface BCOVFPSBrightcoveAuthProxy : NSObject <BCOVFPSAuthorizationProxy>
    [BaseType(typeof(NSObject))]
    interface BCOVFPSBrightcoveAuthProxy : BCOVFPSAuthorizationProxy
    {
        // @property (nonatomic, strong) NSURL * _Null_unspecified fpsBaseURL;
        [Export("fpsBaseURL", ArgumentSemantic.Strong)]
        NSUrl FpsBaseURL { get; set; }

        // @property (nonatomic, strong) NSURL * _Nullable keyRequestURL;
        [NullAllowed, Export("keyRequestURL", ArgumentSemantic.Strong)]
        NSUrl KeyRequestURL { get; set; }

        // @property (nonatomic, strong) NSURLSession * _Null_unspecified sharedURLSession;
        [Export("sharedURLSession", ArgumentSemantic.Strong)]
        NSUrlSession SharedURLSession { get; set; }

        // -(instancetype _Nullable)initWithPublisherId:(NSString * _Nullable)pubId applicationId:(NSString * _Nullable)appId __attribute__((objc_designated_initializer));
        [Export("initWithPublisherId:applicationId:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string pubId, [NullAllowed] string appId);

        // -(void)retrieveApplicationCertificate:(void (^ _Nonnull)(NSData * _Nullable, NSError * _Nullable))completionHandler;
        [Export("retrieveApplicationCertificate:")]
        void RetrieveApplicationCertificate(Action<NSData, NSError> completionHandler);
    }

    // @interface BCOVFairPlayManager : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVFairPlayManager
    {
        // +(void)preloadContentKeysForVideos:(NSArray<BCOVVideo *> * _Nonnull)videos;
        [Static]
        [Export("preloadContentKeysForVideos:")]
        void PreloadContentKeysForVideos(BCOVVideo[] videos);
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const kBCOVSSVideoPropertiesKeyTextTracks;
    // 	[Field ("kBCOVSSVideoPropertiesKeyTextTracks", "__Internal")]
    // 	NSString kBCOVSSVideoPropertiesKeyTextTracks { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKeySource;
    // 	[Field ("kBCOVSSTextTracksKeySource", "__Internal")]
    // 	NSString kBCOVSSTextTracksKeySource { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKeySourceLanguage;
    // 	[Field ("kBCOVSSTextTracksKeySourceLanguage", "__Internal")]
    // 	NSString kBCOVSSTextTracksKeySourceLanguage { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKeyLabel;
    // 	[Field ("kBCOVSSTextTracksKeyLabel", "__Internal")]
    // 	NSString kBCOVSSTextTracksKeyLabel { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKeyDuration;
    // 	[Field ("kBCOVSSTextTracksKeyDuration", "__Internal")]
    // 	NSString kBCOVSSTextTracksKeyDuration { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKeyDefault;
    // 	[Field ("kBCOVSSTextTracksKeyDefault", "__Internal")]
    // 	NSString kBCOVSSTextTracksKeyDefault { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKeyMIMEType;
    // 	[Field ("kBCOVSSTextTracksKeyMIMEType", "__Internal")]
    // 	NSString kBCOVSSTextTracksKeyMIMEType { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKeyKind;
    // 	[Field ("kBCOVSSTextTracksKeyKind", "__Internal")]
    // 	NSString kBCOVSSTextTracksKeyKind { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKindSubtitles;
    // 	[Field ("kBCOVSSTextTracksKindSubtitles", "__Internal")]
    // 	NSString kBCOVSSTextTracksKindSubtitles { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKindCaptions;
    // 	[Field ("kBCOVSSTextTracksKindCaptions", "__Internal")]
    // 	NSString kBCOVSSTextTracksKindCaptions { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKeySourceType;
    // 	[Field ("kBCOVSSTextTracksKeySourceType", "__Internal")]
    // 	NSString kBCOVSSTextTracksKeySourceType { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKeySourceTypeWebVTTURL;
    // 	[Field ("kBCOVSSTextTracksKeySourceTypeWebVTTURL", "__Internal")]
    // 	NSString kBCOVSSTextTracksKeySourceTypeWebVTTURL { get; }

    // 	// extern NSString *const kBCOVSSTextTracksKeySourceTypeM3U8URL;
    // 	[Field ("kBCOVSSTextTracksKeySourceTypeM3U8URL", "__Internal")]
    // 	NSString kBCOVSSTextTracksKeySourceTypeM3U8URL { get; }
    // }

    // @interface BCOVSSAdditions (BCOVPlayerSDKManager)
    //[Category]
    //Hack
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVPlayerSDKManager_BCOVSSAdditions
    {
        // -(id<BCOVPlaybackController>)createSidecarSubtitlesPlaybackControllerWithViewStrategy:(BCOVPlaybackControllerViewStrategy)viewStrategy;
        [Export("createSidecarSubtitlesPlaybackControllerWithViewStrategy:")]
        BCOVPlaybackController CreateSidecarSubtitlesPlaybackControllerWithViewStrategy(BCOVPlaybackControllerViewStrategy viewStrategy);

        // -(id<BCOVPlaybackSessionProvider>)createSidecarSubtitlesSessionProviderWithUpstreamSessionProvider:(id<BCOVPlaybackSessionProvider>)provider;
        [Export("createSidecarSubtitlesSessionProviderWithUpstreamSessionProvider:")]
        BCOVPlaybackSessionProvider CreateSidecarSubtitlesSessionProviderWithUpstreamSessionProvider(BCOVPlaybackSessionProvider provider);
    }

    // @interface BCOVSSAdditionsDepricated (BCOVPlayerSDKManager)
    //[Category]
    //Hack
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVPlayerSDKManager_BCOVSSAdditionsDepricated
    {
        // -(id<BCOVPlaybackSessionProvider>)createSidecarSubtitlesSessionProviderWithOptions:(BCOVSSSessionProviderOption *)options __attribute__((deprecated("Use -[BCOVPlayerSDKManager createSidecarSubtitlesSessionWithUpstreamSessionProvider:] with a nil upstream session provider instead.")));
        [Export("createSidecarSubtitlesSessionProviderWithOptions:")]
        //BCOVPlaybackSessionProvider CreateSidecarSubtitlesSessionProviderWithOptions(BCOVSSSessionProviderOption options);
        //Hack
        BCOVPlaybackSessionProvider CreateSidecarSubtitlesSessionProviderWithOptions(NSObject options);
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const kBCOVCuePointTypeAdSlot;
    // 	[Field ("kBCOVCuePointTypeAdSlot", "__Internal")]
    // 	NSString kBCOVCuePointTypeAdSlot { get; }

    // 	// extern NSString *const kBCOVCuePointTypeAdCompanion;
    // 	[Field ("kBCOVCuePointTypeAdCompanion", "__Internal")]
    // 	NSString kBCOVCuePointTypeAdCompanion { get; }

    // 	// extern NSString *const kBCOVCuePointPropertyKeyName;
    // 	[Field ("kBCOVCuePointPropertyKeyName", "__Internal")]
    // 	NSString kBCOVCuePointPropertyKeyName { get; }
    // }

    // @protocol BCOVCuePoint <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IBCOVCuePoint
    {
        // @required @property (readonly, assign, nonatomic) CMTime position;
        [Abstract]
        [Export("position", ArgumentSemantic.Assign)]
        CMTime Position { get; }

        // @required @property (readonly, copy, nonatomic) NSString * type;
        [Abstract]
        [Export("type")]
        string Type { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary * properties;
        [Abstract]
        [Export("properties", ArgumentSemantic.Copy)]
        NSDictionary Properties { get; }

        // @required -(instancetype)update:(void (^)(id<BCOVMutableCuePoint>))updateBlock;
        [Abstract]
        [Export("update:")]
        BCOVCuePoint Update(Action<BCOVMutableCuePoint> updateBlock);
    }

    // @protocol BCOVMutableCuePoint <BCOVCuePoint>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BCOVMutableCuePoint : IBCOVCuePoint
    {
        // // @required @property (assign, readwrite, nonatomic) CMTime position;
        // [Abstract]
        // [Export ("position", ArgumentSemantic.Assign)]
        // CMTime Position { get; set; }

        // // @required @property (readwrite, copy, nonatomic) NSString * type;
        // [Abstract]
        // [Export ("type")]
        // string Type { get; set; }

        // // @required @property (readwrite, copy, nonatomic) NSDictionary * properties;
        // [Abstract]
        // [Export ("properties", ArgumentSemantic.Copy)]
        // NSDictionary Properties { get; set; }
    }

    // @interface BCOVCuePoint : NSObject <BCOVCuePoint, NSCopying>
    [BaseType(typeof(NSObject))]
    interface BCOVCuePoint : IBCOVCuePoint, INSCopying
    {
        // -(instancetype)initWithType:(NSString *)type position:(CMTime)position;
        [Export("initWithType:position:")]
        IntPtr Constructor(string type, CMTime position);

        // -(instancetype)initWithType:(NSString *)type position:(CMTime)position properties:(NSDictionary *)properties;
        [Export("initWithType:position:properties:")]
        IntPtr Constructor(string type, CMTime position, NSDictionary properties);

        // -(NSComparisonResult)compare:(BCOVCuePoint *)cuePoint;
        [Export("compare:")]
        NSComparisonResult Compare(BCOVCuePoint cuePoint);

        // -(BOOL)hasPosition:(CMTime)position;
        [Export("hasPosition:")]
        bool HasPosition(CMTime position);

        // -(BOOL)isEqualToCuePoint:(BCOVCuePoint *)cuePoint;
        [Export("isEqualToCuePoint:")]
        bool IsEqualToCuePoint(BCOVCuePoint cuePoint);

        // +(BCOVCuePoint *)afterCuePointOfType:(NSString *)type properties:(NSDictionary *)properties;
        [Static]
        [Export("afterCuePointOfType:properties:")]
        BCOVCuePoint AfterCuePointOfType(string type, NSDictionary properties);

        // +(BCOVCuePoint *)beforeCuePointOfType:(NSString *)type properties:(NSDictionary *)properties;
        [Static]
        [Export("beforeCuePointOfType:properties:")]
        BCOVCuePoint BeforeCuePointOfType(string type, NSDictionary properties);

        // +(BCOVCuePoint *)cuePointWithType:(NSString *)type positionInSeconds:(NSTimeInterval)positionInSeconds properties:(NSDictionary *)properties;
        [Static]
        [Export("cuePointWithType:positionInSeconds:properties:")]
        BCOVCuePoint CuePointWithType(string type, double positionInSeconds, NSDictionary properties);
    }

    // @interface BCOVCuePointCollection : NSObject <NSCopying, NSFastEnumeration>
    [BaseType(typeof(NSObject))]
    interface BCOVCuePointCollection : INSCopying //, INSFastEnumeration
    {
        // -(instancetype)initWithArray:(NSArray *)cuePoints;
        [Export("initWithArray:")]
        // [Verify (StronglyTypedNSArray)]
        IntPtr Constructor(NSObject[] cuePoints);

        // -(instancetype)initWithCuePoint:(BCOVCuePoint *)cuePoint;
        [Export("initWithCuePoint:")]
        IntPtr Constructor(BCOVCuePoint cuePoint);

        // -(NSArray *)array;
        [Export("array")]
        // [Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
        NSObject[] Array { get; }

        // -(NSUInteger)count;
        [Export("count")]
        // [Verify (MethodToProperty)]
        nuint Count { get; }

        // -(instancetype)cuePointsAfterTime:(CMTime)time;
        [Export("cuePointsAfterTime:")]
        BCOVCuePointCollection CuePointsAfterTime(CMTime time);

        // -(instancetype)cuePointsBeforeTime:(CMTime)time;
        [Export("cuePointsBeforeTime:")]
        BCOVCuePointCollection CuePointsBeforeTime(CMTime time);

        // -(instancetype)cuePointsAtTime:(CMTime)time;
        [Export("cuePointsAtTime:")]
        BCOVCuePointCollection CuePointsAtTime(CMTime time);

        // -(instancetype)cuePointsAtOrAfterTime:(CMTime)time;
        [Export("cuePointsAtOrAfterTime:")]
        BCOVCuePointCollection CuePointsAtOrAfterTime(CMTime time);

        // -(instancetype)cuePointsAtOrBeforeTime:(CMTime)time;
        [Export("cuePointsAtOrBeforeTime:")]
        BCOVCuePointCollection CuePointsAtOrBeforeTime(CMTime time);

        // -(instancetype)cuePointsAfterTime:(CMTime)lowerBound beforeTime:(CMTime)upperBound;
        [Export("cuePointsAfterTime:beforeTime:")]
        BCOVCuePointCollection CuePointsAfterTime(CMTime lowerBound, CMTime upperBound);

        // -(instancetype)cuePointsAfterTime:(CMTime)lowerBound atOrBeforeTime:(CMTime)upperBound;
        [Export("cuePointsAfterTime:atOrBeforeTime:")]
        BCOVCuePointCollection CuePointsAfterTimeatOrBeforeTime(CMTime lowerBound, CMTime upperBound);

        // -(instancetype)cuePointsAtOrAfterTime:(CMTime)lowerBound beforeTime:(CMTime)upperBound;
        [Export("cuePointsAtOrAfterTime:beforeTime:")]
        BCOVCuePointCollection CuePointsAtOrAfterTime(CMTime lowerBound, CMTime upperBound);

        // -(instancetype)cuePointsAtOrAfterTime:(CMTime)lowerBound atOrBeforeTime:(CMTime)upperBound;
        [Export("cuePointsAtOrAfterTime:atOrBeforeTime:")]
        BCOVCuePointCollection CuePointsAtOrAfterTimeatOrBeforeTime(CMTime lowerBound, CMTime upperBound);

        // -(instancetype)cuePointsOfType:(NSString *)type;
        [Export("cuePointsOfType:")]
        BCOVCuePointCollection CuePointsOfType(string type);

        // -(BOOL)isEqualToCollection:(BCOVCuePointCollection *)collection;
        [Export("isEqualToCollection:")]
        bool IsEqualToCollection(BCOVCuePointCollection collection);

        // -(BCOVCuePoint *)objectAtIndexedSubscript:(NSUInteger)index;
        [Export("objectAtIndexedSubscript:")]
        BCOVCuePoint ObjectAtIndexedSubscript(nuint index);

        // @property (assign, nonatomic) BOOL ignoreCuePoints;
        [Export("ignoreCuePoints")]
        bool IgnoreCuePoints { get; set; }

        // +(instancetype)collectionWithArray:(NSArray *)cuePoints;
        [Static]
        [Export("collectionWithArray:")]
        // [Verify (StronglyTypedNSArray)]
        BCOVCuePointCollection CollectionWithArray(NSObject[] cuePoints);

        // +(instancetype)emptyCollection;
        [Static]
        [Export("emptyCollection")]
        BCOVCuePointCollection EmptyCollection();
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const kBCOVPlaylistPropertiesKeyAccountId;
    // 	[Field ("kBCOVPlaylistPropertiesKeyAccountId", "__Internal")]
    // 	NSString kBCOVPlaylistPropertiesKeyAccountId { get; }

    // 	// extern NSString *const kBCOVPlaylistPropertiesKeyDescription;
    // 	[Field ("kBCOVPlaylistPropertiesKeyDescription", "__Internal")]
    // 	NSString kBCOVPlaylistPropertiesKeyDescription { get; }

    // 	// extern NSString *const kBCOVPlaylistPropertiesKeyId;
    // 	[Field ("kBCOVPlaylistPropertiesKeyId", "__Internal")]
    // 	NSString kBCOVPlaylistPropertiesKeyId { get; }

    // 	// extern NSString *const kBCOVPlaylistPropertiesKeyName;
    // 	[Field ("kBCOVPlaylistPropertiesKeyName", "__Internal")]
    // 	NSString kBCOVPlaylistPropertiesKeyName { get; }

    // 	// extern NSString *const kBCOVPlaylistPropertiesKeyReferenceId;
    // 	[Field ("kBCOVPlaylistPropertiesKeyReferenceId", "__Internal")]
    // 	NSString kBCOVPlaylistPropertiesKeyReferenceId { get; }

    // 	// extern NSString *const kBCOVPlaylistPropertiesKeyType;
    // 	[Field ("kBCOVPlaylistPropertiesKeyType", "__Internal")]
    // 	NSString kBCOVPlaylistPropertiesKeyType { get; }
    // }

    // @protocol BCOVPlaylist <NSObject, NSFastEnumeration>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IBCOVPlaylist //: INSFastEnumeration
    {
        // @required @property (readonly, copy, nonatomic) NSArray * videos;
        [Abstract]
        [Export("videos", ArgumentSemantic.Copy)]
        // [Verify (StronglyTypedNSArray)]
        NSObject[] Videos { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary * properties;
        [Abstract]
        [Export("properties", ArgumentSemantic.Copy)]
        NSDictionary Properties { get; }

        // @required @property (readonly, nonatomic) NSArray<BCOVVideo *> * allPlayableVideos;
        [Abstract]
        [Export("allPlayableVideos")]
        BCOVVideo[] AllPlayableVideos { get; }

        // @required @property (readonly, nonatomic) NSArray<BCOVVideo *> * allFailedVideos;
        [Abstract]
        [Export("allFailedVideos")]
        BCOVVideo[] AllFailedVideos { get; }

        // @required -(instancetype)update:(void (^)(id<BCOVFPS>))updateBlock;
        [Abstract]
        [Export("update:")]
        BCOVPlaylist Update(Action<BCOVMutablePlaylist> updateBlock);

        // @required +(NSArray<BCOVVideo *> *)allPlayableVideosFrom:(id<NSFastEnumeration>)videos;
        //[Static, Abstract]
        //Hack
        [Abstract]
        [Export("allPlayableVideosFrom:")]
        //Hack
        BCOVVideo[] AllPlayableVideosFrom(NSObject videos);
        //BCOVVideo[] AllPlayableVideosFrom(NSFastEnumeration videos);

        // @required +(NSArray<BCOVVideo *> *)allFailedVideosFrom:(id<NSFastEnumeration>)videos;
        //[Static, Abstract]
        //Hack
        [Abstract]
        [Export("allFailedVideosFrom:")]
        //BCOVVideo[] AllFailedVideosFrom(NSFastEnumeration videos);
        //Hack
        BCOVVideo[] AllFailedVideosFrom(NSObject videos);
    }

    // @protocol BCOVMutablePlaylist <BCOVPlaylist>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BCOVMutablePlaylist : IBCOVPlaylist
    {
        // @required @property (readwrite, copy, nonatomic) NSArray * videos;
        // 	[Abstract]
        // 	[Export ("videos", ArgumentSemantic.Copy)]
        // 	[Verify (StronglyTypedNSArray)]
        // 	NSObject[] Videos { get; set; }

        // 	// @required @property (readwrite, copy, nonatomic) NSDictionary * properties;
        // 	[Abstract]
        // 	[Export ("properties", ArgumentSemantic.Copy)]
        // 	NSDictionary Properties { get; set; }
    }

    // @interface BCOVPlaylist : NSObject <BCOVPlaylist, NSCopying>
    [BaseType(typeof(NSObject))]
    interface BCOVPlaylist : IBCOVPlaylist, INSCopying
    {
        // -(instancetype)initWithVideos:(NSArray *)videos properties:(NSDictionary *)properties;
        [Export("initWithVideos:properties:")]
        // [Verify (StronglyTypedNSArray)]
        IntPtr Constructor(NSObject[] videos, NSDictionary properties);

        // -(instancetype)initWithVideos:(NSArray *)videos;
        [Export("initWithVideos:")]
        // [Verify (StronglyTypedNSArray)]
        IntPtr Constructor(NSObject[] videos);

        // -(instancetype)initWithVideo:(BCOVVideo *)video properties:(NSDictionary *)properties;
        [Export("initWithVideo:properties:")]
        IntPtr Constructor(BCOVVideo video, NSDictionary properties);

        // -(instancetype)initWithVideo:(BCOVVideo *)video;
        [Export("initWithVideo:")]
        IntPtr Constructor(BCOVVideo video);

        // -(BCOVVideo *)objectAtIndexedSubscript:(NSUInteger)index;
        [Export("objectAtIndexedSubscript:")]
        BCOVVideo ObjectAtIndexedSubscript(nuint index);

        // -(BOOL)isEqualToPlaylist:(BCOVPlaylist *)playlist;
        [Export("isEqualToPlaylist:")]
        bool IsEqualToPlaylist(BCOVPlaylist playlist);

        // -(NSUInteger)count;
        [Export("count")]
        // [Verify (MethodToProperty)]
        nuint Count { get; }
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const kBCOVSourceURLSchemeHTTP;
    // 	[Field ("kBCOVSourceURLSchemeHTTP", "__Internal")]
    // 	NSString kBCOVSourceURLSchemeHTTP { get; }

    // 	// extern NSString *const kBCOVSourceURLSchemeHTTPS;
    // 	[Field ("kBCOVSourceURLSchemeHTTPS", "__Internal")]
    // 	NSString kBCOVSourceURLSchemeHTTPS { get; }

    // 	// extern NSString *const kBCOVSourceDeliveryHLS;
    // 	[Field ("kBCOVSourceDeliveryHLS", "__Internal")]
    // 	NSString kBCOVSourceDeliveryHLS { get; }

    // 	// extern NSString *const kBCOVSourceDeliveryMP4;
    // 	[Field ("kBCOVSourceDeliveryMP4", "__Internal")]
    // 	NSString kBCOVSourceDeliveryMP4 { get; }

    // 	// extern NSString *const kBCOVSourceDeliveryDASH;
    // 	[Field ("kBCOVSourceDeliveryDASH", "__Internal")]
    // 	NSString kBCOVSourceDeliveryDASH { get; }

    // 	// extern NSString *const kBCOVSourceDeliveryOnce;
    // 	[Field ("kBCOVSourceDeliveryOnce", "__Internal")]
    // 	NSString kBCOVSourceDeliveryOnce { get; }

    // 	// extern NSString *const kBCOVSourceDeliveryBoltSSAI;
    // 	[Field ("kBCOVSourceDeliveryBoltSSAI", "__Internal")]
    // 	NSString kBCOVSourceDeliveryBoltSSAI { get; }

    // 	// extern NSString *const kBCOVSourcePropertyKeySystems;
    // 	[Field ("kBCOVSourcePropertyKeySystems", "__Internal")]
    // 	NSString kBCOVSourcePropertyKeySystems { get; }

    // 	// extern NSString *const kBCOVSourcePropertyKeyEXTXVersion;
    // 	[Field ("kBCOVSourcePropertyKeyEXTXVersion", "__Internal")]
    // 	NSString kBCOVSourcePropertyKeyEXTXVersion { get; }

    // 	// extern NSString *const kBCOVSourcePropertyKeyType;
    // 	[Field ("kBCOVSourcePropertyKeyType", "__Internal")]
    // 	NSString kBCOVSourcePropertyKeyType { get; }

    // 	// extern NSString *const kBCOVSourcePropertyKeyVMAP;
    // 	[Field ("kBCOVSourcePropertyKeyVMAP", "__Internal")]
    // 	NSString kBCOVSourcePropertyKeyVMAP { get; }
    // }

    // @protocol BCOVSource <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface IBCOVSource
    {
        // @required @property (readonly, copy, nonatomic) NSURL * url;
        [Abstract]
        [Export("url", ArgumentSemantic.Copy)]
        NSUrl Url { get; }

        // @required @property (readonly, copy, nonatomic) NSString * deliveryMethod;
        [Abstract]
        [Export("deliveryMethod")]
        string DeliveryMethod { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary * properties;
        [Abstract]
        [Export("properties", ArgumentSemantic.Copy)]
        NSDictionary Properties { get; }

        // @required -(instancetype)update:(void (^)(id<BCOVMutableSource>))updateBlock;
        [Abstract]
        [Export("update:")]
        BCOVSource Update(Action<BCOVMutableSource> updateBlock);
    }

    // @protocol BCOVMutableSource <BCOVSource>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BCOVMutableSource : IBCOVSource
    {
        // // @required @property (readwrite, copy, nonatomic) NSURL * url;
        // [Abstract]
        // [Export ("url", ArgumentSemantic.Copy)]
        // NSUrl Url { get; set; }

        // // @required @property (readwrite, copy, nonatomic) NSString * deliveryMethod;
        // [Abstract]
        // [Export ("deliveryMethod")]
        // string DeliveryMethod { get; set; }

        // // @required @property (readwrite, copy, nonatomic) NSDictionary * properties;
        // [Abstract]
        // [Export ("properties", ArgumentSemantic.Copy)]
        // NSDictionary Properties { get; set; }
    }

    // @interface BCOVSource : NSObject <BCOVSource, NSCopying>
    //[Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVSource : IBCOVSource, INSCopying
    {
        // -(instancetype)initWithURL:(NSURL *)url;
        [Export("initWithURL:")]
        IntPtr Constructor(NSUrl url);

        // -(instancetype)initWithURL:(NSURL *)url deliveryMethod:(NSString *)deliveryMethod properties:(NSDictionary *)properties;
        [Export("initWithURL:deliveryMethod:properties:")]
        IntPtr Constructor(NSUrl url, string deliveryMethod, NSDictionary properties);

        // -(BOOL)isEqualToSource:(BCOVSource *)source;
        [Export("isEqualToSource:")]
        bool IsEqualToSource(BCOVSource source);
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const kBCOVVideoPropertyKeyAccountId;
    // 	[Field ("kBCOVVideoPropertyKeyAccountId", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyAccountId { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyDescription;
    // 	[Field ("kBCOVVideoPropertyKeyDescription", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyDescription { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyDuration;
    // 	[Field ("kBCOVVideoPropertyKeyDuration", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyDuration { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyEconomics;
    // 	[Field ("kBCOVVideoPropertyKeyEconomics", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyEconomics { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyId;
    // 	[Field ("kBCOVVideoPropertyKeyId", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyId { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyLongDescription;
    // 	[Field ("kBCOVVideoPropertyKeyLongDescription", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyLongDescription { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyName;
    // 	[Field ("kBCOVVideoPropertyKeyName", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyName { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyPoster;
    // 	[Field ("kBCOVVideoPropertyKeyPoster", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyPoster { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyPosterSources;
    // 	[Field ("kBCOVVideoPropertyKeyPosterSources", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyPosterSources { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyProjection;
    // 	[Field ("kBCOVVideoPropertyKeyProjection", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyProjection { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyReferenceId;
    // 	[Field ("kBCOVVideoPropertyKeyReferenceId", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyReferenceId { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyTags;
    // 	[Field ("kBCOVVideoPropertyKeyTags", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyTags { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyTextTracks;
    // 	[Field ("kBCOVVideoPropertyKeyTextTracks", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyTextTracks { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyThumbnail;
    // 	[Field ("kBCOVVideoPropertyKeyThumbnail", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyThumbnail { get; }

    // 	// extern NSString *const kBCOVVideoPropertyKeyThumbnailSources;
    // 	[Field ("kBCOVVideoPropertyKeyThumbnailSources", "__Internal")]
    // 	NSString kBCOVVideoPropertyKeyThumbnailSources { get; }
    // }

    // @protocol BCOVVideo <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IBCOVVideo
    {
        // @required @property (readonly, copy, nonatomic) BCOVCuePointCollection * cuePoints;
        [Abstract]
        [Export("cuePoints", ArgumentSemantic.Copy)]
        BCOVCuePointCollection CuePoints { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary * properties;
        [Abstract]
        [Export("properties", ArgumentSemantic.Copy)]
        NSDictionary Properties { get; }

        // @required @property (nonatomic) BCOVEconomics economics;
        [Abstract]
        [Export("economics", ArgumentSemantic.Assign)]
        BCOVEconomics Economics { get; set; }

        // @required @property (readonly, copy, nonatomic) NSArray<BCOVSource *> * sources;
        [Abstract]
        [Export("sources", ArgumentSemantic.Copy)]
        BCOVSource[] Sources { get; }

        // @required -(instancetype)update:(void (^)(id<BCOVMutableVideo>))updateBlock;
        [Abstract]
        [Export("update:")]
        BCOVVideo Update(Action<BCOVMutableVideo> updateBlock);
    }

    // @protocol BCOVMutableVideo <BCOVVideo>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVMutableVideo : IBCOVVideo
    {
        // // @required @property (readwrite, copy, nonatomic) BCOVCuePointCollection * cuePoints;
        // [Abstract]
        // [Export ("cuePoints", ArgumentSemantic.Copy)]
        // BCOVCuePointCollection CuePoints { get; set; }

        // // @required @property (readwrite, copy, nonatomic) NSDictionary * properties;
        // [Abstract]
        // [Export ("properties", ArgumentSemantic.Copy)]
        // NSDictionary Properties { get; set; }

        // // @required @property (readwrite, copy, nonatomic) NSArray * sources;
        // [Abstract]
        // [Export ("sources", ArgumentSemantic.Copy)]
        // [Verify (StronglyTypedNSArray)]
        // NSObject[] Sources { get; set; }
    }

    // @interface BCOVVideo : NSObject <BCOVVideo, NSCopying>
    [BaseType(typeof(NSObject))]
    interface BCOVVideo : IBCOVVideo, INSCopying
    {
        // @property (readonly, nonatomic) BOOL canBeDownloaded;
        [Export("canBeDownloaded")]
        bool CanBeDownloaded { get; }

        // @property (readonly, nonatomic) BOOL usesFairPlay;
        [Export("usesFairPlay")]
        bool UsesFairPlay { get; }

        // @property (readonly, nonatomic) BOOL offline;
        [Export("offline")]
        bool Offline { get; }

        // @property (readonly, nonatomic) BOOL playableOffline;
        [Export("playableOffline")]
        bool PlayableOffline { get; }

        // @property (copy, nonatomic) NSString * errorCode;
        [Export("errorCode")]
        string ErrorCode { get; set; }

        // @property (copy, nonatomic) NSString * errorSubCode;
        [Export("errorSubCode")]
        string ErrorSubCode { get; set; }

        // @property (copy, nonatomic) NSString * errorMessage;
        [Export("errorMessage")]
        string ErrorMessage { get; set; }

        // @property (readonly, nonatomic) BOOL hasError;
        [Export("hasError")]
        bool HasError { get; }

        // -(instancetype)initWithSources:(NSArray<BCOVSource *> *)sources cuePoints:(BCOVCuePointCollection *)cuePoints properties:(NSDictionary *)properties;
        [Export("initWithSources:cuePoints:properties:")]
        IntPtr Constructor(BCOVSource[] sources, BCOVCuePointCollection cuePoints, NSDictionary properties);

        // -(instancetype)initWithSource:(BCOVSource *)source cuePoints:(BCOVCuePointCollection *)cuePoints properties:(NSDictionary *)properties;
        [Export("initWithSource:cuePoints:properties:")]
        IntPtr Constructor(BCOVSource source, BCOVCuePointCollection cuePoints, NSDictionary properties);

        // -(instancetype)initWithErrorCode:(NSString *)errorCode errorSubCode:(NSString *)errorSubCode errorMessage:(NSString *)errorMessage properties:(NSDictionary *)properties;
        [Export("initWithErrorCode:errorSubCode:errorMessage:properties:")]
        IntPtr Constructor(string errorCode, string errorSubCode, string errorMessage, NSDictionary properties);

        // -(BOOL)isEqualToVideo:(BCOVVideo *)video;
        [Export("isEqualToVideo:")]
        bool IsEqualToVideo(BCOVVideo video);

        // +(BCOVVideo *)videoWithURL:(NSURL *)url;
        [Static]
        [Export("videoWithURL:")]
        BCOVVideo VideoWithURL(NSUrl url);

        // +(BCOVVideo *)videoWithHLSSourceURL:(NSURL *)url;
        [Static]
        [Export("videoWithHLSSourceURL:")]
        BCOVVideo VideoWithHLSSourceURL(NSUrl url);

        // +(BCOVVideo *)videoWithURL:(NSURL *)url deliveryMethod:(NSString *)deliveryMethod;
        [Static]
        [Export("videoWithURL:deliveryMethod:")]
        BCOVVideo VideoWithURL(NSUrl url, string deliveryMethod);
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern NSString *const kBCOVPlaybackSessionLifecycleEventWillPauseForAd;
    // 	[Field ("kBCOVPlaybackSessionLifecycleEventWillPauseForAd", "__Internal")]
    // 	NSString kBCOVPlaybackSessionLifecycleEventWillPauseForAd { get; }
    // }

    // @interface BCOVAdSequence : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVAdSequence
    {
        // @property (readonly, nonatomic) CMTime beginTime;
        [Export("beginTime")]
        CMTime BeginTime { get; }

        // @property (readonly, nonatomic) CMTime duration;
        [Export("duration")]
        CMTime Duration { get; }

        // @property (readonly, copy, nonatomic) NSArray * ads;
        [Export("ads", ArgumentSemantic.Copy)]
        // [Verify (StronglyTypedNSArray)]
        NSObject[] Ads { get; }

        // @property (readonly, copy, nonatomic) NSDictionary * properties;
        [Export("properties", ArgumentSemantic.Copy)]
        NSDictionary Properties { get; }

        // -(instancetype)initWithAds:(NSArray *)ads properties:(NSDictionary *)properties;
        [Export("initWithAds:properties:")]
        // [Verify (StronglyTypedNSArray)]
        IntPtr Constructor(NSObject[] ads, NSDictionary properties);

        // -(BOOL)isEqualToAdSequence:(BCOVAdSequence *)adSequence;
        [Export("isEqualToAdSequence:")]
        bool IsEqualToAdSequence(BCOVAdSequence adSequence);
    }

    // @interface BCOVAd : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVAd
    {
        // @property (readonly, copy, nonatomic) NSString * title;
        [Export("title")]
        string Title { get; }

        // @property (readonly, copy, nonatomic) NSString * adId;
        [Export("adId")]
        string AdId { get; }

        // @property (readonly, nonatomic) CMTime beginTime;
        [Export("beginTime")]
        CMTime BeginTime { get; }

        // @property (readonly, nonatomic) CMTime duration;
        [Export("duration")]
        CMTime Duration { get; }

        // @property (readonly, copy, nonatomic) NSDictionary * properties;
        [Export("properties", ArgumentSemantic.Copy)]
        NSDictionary Properties { get; }

        // -(instancetype)initWithTitle:(NSString *)title adId:(NSString *)adId beginTime:(CMTime)beginTime duration:(CMTime)duration properties:(NSDictionary *)properties __attribute__((objc_designated_initializer));
        [Export("initWithTitle:adId:beginTime:duration:properties:")]
        [DesignatedInitializer]
        IntPtr Constructor(string title, string adId, CMTime beginTime, CMTime duration, NSDictionary properties);

        // -(BOOL)isEqualToAd:(BCOVAd *)ad;
        [Export("isEqualToAd:")]
        bool IsEqualToAd(BCOVAd ad);
    }

    // @protocol BCOVPlaybackControllerAdsDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface IBCOVPlaybackControllerAdsDelegate
    {
        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didEnterAdSequence:(BCOVAdSequence *)adSequence;
        [Export("playbackController:playbackSession:didEnterAdSequence:")]
        void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVAdSequence adSequence);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didExitAdSequence:(BCOVAdSequence *)adSequence;
        [Export("playbackController:playbackSession:didExitAdSequence:")]
        void PlaybackSessiondidExitAdSequence(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVAdSequence adSequence);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didEnterAd:(BCOVAd *)ad;
        [Export("playbackController:playbackSession:didEnterAd:")]
        void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVAd ad);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didExitAd:(BCOVAd *)ad;
        [Export("playbackController:playbackSession:didExitAd:")]
        void PlaybackSessiondidExitAd(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVAd ad);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session ad:(BCOVAd *)ad didProgressTo:(NSTimeInterval)progress;
        [Export("playbackController:playbackSession:ad:didProgressTo:")]
        void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVAd ad, double progress);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didPauseAd:(BCOVAd *)ad;
        [Export("playbackController:playbackSession:didPauseAd:")]
        void PlaybackSessionplaybackSessiondidPauseAd(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVAd ad);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didResumeAd:(BCOVAd *)ad;
        [Export("playbackController:playbackSession:didResumeAd:")]
        void PlaybackSessionplaybackSessiondidResumeAd(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVAd ad);
    }

    // @protocol BCOVPlaybackSessionAdsConsumer <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IBCOVPlaybackSessionAdsConsumer
    {
        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didEnterAdSequence:(BCOVAdSequence *)adSequence;
        [Export("playbackSession:didEnterAdSequence:")]
        void DidEnterAdSequence(BCOVPlaybackSession session, BCOVAdSequence adSequence);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didExitAdSequence:(BCOVAdSequence *)adSequence;
        [Export("playbackSession:didExitAdSequence:")]
        void DidExitAdSequence(BCOVPlaybackSession session, BCOVAdSequence adSequence);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didEnterAd:(BCOVAd *)ad;
        [Export("playbackSession:didEnterAd:")]
        void DidEnterAd(BCOVPlaybackSession session, BCOVAd ad);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didExitAd:(BCOVAd *)ad;
        [Export("playbackSession:didExitAd:")]
        void DidExitAd(BCOVPlaybackSession session, BCOVAd ad);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session ad:(BCOVAd *)ad didProgressTo:(NSTimeInterval)progress;
        [Export("playbackSession:ad:didProgressTo:")]
        void Ad(BCOVPlaybackSession session, BCOVAd ad, double progress);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didPauseAd:(BCOVAd *)ad;
        [Export("playbackSession:didPauseAd:")]
        void DidPauseAd(BCOVPlaybackSession session, BCOVAd ad);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didResumeAd:(BCOVAd *)ad;
        [Export("playbackSession:didResumeAd:")]
        void DidResumeAd(BCOVPlaybackSession session, BCOVAd ad);
    }

    // @interface BCOVPUICommon : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVPUICommon
    {
        // +(UIFont *)iconFont;
        [Static]
        [Export("iconFont")]
        // [Verify (MethodToProperty)]
        UIFont IconFont { get; }

        // +(UIFont *)iconFontWithSize:(CGFloat)fontSize;
        [Static]
        [Export("iconFontWithSize:")]
        UIFont IconFontWithSize(nfloat fontSize);

        // +(NSString *)fontUnicodeForButtonIcon:(BCOVPUIButtonIcon)buttonIcon;
        [Static]
        [Export("fontUnicodeForButtonIcon:")]
        string FontUnicodeForButtonIcon(BCOVPUIButtonIcon buttonIcon);

        // +(UIColor *)controlColorForNormalState;
        [Static]
        [Export("controlColorForNormalState")]
        // [Verify (MethodToProperty)]
        UIColor ControlColorForNormalState { get; }

        // +(UIColor *)controlColorForSelectedState;
        [Static]
        [Export("controlColorForSelectedState")]
        // [Verify (MethodToProperty)]
        UIColor ControlColorForSelectedState { get; }

        // +(UIColor *)controlColorForHighlightedState;
        [Static]
        [Export("controlColorForHighlightedState")]
        // [Verify (MethodToProperty)]
        UIColor ControlColorForHighlightedState { get; }

        // +(UIColor *)controlColorForDisabledState;
        [Static]
        [Export("controlColorForDisabledState")]
        // [Verify (MethodToProperty)]
        UIColor ControlColorForDisabledState { get; }

        // +(UIColor *)liveViewTitleColorForLive;
        [Static]
        [Export("liveViewTitleColorForLive")]
        // [Verify (MethodToProperty)]
        UIColor LiveViewTitleColorForLive { get; }

        // +(UIColor *)progressSliderMaximumTrackTintColor;
        [Static]
        [Export("progressSliderMaximumTrackTintColor")]
        // [Verify (MethodToProperty)]
        UIColor ProgressSliderMaximumTrackTintColor { get; }

        // +(UIColor *)progressSliderMinimumTrackTintColor;
        [Static]
        [Export("progressSliderMinimumTrackTintColor")]
        // [Verify (MethodToProperty)]
        UIColor ProgressSliderMinimumTrackTintColor { get; }

        // +(UIColor *)progressSliderBufferProgressTintColor;
        [Static]
        [Export("progressSliderBufferProgressTintColor")]
        // [Verify (MethodToProperty)]
        UIColor ProgressSliderBufferProgressTintColor { get; }

        // +(UIImage *)imageForVolumeViewWithFontSize:(CGFloat)fontSize color:(UIColor *)color;
        [Static]
        [Export("imageForVolumeViewWithFontSize:color:")]
        UIImage ImageForVolumeViewWithFontSize(nfloat fontSize, UIColor color);

        // +(CGFloat)defaultFontSizeForLabel;
        [Static]
        [Export("defaultFontSizeForLabel")]
        // [Verify (MethodToProperty)]
        nfloat DefaultFontSizeForLabel { get; }

        // +(CGFloat)defaultFontSizeForButton;
        [Static]
        [Export("defaultFontSizeForButton")]
        // [Verify (MethodToProperty)]
        nfloat DefaultFontSizeForButton { get; }
    }

    // @interface BCOVPUIAdControlView : UIView
    [BaseType(typeof(UIView))]
    interface BCOVPUIAdControlView
    {
        // @property (nonatomic) int adPodCount;
        [Export("adPodCount")]
        int AdPodCount { get; set; }

        // @property (nonatomic) float adPodRemaining;
        [Export("adPodRemaining")]
        float AdPodRemaining { get; set; }

        // @property (nonatomic) int adPodIndex;
        [Export("adPodIndex")]
        int AdPodIndex { get; set; }

        // @property (nonatomic) float adDuration;
        [Export("adDuration")]
        float AdDuration { get; set; }

        // @property (nonatomic) float adCurrentTime;
        [Export("adCurrentTime")]
        float AdCurrentTime { get; set; }

        // @property (nonatomic) BOOL adIsSkippable;
        [Export("adIsSkippable")]
        bool AdIsSkippable { get; set; }

        // @property (nonatomic) float adSkipTime;
        [Export("adSkipTime")]
        float AdSkipTime { get; set; }

        // @property (readwrite, nonatomic) BOOL advertisingMode;
        [Export("advertisingMode")]
        bool AdvertisingMode { get; set; }

        // @property (readonly, nonatomic) BCOVPUIButton * adPodCountdownButton;
        [Export("adPodCountdownButton")]
        BCOVPUIButton AdPodCountdownButton { get; }

        // @property (readonly, nonatomic) BCOVPUIButton * learnMoreButton;
        [Export("learnMoreButton")]
        BCOVPUIButton LearnMoreButton { get; }

        // @property (readonly, nonatomic) BCOVPUIButton * skipAdCountdownButton;
        [Export("skipAdCountdownButton")]
        BCOVPUIButton SkipAdCountdownButton { get; }

        // @property (readonly, nonatomic) BCOVPUIButton * skipAdButton;
        [Export("skipAdButton")]
        BCOVPUIButton SkipAdButton { get; }

        // @property (readwrite, nonatomic) float controlBarHeight;
        [Export("controlBarHeight")]
        float ControlBarHeight { get; set; }

        // -(void)showControls:(BOOL)show;
        [Export("showControls:")]
        void ShowControls(bool show);

        // -(void)enableControls:(BOOL)enabled;
        [Export("enableControls:")]
        void EnableControls(bool enabled);

        // -(void)setFontSizeForControls:(CGFloat)fontSize;
        [Export("setFontSizeForControls:")]
        void SetFontSizeForControls(nfloat fontSize);

        // -(void)setTextColorForControls:(UIColor *)textColor forState:(UIControlState)state;
        [Export("setTextColorForControls:forState:")]
        void SetTextColorForControls(UIColor textColor, UIControlState state);
    }

    // [Static]
    // [Verify (ConstantsInterfaceAssociation)]
    // partial interface Constants
    // {
    // 	// extern CGFloat kBCOVPUILayoutUseDefaultValue;
    // 	[Field ("kBCOVPUILayoutUseDefaultValue", "__Internal")]
    // 	nfloat kBCOVPUILayoutUseDefaultValue { get; }
    // }

    // @interface BCOVPUIControlLayout : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface BCOVPUIControlLayout : INSCopying
    {
        // @property (readonly, copy, nonatomic) NSArray * standardLayoutItems;
        [Export("standardLayoutItems", ArgumentSemantic.Copy)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] StandardLayoutItems { get; }

        // @property (readonly, copy, nonatomic) NSArray * compactLayoutItems;
        [Export("compactLayoutItems", ArgumentSemantic.Copy)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] CompactLayoutItems { get; }

        // @property (readonly, copy, nonatomic) NSSet * allLayoutItems;
        [Export("allLayoutItems", ArgumentSemantic.Copy)]
        NSSet AllLayoutItems { get; }

        // @property (assign, nonatomic) CGFloat controlBarHeight;
        [Export("controlBarHeight")]
        nfloat ControlBarHeight { get; set; }

        // @property (assign, nonatomic) CGFloat horizontalItemSpacing;
        [Export("horizontalItemSpacing")]
        nfloat HorizontalItemSpacing { get; set; }

        // @property (assign, nonatomic) CGFloat compactLayoutMaximumWidth;
        [Export("compactLayoutMaximumWidth")]
        nfloat CompactLayoutMaximumWidth { get; set; }

        // -(instancetype)initWithStandardControls:(NSArray *)standardLayoutLines compactControls:(NSArray *)compactLayoutLines;
        [Export("initWithStandardControls:compactControls:")]
        //[Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
        IntPtr Constructor(NSObject[] standardLayoutLines, NSObject[] compactLayoutLines);

        // +(instancetype)basicVODControlLayout;
        [Static]
        [Export("basicVODControlLayout")]
        BCOVPUIControlLayout BasicVODControlLayout();

        // +(instancetype)basicLiveControlLayout;
        [Static]
        [Export("basicLiveControlLayout")]
        BCOVPUIControlLayout BasicLiveControlLayout();

        // +(instancetype)basicLiveDVRControlLayout;
        [Static]
        [Export("basicLiveDVRControlLayout")]
        BCOVPUIControlLayout BasicLiveDVRControlLayout();
    }

    // @interface BCOVPUIBasicControlView : UIView
    [BaseType(typeof(UIView))]
    interface BCOVPUIBasicControlView
    {
        // @property (readonly, nonatomic, weak) UIView * backgroundView;
        [Export("backgroundView", ArgumentSemantic.Weak)]
        UIView BackgroundView { get; }

        // @property (copy, nonatomic) BCOVPUIControlLayout * layout;
        [Export("layout", ArgumentSemantic.Copy)]
        BCOVPUIControlLayout Layout { get; set; }

        // @property (readonly, nonatomic, weak) BCOVPUIButton * playbackButton;
        [Export("playbackButton", ArgumentSemantic.Weak)]
        BCOVPUIButton PlaybackButton { get; }

        // @property (readonly, nonatomic, weak) BCOVPUIButton * jumpBackButton;
        [Export("jumpBackButton", ArgumentSemantic.Weak)]
        BCOVPUIButton JumpBackButton { get; }

        // @property (readonly, nonatomic, weak) BCOVUILabel * currentTimeLabel;
        [Export("currentTimeLabel", ArgumentSemantic.Weak)]
        BCOVUILabel CurrentTimeLabel { get; }

        // @property (readonly, nonatomic, weak) UILabel * timeSeparatorLabel;
        [Export("timeSeparatorLabel", ArgumentSemantic.Weak)]
        UILabel TimeSeparatorLabel { get; }

        // @property (readonly, nonatomic, weak) BCOVUILabel * durationLabel;
        [Export("durationLabel", ArgumentSemantic.Weak)]
        BCOVUILabel DurationLabel { get; }

        // @property (readonly, nonatomic, weak) BCOVPUISlider * progressSlider;
        [Export("progressSlider", ArgumentSemantic.Weak)]
        BCOVPUISlider ProgressSlider { get; }

        // @property (readonly, nonatomic, weak) BCOVPUIButton * closedCaptionButton;
        [Export("closedCaptionButton", ArgumentSemantic.Weak)]
        BCOVPUIButton ClosedCaptionButton { get; }

        // @property (readonly, nonatomic, weak) BCOVPUIButton * screenModeButton;
        [Export("screenModeButton", ArgumentSemantic.Weak)]
        BCOVPUIButton ScreenModeButton { get; }

        // @property (readonly, nonatomic, weak) BCOVPUIButton * video360Button;
        [Export("video360Button", ArgumentSemantic.Weak)]
        BCOVPUIButton Video360Button { get; }

        // @property (readonly, nonatomic, weak) UIView * externalRouteView;
        [Export("externalRouteView", ArgumentSemantic.Weak)]
        UIView ExternalRouteView { get; }

        // @property (readonly, nonatomic, weak) BCOVPUIButton * liveButton;
        [Export("liveButton", ArgumentSemantic.Weak)]
        BCOVPUIButton LiveButton { get; }

        // @property (readonly, nonatomic, weak) BCOVPUIButton * preferredBitrateButton;
        [Export("preferredBitrateButton", ArgumentSemantic.Weak)]
        BCOVPUIButton PreferredBitrateButton { get; }

        // @property (readonly, nonatomic, weak) BCOVPUIButton * pictureInPictureButton;
        [Export("pictureInPictureButton", ArgumentSemantic.Weak)]
        BCOVPUIButton PictureInPictureButton { get; }

        // @property (readonly, getter = isClosedCaptionEnabled, nonatomic) BOOL closedCaptionEnabled;
        [Export("closedCaptionEnabled")]
        bool ClosedCaptionEnabled { [Bind("isClosedCaptionEnabled")] get; }

        // @property (readonly, getter = isExternalRouteEnabled, assign, nonatomic) BOOL externalRouteEnabled;
        [Export("externalRouteEnabled")]
        bool ExternalRouteEnabled { [Bind("isExternalRouteEnabled")] get; }

        // @property (assign, nonatomic) BOOL preferredBitrateEnabled;
        [Export("preferredBitrateEnabled")]
        bool PreferredBitrateEnabled { get; set; }

        // @property (assign, nonatomic) BOOL pictureInPictureEnabled;
        [Export("pictureInPictureEnabled")]
        bool PictureInPictureEnabled { get; set; }

        // @property (readwrite, nonatomic) BOOL advertisingMode;
        [Export("advertisingMode")]
        bool AdvertisingMode { get; set; }

        // +(BCOVPUILayoutView *)layoutViewWithControlFromTag:(BCOVPUIViewTag)tag width:(CGFloat)width elasticity:(CGFloat)elasticity;
        [Static]
        [Export("layoutViewWithControlFromTag:width:elasticity:")]
        BCOVPUILayoutView LayoutViewWithControlFromTag(BCOVPUIViewTag tag, nfloat width, nfloat elasticity);

        // +(instancetype)basicControlViewWithVODLayout;
        [Static]
        [Export("basicControlViewWithVODLayout")]
        BCOVPUIBasicControlView BasicControlViewWithVODLayout();

        // +(instancetype)basicControlViewWithLiveLayout;
        [Static]
        [Export("basicControlViewWithLiveLayout")]
        BCOVPUIBasicControlView BasicControlViewWithLiveLayout();

        // +(instancetype)basicControlViewWithLiveDVRLayout;
        [Static]
        [Export("basicControlViewWithLiveDVRLayout")]
        BCOVPUIBasicControlView BasicControlViewWithLiveDVRLayout();

        // -(void)enableControls:(BOOL)enabled;
        [Export("enableControls:")]
        void EnableControls(bool enabled);

        // -(void)setFontSizeForLabels:(CGFloat)fontSize;
        [Export("setFontSizeForLabels:")]
        void SetFontSizeForLabels(nfloat fontSize);

        // -(void)setFontSizeForButtons:(CGFloat)fontSize;
        [Export("setFontSizeForButtons:")]
        void SetFontSizeForButtons(nfloat fontSize);

        // -(void)setTextColorForLabels:(UIColor *)textColor;
        [Export("setTextColorForLabels:")]
        void SetTextColorForLabels(UIColor textColor);

        // -(void)setTitleColorForButtons:(UIColor *)titleColor forState:(UIControlState)state;
        [Export("setTitleColorForButtons:forState:")]
        void SetTitleColorForButtons(UIColor titleColor, UIControlState state);

        // -(void)video360OptionSelected:(BOOL)isGogglesMode;
        [Export("video360OptionSelected:")]
        void Video360OptionSelected(bool isGogglesMode);

        // +(UIView *)createPUIControlItemWithViewTag:(BCOVPUIViewTag)tag;
        [Static]
        [Export("createPUIControlItemWithViewTag:")]
        UIView CreatePUIControlItemWithViewTag(BCOVPUIViewTag tag);

        // -(void)setButtonsAccessibilityDelegate:(id<BCOVPUIButtonAccessibilityDelegate>)delegate;
        [Export("setButtonsAccessibilityDelegate:")]
        void SetButtonsAccessibilityDelegate(BCOVPUIButtonAccessibilityDelegate @delegate);
    }

    // @protocol BCOVPUIButtonAccessibilityDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BCOVPUIButtonAccessibilityDelegate
    {
        // @required -(NSString *)accessibilityLabelForButton:(BCOVPUIButton *)button isPrimaryState:(BOOL)isPrimaryState;
        [Abstract]
        [Export("accessibilityLabelForButton:isPrimaryState:")]
        string IsPrimaryState(BCOVPUIButton button, bool isPrimaryState);
    }

    // @interface BCOVPUIButton : UIButton
    [BaseType(typeof(UIButton))]
    interface BCOVPUIButton
    {
        // @property (readwrite, copy, nonatomic) NSString * primaryTitle;
        [Export("primaryTitle")]
        string PrimaryTitle { get; set; }

        // @property (readwrite, copy, nonatomic) NSString * secondaryTitle;
        [Export("secondaryTitle")]
        string SecondaryTitle { get; set; }

        // -(void)showPrimaryTitle:(BOOL)primary;
        [Export("showPrimaryTitle:")]
        void ShowPrimaryTitle(bool primary);

        [Wrap("WeakAccessibilityDelegate")]
        BCOVPUIButtonAccessibilityDelegate AccessibilityDelegate { get; set; }

        // @property (nonatomic, weak) id<BCOVPUIButtonAccessibilityDelegate> accessibilityDelegate;
        [NullAllowed, Export("accessibilityDelegate", ArgumentSemantic.Weak)]
        NSObject WeakAccessibilityDelegate { get; set; }
    }

    // @interface BCOVPUILayoutView : UIView
    [BaseType(typeof(UIView))]
    interface BCOVPUILayoutView
    {
        // @property (readwrite, nonatomic) float minimumWidth;
        [Export("minimumWidth")]
        float MinimumWidth { get; set; }

        // @property (readwrite, nonatomic) float elasticity;
        [Export("elasticity")]
        float Elasticity { get; set; }

        // @property (getter = isRemoved, readwrite, nonatomic) BOOL removed;
        [Export("removed")]
        bool Removed { [Bind("isRemoved")] get; set; }
    }

    // @protocol BCOVPUIPlayerViewDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BCOVPUIPlayerViewDelegate
    {
        // @optional -(void)playerView:(BCOVPUIPlayerView *)playerView willTransitionToScreenMode:(BCOVPUIScreenMode)screenMode;
        [Export("playerView:willTransitionToScreenMode:")]
        void PlayerView(BCOVPUIPlayerView playerView, BCOVPUIScreenMode screenMode);

        // @optional -(void)playerView:(BCOVPUIPlayerView *)playerView didTransitionToScreenMode:(BCOVPUIScreenMode)screenMode;
        [Export("playerView:didTransitionToScreenMode:")]
        void PlayerViewdidTransitionToScreenMode(BCOVPUIPlayerView playerView, BCOVPUIScreenMode screenMode);

        // @optional -(void)playerView:(BCOVPUIPlayerView *)playerView controlsFadingViewDidFadeOut:(UIView *)controlsFadingView;
        [Export("playerView:controlsFadingViewDidFadeOut:")]
        void PlayerView(BCOVPUIPlayerView playerView, UIView controlsFadingView);

        // @optional -(void)playerView:(BCOVPUIPlayerView *)playerView controlsFadingViewDidFadeIn:(UIView *)controlsFadingView;
        [Export("playerView:controlsFadingViewDidFadeIn:")]
        void PlayerViewcontrolsFadingViewDidFadeIn(BCOVPUIPlayerView playerView, UIView controlsFadingView);

        // @optional -(CGRect)playerViewShouldDisplayThumbnailPreviewWithRect:(BCOVPUIPlayerView *)playerView;
        [Export("playerViewShouldDisplayThumbnailPreviewWithRect:")]
        NSObject PlayerViewShouldDisplayThumbnailPreviewWithRect(BCOVPUIPlayerView playerView);

        // @optional -(void)willOpenInAppBrowserWithAd:(BCOVAd *)ad;
        [Export("willOpenInAppBrowserWithAd:")]
        void WillOpenInAppBrowserWithAd(BCOVAd ad);

        // @optional -(void)didOpenInAppBrowserWithAd:(BCOVAd *)ad;
        [Export("didOpenInAppBrowserWithAd:")]
        void DidOpenInAppBrowserWithAd(BCOVAd ad);

        // @optional -(void)willCloseInAppBrowserWithAd:(BCOVAd *)ad;
        [Export("willCloseInAppBrowserWithAd:")]
        void WillCloseInAppBrowserWithAd(BCOVAd ad);

        // @optional -(void)didCloseInAppBrowserWithAd:(BCOVAd *)ad;
        [Export("didCloseInAppBrowserWithAd:")]
        void DidCloseInAppBrowserWithAd(BCOVAd ad);

        // @optional -(void)willOpenExternalBrowserWithAd:(BCOVAd *)ad;
        [Export("willOpenExternalBrowserWithAd:")]
        void WillOpenExternalBrowserWithAd(BCOVAd ad);

        // @optional -(void)didReturnFromExternalBrowserWithAd:(BCOVAd *)ad;
        [Export("didReturnFromExternalBrowserWithAd:")]
        void DidReturnFromExternalBrowserWithAd(BCOVAd ad);

        // @optional -(void)routePickerViewWillBeginPresentingRoutes:(AVRoutePickerView *)routePickerView;
        [Export("routePickerViewWillBeginPresentingRoutes:")]
        void RoutePickerViewWillBeginPresentingRoutes(AVRoutePickerView routePickerView);

        // @optional -(void)routePickerViewDidEndPresentingRoutes:(AVRoutePickerView *)routePickerView;
        [Export("routePickerViewDidEndPresentingRoutes:")]
        void RoutePickerViewDidEndPresentingRoutes(AVRoutePickerView routePickerView);

        // @optional -(void)didSetVideo360NavigationMethod:(BCOVPUIVideo360NavigationMethod)navigationMethod projectionStyle:(BCOVVideo360ProjectionStyle)projectionStyle;
        [Export("didSetVideo360NavigationMethod:projectionStyle:")]
        void DidSetVideo360NavigationMethod(BCOVPUIVideo360NavigationMethod navigationMethod, BCOVVideo360ProjectionStyle projectionStyle);

        // @optional -(void)pictureInPictureControllerDidStartPictureInPicture:(AVPictureInPictureController *)pictureInPictureController;
        [Export("pictureInPictureControllerDidStartPictureInPicture:")]
        void PictureInPictureControllerDidStartPictureInPicture(AVPictureInPictureController pictureInPictureController);

        // @optional -(void)pictureInPictureControllerDidStopPictureInPicture:(AVPictureInPictureController *)pictureInPictureController;
        [Export("pictureInPictureControllerDidStopPictureInPicture:")]
        void PictureInPictureControllerDidStopPictureInPicture(AVPictureInPictureController pictureInPictureController);

        // @optional -(void)pictureInPictureControllerWillStartPictureInPicture:(AVPictureInPictureController *)pictureInPictureController;
        [Export("pictureInPictureControllerWillStartPictureInPicture:")]
        void PictureInPictureControllerWillStartPictureInPicture(AVPictureInPictureController pictureInPictureController);

        // @optional -(void)pictureInPictureControllerWillStopPictureInPicture:(AVPictureInPictureController *)pictureInPictureController;
        [Export("pictureInPictureControllerWillStopPictureInPicture:")]
        void PictureInPictureControllerWillStopPictureInPicture(AVPictureInPictureController pictureInPictureController);

        // @optional -(void)pictureInPictureController:(AVPictureInPictureController *)pictureInPictureController failedToStartPictureInPictureWithError:(NSError *)error;
        [Export("pictureInPictureController:failedToStartPictureInPictureWithError:")]
        void PictureInPictureController(AVPictureInPictureController pictureInPictureController, NSError error);

        // @optional -(void)progressSliderDidTouchDown:(UISlider *)slider;
        [Export("progressSliderDidTouchDown:")]
        void ProgressSliderDidTouchDown(UISlider slider);

        // @optional -(void)progressSliderDidTouchUp:(UISlider *)slider;
        [Export("progressSliderDidTouchUp:")]
        void ProgressSliderDidTouchUp(UISlider slider);

        // @optional -(void)progressSliderDidChangeValue:(UISlider *)slider;
        [Export("progressSliderDidChangeValue:")]
        void ProgressSliderDidChangeValue(UISlider slider);
    }

    // @interface BCOVPreferredBitrateConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVPreferredBitrateConfig
    {
        // @property (copy, nonatomic) NSString * menuTitle;
        [Export("menuTitle")]
        string MenuTitle { get; set; }

        // @property (nonatomic, strong) NSArray<NSDictionary<NSString *,NSNumber *> *> * bitrateOptions;
        [Export("bitrateOptions", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSNumber>[] BitrateOptions { get; set; }

        // @property (readonly, assign, nonatomic) NSUInteger initialSelectionIndex;
        [Export("initialSelectionIndex")]
        nuint InitialSelectionIndex { get; }

        // +(BCOVPreferredBitrateConfig *)configWithMenuTitle:(NSString *)menuTitle andBitrateOptions:(NSArray<NSDictionary<NSString *,NSNumber *> *> *)bitrateOptions;
        [Static]
        [Export("configWithMenuTitle:andBitrateOptions:")]
        BCOVPreferredBitrateConfig ConfigWithMenuTitle(string menuTitle, NSDictionary<NSString, NSNumber>[] bitrateOptions);

        // +(BCOVPreferredBitrateConfig *)configWithMenuTitle:(NSString *)menuTitle bitrateOptions:(NSArray<NSDictionary<NSString *,NSNumber *> *> *)bitrateOptions andIndexofInitialSelection:(NSInteger)initialSelectionIndex;
        [Static]
        [Export("configWithMenuTitle:bitrateOptions:andIndexofInitialSelection:")]
        BCOVPreferredBitrateConfig ConfigWithMenuTitle(string menuTitle, NSDictionary<NSString, NSNumber>[] bitrateOptions, nint initialSelectionIndex);
    }

    // @interface BCOVPUIPlayerViewOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVPUIPlayerViewOptions
    {
        // @property (nonatomic, strong) BCOVPreferredBitrateConfig * preferredBitrateConfig;
        [Export("preferredBitrateConfig", ArgumentSemantic.Strong)]
        BCOVPreferredBitrateConfig PreferredBitrateConfig { get; set; }

        // @property (nonatomic, weak) UIViewController * presentingViewController;
        [Export("presentingViewController", ArgumentSemantic.Weak)]
        UIViewController PresentingViewController { get; set; }

        // @property (assign, nonatomic) NSTimeInterval jumpBackInterval;
        [Export("jumpBackInterval")]
        double JumpBackInterval { get; set; }

        // @property (assign, nonatomic) NSTimeInterval hideControlsInterval;
        [Export("hideControlsInterval")]
        double HideControlsInterval { get; set; }

        // @property (assign, nonatomic) NSTimeInterval hideControlsAnimationDuration;
        [Export("hideControlsAnimationDuration")]
        double HideControlsAnimationDuration { get; set; }

        // @property (assign, nonatomic) NSTimeInterval showControlsAnimationDuration;
        [Export("showControlsAnimationDuration")]
        double ShowControlsAnimationDuration { get; set; }

        // @property (assign, nonatomic) BCOVPUILearnMoreButtonBrowserStyle learnMoreButtonBrowserStyle;
        [Export("learnMoreButtonBrowserStyle", ArgumentSemantic.Assign)]
        BCOVPUILearnMoreButtonBrowserStyle LearnMoreButtonBrowserStyle { get; set; }

        // @property (assign, nonatomic) float panMin;
        [Export("panMin")]
        float PanMin { get; set; }

        // @property (assign, nonatomic) float panMax;
        [Export("panMax")]
        float PanMax { get; set; }

        // @property (assign, nonatomic) float panInertia;
        [Export("panInertia")]
        float PanInertia { get; set; }

        // @property (assign, nonatomic) float tiltMin;
        [Export("tiltMin")]
        float TiltMin { get; set; }

        // @property (assign, nonatomic) float tiltMax;
        [Export("tiltMax")]
        float TiltMax { get; set; }

        // @property (assign, nonatomic) float zoomMin;
        [Export("zoomMin")]
        float ZoomMin { get; set; }

        // @property (assign, nonatomic) float zoomMax;
        [Export("zoomMax")]
        float ZoomMax { get; set; }

        // @property (assign, nonatomic) float rotateMin;
        [Export("rotateMin")]
        float RotateMin { get; set; }

        // @property (assign, nonatomic) float rotateMax;
        [Export("rotateMax")]
        float RotateMax { get; set; }

        // @property (assign, nonatomic) BOOL showPictureInPictureButton;
        [Export("showPictureInPictureButton")]
        bool ShowPictureInPictureButton { get; set; }
    }

    // @interface BCOVPUIPlayerView : UIView
    [BaseType(typeof(UIView))]
    interface BCOVPUIPlayerView
    {
        // @property (nonatomic, weak) id<BCOVPlaybackController> playbackController;
        [Export("playbackController", ArgumentSemantic.Weak)]
        BCOVPlaybackController PlaybackController { get; set; }

        [Wrap("WeakDelegate")]
        BCOVPUIPlayerViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BCOVPUIPlayerViewDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, weak) UIView * contentContainerView;
        [Export("contentContainerView", ArgumentSemantic.Weak)]
        UIView ContentContainerView { get; }

        // @property (readonly, nonatomic, weak) UIView * contentOverlayView;
        [Export("contentOverlayView", ArgumentSemantic.Weak)]
        UIView ContentOverlayView { get; }

        // @property (readonly, nonatomic, weak) UIView * controlsContainerView;
        [Export("controlsContainerView", ArgumentSemantic.Weak)]
        UIView ControlsContainerView { get; }

        // @property (readonly, nonatomic, weak) UIView * controlsStaticView;
        [Export("controlsStaticView", ArgumentSemantic.Weak)]
        UIView ControlsStaticView { get; }

        // @property (readonly, nonatomic, weak) UIView * controlsFadingView;
        [Export("controlsFadingView", ArgumentSemantic.Weak)]
        UIView ControlsFadingView { get; }

        // @property (nonatomic) BOOL controlsFadingViewVisible;
        [Export("controlsFadingViewVisible")]
        bool ControlsFadingViewVisible { get; set; }

        // @property (readonly, nonatomic, weak) UIView * overlayView;
        [Export("overlayView", ArgumentSemantic.Weak)]
        UIView OverlayView { get; }

        // @property (readonly, nonatomic) BCOVPUIBasicControlView * controlsView;
        [Export("controlsView")]
        BCOVPUIBasicControlView ControlsView { get; }

        // @property (readonly, nonatomic) BCOVPUIAdControlView * adControlsView;
        [Export("adControlsView")]
        BCOVPUIAdControlView AdControlsView { get; }

        // @property (readwrite, nonatomic) BCOVPUIVideo360NavigationMethod video360NavigationMethod;
        [Export("video360NavigationMethod", ArgumentSemantic.Assign)]
        BCOVPUIVideo360NavigationMethod Video360NavigationMethod { get; set; }

        // -(instancetype)initWithPlaybackController:(id<BCOVPlaybackController>)playbackController;
        [Export("initWithPlaybackController:")]
        IntPtr Constructor(BCOVPlaybackController playbackController);

        // -(instancetype)initWithPlaybackController:(id<BCOVPlaybackController>)playbackController options:(BCOVPUIPlayerViewOptions *)options;
        [Export("initWithPlaybackController:options:")]
        IntPtr Constructor(BCOVPlaybackController playbackController, BCOVPUIPlayerViewOptions options);

        // -(instancetype)initWithPlaybackController:(id<BCOVPlaybackController>)playbackController options:(BCOVPUIPlayerViewOptions *)options controlsView:(BCOVPUIBasicControlView *)controlsView __attribute__((objc_designated_initializer));
        [Export("initWithPlaybackController:options:controlsView:")]
        [DesignatedInitializer]
        IntPtr Constructor(BCOVPlaybackController playbackController, BCOVPUIPlayerViewOptions options, BCOVPUIBasicControlView controlsView);

        // -(void)performScreenTransitionWithScreenMode:(BCOVPUIScreenMode)screenMode;
        [Export("performScreenTransitionWithScreenMode:")]
        void PerformScreenTransitionWithScreenMode(BCOVPUIScreenMode screenMode);

        // -(void)resetHideControlsIntervalTimer;
        [Export("resetHideControlsIntervalTimer")]
        void ResetHideControlsIntervalTimer();
    }

    // @interface BCOVPUISlider : UISlider
    [BaseType(typeof(UISlider))]
    interface BCOVPUISlider
    {
        // @property (readwrite, nonatomic) CGFloat trackHeight;
        [Export("trackHeight")]
        nfloat TrackHeight { get; set; }

        // @property (readwrite, nonatomic) float bufferProgress;
        [Export("bufferProgress")]
        float BufferProgress { get; set; }

        // @property (readwrite, nonatomic) BOOL advertisingMode;
        [Export("advertisingMode")]
        bool AdvertisingMode { get; set; }

        // @property (nonatomic) UIColor * bufferProgressTintColor;
        [Export("bufferProgressTintColor", ArgumentSemantic.Assign)]
        UIColor BufferProgressTintColor { get; set; }

        // @property (nonatomic) UIColor * advertisingMinimumTrackTintColor;
        [Export("advertisingMinimumTrackTintColor", ArgumentSemantic.Assign)]
        UIColor AdvertisingMinimumTrackTintColor { get; set; }

        // @property (nonatomic) UIColor * advertisingMaximumTrackTintColor;
        [Export("advertisingMaximumTrackTintColor", ArgumentSemantic.Assign)]
        UIColor AdvertisingMaximumTrackTintColor { get; set; }

        // @property (nonatomic) UIColor * markerTickColor;
        [Export("markerTickColor", ArgumentSemantic.Assign)]
        UIColor MarkerTickColor { get; set; }

        // @property (readwrite, nonatomic) double duration;
        [Export("duration")]
        double Duration { get; set; }

        // -(void)addMarkerAt:(double)position duration:(double)duration isAd:(BOOL)isAd image:(UIImage *)image;
        [Export("addMarkerAt:duration:isAd:image:")]
        void AddMarkerAt(double position, double duration, bool isAd, UIImage image);

        // -(void)removeMarkerAtPosition:(double)position;
        [Export("removeMarkerAtPosition:")]
        void RemoveMarkerAtPosition(double position);

        // -(void)removeAllMarkers;
        [Export("removeAllMarkers")]
        void RemoveAllMarkers();

        // -(void)removeGenericMarkers;
        [Export("removeGenericMarkers")]
        void RemoveGenericMarkers();

        // -(void)removeAdMarkers;
        [Export("removeAdMarkers")]
        void RemoveAdMarkers();

        // -(void)setCustomMinimumTrackImage:(UIImage *)image forState:(UIControlState)state;
        [Export("setCustomMinimumTrackImage:forState:")]
        void SetCustomMinimumTrackImage(UIImage image, UIControlState state);

        // -(void)setCustomMaximumTrackImage:(UIImage *)image forState:(UIControlState)state;
        [Export("setCustomMaximumTrackImage:forState:")]
        void SetCustomMaximumTrackImage(UIImage image, UIControlState state);
    }

    // @interface BCOVOfflineVideoManager : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVOfflineVideoManager
    {
        // @property (nonatomic, strong) id<BCOVFPSAuthorizationProxy> authProxy;
        [Export("authProxy", ArgumentSemantic.Strong)]
        BCOVFPSAuthorizationProxy AuthProxy { get; set; }

        [Wrap("WeakDelegate")]
        NSObject Delegate { get; set; }

        // @property (assign, nonatomic) id delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) NSArray * offlineVideoTokens;
        [Export("offlineVideoTokens")]
        // [Verify (StronglyTypedNSArray)]
        NSObject[] OfflineVideoTokens { get; }

        // +(BCOVOfflineVideoManager *)sharedManager;
        [Static]
        [Export("sharedManager")]
        // [Verify (MethodToProperty)]
        BCOVOfflineVideoManager SharedManager { get; }

        // +(void)initializeOfflineVideoManagerWithDelegate:(id)delegate options:(NSDictionary *)options;
        [Static]
        [Export("initializeOfflineVideoManagerWithDelegate:options:")]
        void InitializeOfflineVideoManagerWithDelegate(NSObject @delegate, NSDictionary options);

        // -(void)requestVideoDownload:(BCOVVideo *)video mediaSelections:(NSArray<AVMediaSelection *> *)mediaSelections parameters:(NSDictionary *)parameters completion:(void (^)(int, NSError *))completionHandler;
        [Export("requestVideoDownload:mediaSelections:parameters:completion:")]
        void RequestVideoDownload(BCOVVideo video, AVMediaSelection[] mediaSelections, NSDictionary parameters, Action<int, NSError> completionHandler);

        // -(NSArray *)offlineVideoStatus;
        [Export("offlineVideoStatus")]
        // [Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
        NSObject[] OfflineVideoStatus { get; }

        // -(id)offlineVideoStatusForToken:(id)offlineVideoToken;
        [Export("offlineVideoStatusForToken:")]
        NSObject OfflineVideoStatusForToken(NSObject offlineVideoToken);

        // -(void)pauseVideoDownload:(id)offlineVideoToken;
        [Export("pauseVideoDownload:")]
        void PauseVideoDownload(NSObject offlineVideoToken);

        // -(void)resumeVideoDownload:(id)offlineVideoToken;
        [Export("resumeVideoDownload:")]
        void ResumeVideoDownload(NSObject offlineVideoToken);

        // -(void)cancelVideoDownload:(id)offlineVideoToken;
        [Export("cancelVideoDownload:")]
        void CancelVideoDownload(NSObject offlineVideoToken);

        // -(void)deleteOfflineVideo:(id)offlineVideoToken;
        [Export("deleteOfflineVideo:")]
        void DeleteOfflineVideo(NSObject offlineVideoToken);

        // -(void)forceStopAllDownloadTasks;
        [Export("forceStopAllDownloadTasks")]
        void ForceStopAllDownloadTasks();

        // -(void)estimateDownloadSize:(BCOVVideo *)video options:(NSDictionary *)options completion:(void (^)(double, NSError *))completionHandler;
        [Export("estimateDownloadSize:options:completion:")]
        void EstimateDownloadSize(BCOVVideo video, NSDictionary options, Action<double, NSError> completionHandler);

        // -(AVURLAsset *)urlAssetForVideo:(BCOVVideo *)video error:(NSError **)error;
        [Export("urlAssetForVideo:error:")]
        AVUrlAsset UrlAssetForVideo(BCOVVideo video, out NSError error);

        // -(void)variantAttributesDictionariesForVideo:(BCOVVideo *)video completion:(void (^)(NSArray<NSDictionary *> *, NSError *))completionHandler;
        [Export("variantAttributesDictionariesForVideo:completion:")]
        void VariantAttributesDictionariesForVideo(BCOVVideo video, Action<NSArray<NSDictionary>, NSError> completionHandler);

        // -(void)alternativeRenditionAttributesDictionariesForVideo:(BCOVVideo *)video completion:(void (^)(NSArray<NSDictionary *> *, NSError *))completionHandler;
        [Export("alternativeRenditionAttributesDictionariesForVideo:completion:")]
        void AlternativeRenditionAttributesDictionariesForVideo(BCOVVideo video, Action<NSArray<NSDictionary>, NSError> completionHandler);

        // -(void)variantBitratesForVideo:(BCOVVideo *)video completion:(void (^)(NSArray<NSNumber *> *, NSError *))completionHandler;
        [Export("variantBitratesForVideo:completion:")]
        void VariantBitratesForVideo(BCOVVideo video, Action<NSArray<NSNumber>, NSError> completionHandler);

        // -(BCOVVideo *)videoObjectFromOfflineVideoToken:(id)offlineVideoToken;
        [Export("videoObjectFromOfflineVideoToken:")]
        BCOVVideo VideoObjectFromOfflineVideoToken(NSObject offlineVideoToken);

        // -(void)preloadFairPlayLicense:(BCOVVideo *)video parameters:(NSDictionary *)parameters completion:(void (^)(int, NSError *))completionHandler;
        [Export("preloadFairPlayLicense:parameters:completion:")]
        void PreloadFairPlayLicense(BCOVVideo video, NSDictionary parameters, Action<int, NSError> completionHandler);

        // -(void)renewFairPlayLicense:(id)offlineVideoToken video:(BCOVVideo *)video parameters:(NSDictionary *)parameters completion:(void (^)(int, NSError *))completionHandler;
        [Export("renewFairPlayLicense:video:parameters:completion:")]
        void RenewFairPlayLicense(NSObject offlineVideoToken, BCOVVideo video, NSDictionary parameters, Action<int, NSError> completionHandler);

        // -(void)renewFairPlayLicense:(id)offlineVideoToken video:(BCOVVideo *)video authToken:(NSString *)authToken parameters:(NSDictionary *)parameters completion:(void (^)(int, NSError *))completionHandler;
        [Export("renewFairPlayLicense:video:authToken:parameters:completion:")]
        void RenewFairPlayLicense(NSObject offlineVideoToken, BCOVVideo video, string authToken, NSDictionary parameters, Action<int, NSError> completionHandler);

        // -(void)addFairPlayApplicationCertificate:(NSData *)applicationCertificateData identifier:(NSString *)identifier;
        [Export("addFairPlayApplicationCertificate:identifier:")]
        void AddFairPlayApplicationCertificate(NSData applicationCertificateData, string identifier);

        // -(void)invalidateFairPlayLicense:(id)offlineVideoToken;
        [Export("invalidateFairPlayLicense:")]
        void InvalidateFairPlayLicense(NSObject offlineVideoToken);

        // -(NSDate *)fairPlayLicenseExpiration:(id)offlineVideoToken;
        [Export("fairPlayLicenseExpiration:")]
        NSDate FairPlayLicenseExpiration(NSObject offlineVideoToken);

        // -(AVMediaSelectionGroup *)mediaSelectionGroupForMediaCharacteristic:(NSString *)mediaCharacteristic offlineVideoToken:(id)offlineVideoToken;
        [Export("mediaSelectionGroupForMediaCharacteristic:offlineVideoToken:")]
        AVMediaSelectionGroup MediaSelectionGroupForMediaCharacteristic(string mediaCharacteristic, NSObject offlineVideoToken);

        // -(NSArray<AVMediaSelectionOption *> *)downloadedMediaSelectionOptionsForMediaCharacteristic:(NSString *)mediaCharacteristic offlineVideoToken:(id)offlineVideoToken;
        [Export("downloadedMediaSelectionOptionsForMediaCharacteristic:offlineVideoToken:")]
        AVMediaSelectionOption[] DownloadedMediaSelectionOptionsForMediaCharacteristic(string mediaCharacteristic, NSObject offlineVideoToken);
    }

    // @interface BCOVUILabel : UILabel
    [BaseType(typeof(UILabel))]
    interface BCOVUILabel
    {
        // @property (nonatomic, strong) NSString * _Nonnull accessibilityLabelPrefix;
        [Export("accessibilityLabelPrefix", ArgumentSemantic.Strong)]
        string AccessibilityLabelPrefix { get; set; }
    }

}
