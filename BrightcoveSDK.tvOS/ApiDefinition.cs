using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using AVFoundation;
using System.Collections.Generic;

namespace BrightcoveSDK.tvOS
{
    //[Static]
    partial interface Constants
    {
        //    // extern NSString *const kBCOVCuePointTypeAdSlot;
        //    [Field("kBCOVCuePointTypeAdSlot")]
        //    NSString kBCOVCuePointTypeAdSlot { get; }

        //    // extern NSString *const kBCOVCuePointTypeAdCompanion;
        //    [Field("kBCOVCuePointTypeAdCompanion")]
        //    NSString kBCOVCuePointTypeAdCompanion { get; }

        //    // extern NSString *const kBCOVCuePointPropertyKeyName;
        //    [Field("kBCOVCuePointPropertyKeyName")]
        //    NSString kBCOVCuePointPropertyKeyName { get; }
    }

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
    [Protocol]
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
        // @required @property (assign, readwrite, nonatomic) CMTime position;
        //[Abstract]
        //[Export("position", ArgumentSemantic.Assign)]
        //CMTime Position { get; set; }

        //// @required @property (readwrite, copy, nonatomic) NSString * type;
        //[Abstract]
        //[Export("type")]
        //string Type { get; set; }

        //// @required @property (readwrite, copy, nonatomic) NSDictionary * properties;
        //[Abstract]
        //[Export("properties", ArgumentSemantic.Copy)]
        //NSDictionary Properties { get; set; }
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

    //[Static]
    partial interface Constants
    {
        //    // extern NSString *const kBCOVPlaylistPropertiesKeyAccountId;
        //    [Field("kBCOVPlaylistPropertiesKeyAccountId")]
        //    NSString kBCOVPlaylistPropertiesKeyAccountId { get; }

        //    // extern NSString *const kBCOVPlaylistPropertiesKeyDescription;
        //    [Field("kBCOVPlaylistPropertiesKeyDescription")]
        //    NSString kBCOVPlaylistPropertiesKeyDescription { get; }

        //    // extern NSString *const kBCOVPlaylistPropertiesKeyId;
        //    [Field("kBCOVPlaylistPropertiesKeyId")]
        //    NSString kBCOVPlaylistPropertiesKeyId { get; }

        //    // extern NSString *const kBCOVPlaylistPropertiesKeyName;
        //    [Field("kBCOVPlaylistPropertiesKeyName")]
        //    NSString kBCOVPlaylistPropertiesKeyName { get; }

        //    // extern NSString *const kBCOVPlaylistPropertiesKeyReferenceId;
        //    [Field("kBCOVPlaylistPropertiesKeyReferenceId")]
        //    NSString kBCOVPlaylistPropertiesKeyReferenceId { get; }

        //    // extern NSString *const kBCOVPlaylistPropertiesKeyType;
        //    [Field("kBCOVPlaylistPropertiesKeyType")]
        //    NSString kBCOVPlaylistPropertiesKeyType { get; }
    }

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
        NSObject[] Videos { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary * properties;
        [Abstract]
        [Export("properties", ArgumentSemantic.Copy)]
        NSDictionary Properties { get; }

        // @required -(instancetype)update:(void (^)(id<BCOVMutablePlaylist>))updateBlock;
        [Abstract]
        [Export("update:")]
        BCOVPlaylist Update(Action<BCOVMutablePlaylist> updateBlock);
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
        //[Abstract]
        //[Export("videos", ArgumentSemantic.Copy)]
        //NSObject[] Videos { get; set; }

        //// @required @property (readwrite, copy, nonatomic) NSDictionary * properties;
        //[Abstract]
        //[Export("properties", ArgumentSemantic.Copy)]
        //NSDictionary Properties { get; set; }
    }

    // @interface BCOVPlaylist : NSObject <BCOVPlaylist, NSCopying>
    [BaseType(typeof(NSObject))]
    interface BCOVPlaylist : IBCOVPlaylist, INSCopying
    {
        // -(instancetype)initWithVideos:(NSArray *)videos properties:(NSDictionary *)properties;
        [Export("initWithVideos:properties:")]
        //[Verify(StronglyTypedNSArray)]
        IntPtr Constructor(NSObject[] videos, NSDictionary properties);

        // -(instancetype)initWithVideos:(NSArray *)videos;
        [Export("initWithVideos:")]
        //[Verify(StronglyTypedNSArray)]
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
        //[Verify(MethodToProperty)]
        nuint Count { get; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        //    // extern NSString *const kBCOVSourceURLSchemeHTTP;
        //    [Field("kBCOVSourceURLSchemeHTTP")]
        //    NSString kBCOVSourceURLSchemeHTTP { get; }

        //    // extern NSString *const kBCOVSourceURLSchemeHTTPS;
        //    [Field("kBCOVSourceURLSchemeHTTPS")]
        //    NSString kBCOVSourceURLSchemeHTTPS { get; }

        //    // extern NSString *const kBCOVSourceDeliveryHLS;
        //    [Field("kBCOVSourceDeliveryHLS")]
        //    NSString kBCOVSourceDeliveryHLS { get; }

        //    // extern NSString *const kBCOVSourceDeliveryMP4;
        //    [Field("kBCOVSourceDeliveryMP4")]
        //    NSString kBCOVSourceDeliveryMP4 { get; }

        //    // extern NSString *const kBCOVSourceDeliveryDASH;
        //    [Field("kBCOVSourceDeliveryDASH")]
        //    NSString kBCOVSourceDeliveryDASH { get; }

        //    // extern NSString *const kBCOVSourceDeliveryOnce;
        //    [Field("kBCOVSourceDeliveryOnce")]
        //    NSString kBCOVSourceDeliveryOnce { get; }

        //    // extern NSString *const kBCOVSourceDeliveryBoltSSAI;
        //    [Field("kBCOVSourceDeliveryBoltSSAI")]
        //    NSString kBCOVSourceDeliveryBoltSSAI { get; }

        //    // extern NSString *const kBCOVSourcePropertyKeySystems;
        //    [Field("kBCOVSourcePropertyKeySystems")]
        //    NSString kBCOVSourcePropertyKeySystems { get; }

        //    // extern NSString *const kBCOVSourcePropertyKeyEXTXVersion;
        //    [Field("kBCOVSourcePropertyKeyEXTXVersion")]
        //    NSString kBCOVSourcePropertyKeyEXTXVersion { get; }

        //    // extern NSString *const kBCOVSourcePropertyKeyType;
        //    [Field("kBCOVSourcePropertyKeyType")]
        //    NSString kBCOVSourcePropertyKeyType { get; }

        //    // extern NSString *const kBCOVSourcePropertyKeyVMAP;
        //    [Field("kBCOVSourcePropertyKeyVMAP")]
        //    NSString kBCOVSourcePropertyKeyVMAP { get; }
    }

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
        // @required @property (readwrite, copy, nonatomic) NSURL * url;
        //[Abstract]
        //[Export("url", ArgumentSemantic.Copy)]
        //NSUrl Url { get; set; }

        //// @required @property (readwrite, copy, nonatomic) NSString * deliveryMethod;
        //[Abstract]
        //[Export("deliveryMethod")]
        //string DeliveryMethod { get; set; }

        //// @required @property (readwrite, copy, nonatomic) NSDictionary * properties;
        //[Abstract]
        //[Export("properties", ArgumentSemantic.Copy)]
        //NSDictionary Properties { get; set; }
    }

    // @interface BCOVSource : NSObject <BCOVSource, NSCopying>
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

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        //    // extern NSString *const kBCOVVideoPropertyKeyAccountId;
        //    [Field("kBCOVVideoPropertyKeyAccountId")]
        //    NSString kBCOVVideoPropertyKeyAccountId { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyDescription;
        //    [Field("kBCOVVideoPropertyKeyDescription")]
        //    NSString kBCOVVideoPropertyKeyDescription { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyDuration;
        //    [Field("kBCOVVideoPropertyKeyDuration")]
        //    NSString kBCOVVideoPropertyKeyDuration { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyEconomics;
        //    [Field("kBCOVVideoPropertyKeyEconomics")]
        //    NSString kBCOVVideoPropertyKeyEconomics { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyId;
        //    [Field("kBCOVVideoPropertyKeyId")]
        //    NSString kBCOVVideoPropertyKeyId { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyLongDescription;
        //    [Field("kBCOVVideoPropertyKeyLongDescription")]
        //    NSString kBCOVVideoPropertyKeyLongDescription { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyName;
        //    [Field("kBCOVVideoPropertyKeyName")]
        //    NSString kBCOVVideoPropertyKeyName { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyPoster;
        //    [Field("kBCOVVideoPropertyKeyPoster")]
        //    NSString kBCOVVideoPropertyKeyPoster { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyPosterSources;
        //    [Field("kBCOVVideoPropertyKeyPosterSources")]
        //    NSString kBCOVVideoPropertyKeyPosterSources { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyProjection;
        //    [Field("kBCOVVideoPropertyKeyProjection")]
        //    NSString kBCOVVideoPropertyKeyProjection { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyReferenceId;
        //    [Field("kBCOVVideoPropertyKeyReferenceId")]
        //    NSString kBCOVVideoPropertyKeyReferenceId { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyTags;
        //    [Field("kBCOVVideoPropertyKeyTags")]
        //    NSString kBCOVVideoPropertyKeyTags { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyTextTracks;
        //    [Field("kBCOVVideoPropertyKeyTextTracks")]
        //    NSString kBCOVVideoPropertyKeyTextTracks { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyThumbnail;
        //    [Field("kBCOVVideoPropertyKeyThumbnail")]
        //    NSString kBCOVVideoPropertyKeyThumbnail { get; }

        //    // extern NSString *const kBCOVVideoPropertyKeyThumbnailSources;
        //    [Field("kBCOVVideoPropertyKeyThumbnailSources")]
        //    NSString kBCOVVideoPropertyKeyThumbnailSources { get; }
    }

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
    [Protocol]
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

        // @required @property (readonly, copy, nonatomic) NSArray * sources;
        [Abstract]
        [Export("sources", ArgumentSemantic.Copy)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] Sources { get; }

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
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BCOVMutableVideo : IBCOVVideo
    {
        // @required @property (readwrite, copy, nonatomic) BCOVCuePointCollection * cuePoints;
        //[Abstract]
        //[Export("cuePoints", ArgumentSemantic.Copy)]
        //BCOVCuePointCollection CuePoints { get; set; }

        //// @required @property (readwrite, copy, nonatomic) NSDictionary * properties;
        //[Abstract]
        //[Export("properties", ArgumentSemantic.Copy)]
        //NSDictionary Properties { get; set; }

        //// @required @property (readwrite, copy, nonatomic) NSArray * sources;
        //[Abstract]
        //[Export("sources", ArgumentSemantic.Copy)]
        ////[Verify(StronglyTypedNSArray)]
        //NSObject[] Sources { get; set; }
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

        // -(instancetype)initWithSources:(NSArray *)sources cuePoints:(BCOVCuePointCollection *)cuePoints properties:(NSDictionary *)properties;
        [Export("initWithSources:cuePoints:properties:")]
        //[Verify(StronglyTypedNSArray)]
        IntPtr Constructor(NSObject[] sources, BCOVCuePointCollection cuePoints, NSDictionary properties);

        // -(instancetype)initWithSource:(BCOVSource *)source cuePoints:(BCOVCuePointCollection *)cuePoints properties:(NSDictionary *)properties;
        [Export("initWithSource:cuePoints:properties:")]
        IntPtr Constructor(BCOVSource source, BCOVCuePointCollection cuePoints, NSDictionary properties);

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

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        //// extern NSString *const kBCOVPlaybackServiceErrorDomain;
        //[Field("kBCOVPlaybackServiceErrorDomain")]
        //NSString kBCOVPlaybackServiceErrorDomain { get; }

        //// extern NSString *const kBCOVPlaybackServiceErrorKeyRawResponseData;
        //[Field("kBCOVPlaybackServiceErrorKeyRawResponseData")]
        //NSString kBCOVPlaybackServiceErrorKeyRawResponseData { get; }

        //// extern NSString *const kBCOVPlaybackServiceErrorKeyAPIErrors;
        //[Field("kBCOVPlaybackServiceErrorKeyAPIErrors")]
        //NSString kBCOVPlaybackServiceErrorKeyAPIErrors { get; }

        //// extern NSString *const kBCOVPlaybackServiceErrorKeyAPIHTTPStatusCode;
        //[Field("kBCOVPlaybackServiceErrorKeyAPIHTTPStatusCode")]
        //NSString kBCOVPlaybackServiceErrorKeyAPIHTTPStatusCode { get; }

        //// extern NSString *const kBCOVPlaybackServiceParameterKeyLimit;
        //[Field("kBCOVPlaybackServiceParameterKeyLimit")]
        //NSString kBCOVPlaybackServiceParameterKeyLimit { get; }

        //// extern NSString *const kBCOVPlaybackServiceParameterKeyOffset;
        //[Field("kBCOVPlaybackServiceParameterKeyOffset")]
        //NSString kBCOVPlaybackServiceParameterKeyOffset { get; }

        //// extern NSString *const kBCOVPlaybackServiceParamaterKeyAdConfigId;
        //[Field("kBCOVPlaybackServiceParamaterKeyAdConfigId")]
        //NSString kBCOVPlaybackServiceParamaterKeyAdConfigId { get; }
    }

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

        // -(void)findPlaylistWithPlaylistID:(NSString *)playlistID parameters:(NSDictionary *)parameters completion:(void (^)(BCOVPlaylist *, NSDictionary *, NSError *))completionHandler;
        [Export("findPlaylistWithPlaylistID:parameters:completion:")]
        void FindPlaylistWithPlaylistID(string playlistID, NSDictionary parameters, Action<BCOVPlaylist, NSDictionary, NSError> completionHandler);

        // -(void)findPlaylistWithPlaylistID:(NSString *)playlistID authToken:(NSString *)authToken parameters:(NSDictionary *)parameters completion:(void (^)(BCOVPlaylist *, NSDictionary *, NSError *))completionHandler;
        [Export("findPlaylistWithPlaylistID:authToken:parameters:completion:")]
        void FindPlaylistWithPlaylistID(string playlistID, string authToken, NSDictionary parameters, Action<BCOVPlaylist, NSDictionary, NSError> completionHandler);

        // -(void)findPlaylistWithReferenceID:(NSString *)referenceID parameters:(NSDictionary *)parameters completion:(void (^)(BCOVPlaylist *, NSDictionary *, NSError *))completionHandler;
        [Export("findPlaylistWithReferenceID:parameters:completion:")]
        void FindPlaylistWithReferenceID(string referenceID, NSDictionary parameters, Action<BCOVPlaylist, NSDictionary, NSError> completionHandler);

        // -(void)findPlaylistWithReferenceID:(NSString *)referenceID authToken:(NSString *)authToken parameters:(NSDictionary *)parameters completion:(void (^)(BCOVPlaylist *, NSDictionary *, NSError *))completionHandler;
        [Export("findPlaylistWithReferenceID:authToken:parameters:completion:")]
        void FindPlaylistWithReferenceID(string referenceID, string authToken, NSDictionary parameters, Action<BCOVPlaylist, NSDictionary, NSError> completionHandler);

        // -(void)findVideoWithVideoID:(NSString *)videoID parameters:(NSDictionary *)parameters completion:(void (^)(BCOVVideo *, NSDictionary *, NSError *))completionHandler;
        [Export("findVideoWithVideoID:parameters:completion:")]
        void FindVideoWithVideoID(string videoID, NSDictionary parameters, Action<BCOVVideo, NSDictionary, NSError> completionHandler);

        // -(void)findVideoWithVideoID:(NSString *)videoID authToken:(NSString *)authToken parameters:(NSDictionary *)parameters completion:(void (^)(BCOVVideo *, NSDictionary *, NSError *))completionHandler;
        [Export("findVideoWithVideoID:authToken:parameters:completion:")]
        void FindVideoWithVideoID(string videoID, string authToken, NSDictionary parameters, Action<BCOVVideo, NSDictionary, NSError> completionHandler);

        // -(void)findVideoWithReferenceID:(NSString *)referenceID parameters:(NSDictionary *)parameters completion:(void (^)(BCOVVideo *, NSDictionary *, NSError *))completionHandler;
        [Export("findVideoWithReferenceID:parameters:completion:")]
        void FindVideoWithReferenceID(string referenceID, NSDictionary parameters, Action<BCOVVideo, NSDictionary, NSError> completionHandler);

        // -(void)findVideoWithReferenceID:(NSString *)referenceID authToken:(NSString *)authToken parameters:(NSDictionary *)parameters completion:(void (^)(BCOVVideo *, NSDictionary *, NSError *))completionHandler;
        [Export("findVideoWithReferenceID:authToken:parameters:completion:")]
        void FindVideoWithReferenceID(string referenceID, string authToken, NSDictionary parameters, Action<BCOVVideo, NSDictionary, NSError> completionHandler);

        // +(BCOVSource *)sourceFromJSONDictionary:(NSDictionary *)json;
        [Static]
        [Export("sourceFromJSONDictionary:")]
        BCOVSource SourceFromJSONDictionary(NSDictionary json);

        // +(BCOVCuePoint *)cuePointFromJSONDictionary:(NSDictionary *)json;
        [Static]
        [Export("cuePointFromJSONDictionary:")]
        BCOVCuePoint CuePointFromJSONDictionary(NSDictionary json);

        // +(BCOVPlaylist *)playlistFromJSONDictionary:(NSDictionary *)json;
        [Static]
        [Export("playlistFromJSONDictionary:")]
        BCOVPlaylist PlaylistFromJSONDictionary(NSDictionary json);

        // +(BCOVVideo *)videoFromJSONDictionary:(NSDictionary *)json;
        [Static]
        [Export("videoFromJSONDictionary:")]
        BCOVVideo VideoFromJSONDictionary(NSDictionary json);
    }

    // @interface BCOVPlaybackServiceRequestFactory : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackServiceRequestFactory
    {
        // @property (readonly, copy, nonatomic) NSString * accountId;
        [Export("accountId")]
        string AccountId { get; }

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

    // @interface BCOVURLSupport (NSDictionary)
    //[Category]
    //[BaseType(typeof(NSObject))]
    [BaseType(typeof(NSDictionary))]
    [Protocol]
    interface NSDictionary_BCOVURLSupport
    {
        // -(NSString *)bcov_UTF8EncodedRequestParameterString;
        [Export("bcov_UTF8EncodedRequestParameterString")]
        //[Verify(MethodToProperty)]
        string Bcov_UTF8EncodedRequestParameterString { get; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const CMImageDescriptionFlavor _Nonnull kCMImageDescriptionFlavor_QuickTimeMovie __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMImageDescriptionFlavor_QuickTimeMovie")]
        //unsafe CMImageDescriptionFlavor* kCMImageDescriptionFlavor_QuickTimeMovie { get; }

        //// extern const CMImageDescriptionFlavor _Nonnull kCMImageDescriptionFlavor_ISOFamily __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMImageDescriptionFlavor_ISOFamily")]
        //unsafe CMImageDescriptionFlavor* kCMImageDescriptionFlavor_ISOFamily { get; }

        //// extern const CMImageDescriptionFlavor _Nonnull kCMImageDescriptionFlavor_3GPFamily __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMImageDescriptionFlavor_3GPFamily")]
        //unsafe CMImageDescriptionFlavor* kCMImageDescriptionFlavor_3GPFamily { get; }

        //// extern const CMSoundDescriptionFlavor _Nonnull kCMSoundDescriptionFlavor_QuickTimeMovie __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMSoundDescriptionFlavor_QuickTimeMovie")]
        //unsafe CMSoundDescriptionFlavor* kCMSoundDescriptionFlavor_QuickTimeMovie { get; }

        //// extern const CMSoundDescriptionFlavor _Nonnull kCMSoundDescriptionFlavor_QuickTimeMovieV2 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMSoundDescriptionFlavor_QuickTimeMovieV2")]
        //unsafe CMSoundDescriptionFlavor* kCMSoundDescriptionFlavor_QuickTimeMovieV2 { get; }

        //// extern const CMSoundDescriptionFlavor _Nonnull kCMSoundDescriptionFlavor_ISOFamily __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMSoundDescriptionFlavor_ISOFamily")]
        //unsafe CMSoundDescriptionFlavor* kCMSoundDescriptionFlavor_ISOFamily { get; }

        //// extern const CMSoundDescriptionFlavor _Nonnull kCMSoundDescriptionFlavor_3GPFamily __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMSoundDescriptionFlavor_3GPFamily")]
        //unsafe CMSoundDescriptionFlavor* kCMSoundDescriptionFlavor_3GPFamily { get; }
    }

    // typedef CMTime (^CMBufferGetTimeHandler)(CMBufferRef _Nonnull);
    //unsafe delegate CMTime CMBufferGetTimeHandler(void* arg0);

    //// typedef Boolean (^CMBufferGetBooleanHandler)(CMBufferRef _Nonnull);
    //unsafe delegate byte CMBufferGetBooleanHandler(void* arg0);

    //// typedef CFComparisonResult (^CMBufferCompareHandler)(CMBufferRef _Nonnull, CMBufferRef _Nonnull);
    //unsafe delegate CFComparisonResult CMBufferCompareHandler(void* arg0, void* arg1);

    //// typedef size_t (^CMBufferGetSizeHandler)(CMBufferRef _Nonnull);
    //unsafe delegate nuint CMBufferGetSizeHandler(void* arg0);

    //// typedef void (^CMBufferQueueTriggerHandler)(CMBufferQueueTriggerToken _Nonnull);
    //unsafe delegate void CMBufferQueueTriggerHandler(CMBufferQueueTriggerToken* arg0);

    //// typedef OSStatus (^CMBufferValidationHandler)(CMBufferQueueRef _Nonnull, CMBufferRef _Nonnull);
    //unsafe delegate int CMBufferValidationHandler(CMBufferQueueRef* arg0, void* arg1);

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern CFStringRef  _Nonnull const kCMMemoryPoolOption_AgeOutPeriod __attribute__((availability(ios, introduced=6.0))) __attribute__((availability(tvos, introduced=6.0)));
        //[TV(6, 0), iOS(6, 0)]
        //[Field("kCMMemoryPoolOption_AgeOutPeriod")]
        //unsafe CFStringRef* kCMMemoryPoolOption_AgeOutPeriod { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_ForegroundColorARGB __attribute__((availability(ios, introduced=6.0))) __attribute__((availability(tvos, introduced=6.0)));
        //[TV(6, 0), iOS(6, 0)]
        //[Field("kCMTextMarkupAttribute_ForegroundColorARGB")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_ForegroundColorARGB { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_BackgroundColorARGB __attribute__((availability(ios, introduced=6.0))) __attribute__((availability(tvos, introduced=6.0)));
        //[TV(6, 0), iOS(6, 0)]
        //[Field("kCMTextMarkupAttribute_BackgroundColorARGB")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_BackgroundColorARGB { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_CharacterBackgroundColorARGB __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAttribute_CharacterBackgroundColorARGB")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_CharacterBackgroundColorARGB { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_BoldStyle __attribute__((availability(ios, introduced=6.0))) __attribute__((availability(tvos, introduced=6.0)));
        //[TV(6, 0), iOS(6, 0)]
        //[Field("kCMTextMarkupAttribute_BoldStyle")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_BoldStyle { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_ItalicStyle __attribute__((availability(ios, introduced=6.0))) __attribute__((availability(tvos, introduced=6.0)));
        //[TV(6, 0), iOS(6, 0)]
        //[Field("kCMTextMarkupAttribute_ItalicStyle")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_ItalicStyle { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_UnderlineStyle __attribute__((availability(ios, introduced=6.0))) __attribute__((availability(tvos, introduced=6.0)));
        //[TV(6, 0), iOS(6, 0)]
        //[Field("kCMTextMarkupAttribute_UnderlineStyle")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_UnderlineStyle { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_FontFamilyName __attribute__((availability(ios, introduced=6.0))) __attribute__((availability(tvos, introduced=6.0)));
        //[TV(6, 0), iOS(6, 0)]
        //[Field("kCMTextMarkupAttribute_FontFamilyName")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_FontFamilyName { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_GenericFontFamilyName __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAttribute_GenericFontFamilyName")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_GenericFontFamilyName { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_Default __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_Default")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_Default { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_Serif __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_Serif")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_Serif { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_SansSerif __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_SansSerif")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_SansSerif { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_Monospace __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_Monospace")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_Monospace { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_ProportionalSerif __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_ProportionalSerif")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_ProportionalSerif { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_ProportionalSansSerif __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_ProportionalSansSerif")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_ProportionalSansSerif { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_MonospaceSerif __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_MonospaceSerif")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_MonospaceSerif { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_MonospaceSansSerif __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_MonospaceSansSerif")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_MonospaceSansSerif { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_Casual __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_Casual")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_Casual { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_Cursive __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_Cursive")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_Cursive { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_Fantasy __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_Fantasy")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_Fantasy { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupGenericFontName_SmallCapital __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupGenericFontName_SmallCapital")]
        //unsafe CFStringRef* kCMTextMarkupGenericFontName_SmallCapital { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_BaseFontSizePercentageRelativeToVideoHeight __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAttribute_BaseFontSizePercentageRelativeToVideoHeight")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_BaseFontSizePercentageRelativeToVideoHeight { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_RelativeFontSize __attribute__((availability(ios, introduced=6.0))) __attribute__((availability(tvos, introduced=6.0)));
        //[TV(6, 0), iOS(6, 0)]
        //[Field("kCMTextMarkupAttribute_RelativeFontSize")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_RelativeFontSize { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_VerticalLayout __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAttribute_VerticalLayout")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_VerticalLayout { get; }

        //// extern const CFStringRef _Nonnull kCMTextVerticalLayout_LeftToRight __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextVerticalLayout_LeftToRight")]
        //unsafe CFStringRef* kCMTextVerticalLayout_LeftToRight { get; }

        //// extern const CFStringRef _Nonnull kCMTextVerticalLayout_RightToLeft __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextVerticalLayout_RightToLeft")]
        //unsafe CFStringRef* kCMTextVerticalLayout_RightToLeft { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_Alignment __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAttribute_Alignment")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_Alignment { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAlignmentType_Start __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAlignmentType_Start")]
        //unsafe CFStringRef* kCMTextMarkupAlignmentType_Start { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAlignmentType_Middle __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAlignmentType_Middle")]
        //unsafe CFStringRef* kCMTextMarkupAlignmentType_Middle { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAlignmentType_End __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAlignmentType_End")]
        //unsafe CFStringRef* kCMTextMarkupAlignmentType_End { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAlignmentType_Left __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAlignmentType_Left")]
        //unsafe CFStringRef* kCMTextMarkupAlignmentType_Left { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAlignmentType_Right __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAlignmentType_Right")]
        //unsafe CFStringRef* kCMTextMarkupAlignmentType_Right { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_TextPositionPercentageRelativeToWritingDirection __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAttribute_TextPositionPercentageRelativeToWritingDirection")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_TextPositionPercentageRelativeToWritingDirection { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_OrthogonalLinePositionPercentageRelativeToWritingDirection __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAttribute_OrthogonalLinePositionPercentageRelativeToWritingDirection")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_OrthogonalLinePositionPercentageRelativeToWritingDirection { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_WritingDirectionSizePercentage __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAttribute_WritingDirectionSizePercentage")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_WritingDirectionSizePercentage { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupAttribute_CharacterEdgeStyle __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupAttribute_CharacterEdgeStyle")]
        //unsafe CFStringRef* kCMTextMarkupAttribute_CharacterEdgeStyle { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupCharacterEdgeStyle_None __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupCharacterEdgeStyle_None")]
        //unsafe CFStringRef* kCMTextMarkupCharacterEdgeStyle_None { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupCharacterEdgeStyle_Raised __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupCharacterEdgeStyle_Raised")]
        //unsafe CFStringRef* kCMTextMarkupCharacterEdgeStyle_Raised { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupCharacterEdgeStyle_Depressed __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupCharacterEdgeStyle_Depressed")]
        //unsafe CFStringRef* kCMTextMarkupCharacterEdgeStyle_Depressed { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupCharacterEdgeStyle_Uniform __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupCharacterEdgeStyle_Uniform")]
        //unsafe CFStringRef* kCMTextMarkupCharacterEdgeStyle_Uniform { get; }

        //// extern const CFStringRef _Nonnull kCMTextMarkupCharacterEdgeStyle_DropShadow __attribute__((availability(ios, introduced=7.0))) __attribute__((availability(tvos, introduced=7.0)));
        //[TV(7, 0), iOS(7, 0)]
        //[Field("kCMTextMarkupCharacterEdgeStyle_DropShadow")]
        //unsafe CFStringRef* kCMTextMarkupCharacterEdgeStyle_DropShadow { get; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const CFStringRef _Nonnull kCMMetadataKeySpace_QuickTimeUserData __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataKeySpace_QuickTimeUserData")]
        //unsafe CFStringRef* kCMMetadataKeySpace_QuickTimeUserData { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataKeySpace_ISOUserData __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataKeySpace_ISOUserData")]
        //unsafe CFStringRef* kCMMetadataKeySpace_ISOUserData { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataKeySpace_QuickTimeMetadata __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataKeySpace_QuickTimeMetadata")]
        //unsafe CFStringRef* kCMMetadataKeySpace_QuickTimeMetadata { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataKeySpace_iTunes __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataKeySpace_iTunes")]
        //unsafe CFStringRef* kCMMetadataKeySpace_iTunes { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataKeySpace_ID3 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataKeySpace_ID3")]
        //unsafe CFStringRef* kCMMetadataKeySpace_ID3 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataKeySpace_Icy __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataKeySpace_Icy")]
        //unsafe CFStringRef* kCMMetadataKeySpace_Icy { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataKeySpace_HLSDateRange __attribute__((availability(ios, introduced=9.3))) __attribute__((availability(tvos, introduced=9.3)));
        //[TV(9, 3), iOS(9, 3)]
        //[Field("kCMMetadataKeySpace_HLSDateRange")]
        //unsafe CFStringRef* kCMMetadataKeySpace_HLSDateRange { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataIdentifier_QuickTimeMetadataLocation_ISO6709 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataIdentifier_QuickTimeMetadataLocation_ISO6709")]
        //unsafe CFStringRef* kCMMetadataIdentifier_QuickTimeMetadataLocation_ISO6709 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataIdentifier_QuickTimeMetadataDirection_Facing __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataIdentifier_QuickTimeMetadataDirection_Facing")]
        //unsafe CFStringRef* kCMMetadataIdentifier_QuickTimeMetadataDirection_Facing { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataIdentifier_QuickTimeMetadataPreferredAffineTransform __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataIdentifier_QuickTimeMetadataPreferredAffineTransform")]
        //unsafe CFStringRef* kCMMetadataIdentifier_QuickTimeMetadataPreferredAffineTransform { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataIdentifier_QuickTimeMetadataVideoOrientation __attribute__((availability(ios, introduced=9.0))) __attribute__((availability(tvos, introduced=9.0)));
        //[TV(9, 0), iOS(9, 0)]
        //[Field("kCMMetadataIdentifier_QuickTimeMetadataVideoOrientation")]
        //unsafe CFStringRef* kCMMetadataIdentifier_QuickTimeMetadataVideoOrientation { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_RawData __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_RawData")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_RawData { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_UTF8 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_UTF8")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_UTF8 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_UTF16 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_UTF16")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_UTF16 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_GIF __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_GIF")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_GIF { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_JPEG __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_JPEG")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_JPEG { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_PNG __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_PNG")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_PNG { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_BMP __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_BMP")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_BMP { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_Float32 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_Float32")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_Float32 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_Float64 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_Float64")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_Float64 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_SInt8 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_SInt8")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_SInt8 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_SInt16 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_SInt16")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_SInt16 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_SInt32 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_SInt32")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_SInt32 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_SInt64 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_SInt64")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_SInt64 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_UInt8 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_UInt8")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_UInt8 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_UInt16 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_UInt16")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_UInt16 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_UInt32 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_UInt32")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_UInt32 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_UInt64 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_UInt64")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_UInt64 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_PointF32 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_PointF32")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_PointF32 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_DimensionsF32 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_DimensionsF32")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_DimensionsF32 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_RectF32 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_RectF32")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_RectF32 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_AffineTransformF64 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataBaseDataType_AffineTransformF64")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_AffineTransformF64 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_PolygonF32 __attribute__((availability(ios, introduced=9.0))) __attribute__((availability(tvos, introduced=9.0)));
        //[TV(9, 0), iOS(9, 0)]
        //[Field("kCMMetadataBaseDataType_PolygonF32")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_PolygonF32 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_PolylineF32 __attribute__((availability(ios, introduced=9.0))) __attribute__((availability(tvos, introduced=9.0)));
        //[TV(9, 0), iOS(9, 0)]
        //[Field("kCMMetadataBaseDataType_PolylineF32")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_PolylineF32 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataBaseDataType_JSON __attribute__((availability(ios, introduced=9.0))) __attribute__((availability(tvos, introduced=9.0)));
        //[TV(9, 0), iOS(9, 0)]
        //[Field("kCMMetadataBaseDataType_JSON")]
        //unsafe CFStringRef* kCMMetadataBaseDataType_JSON { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataDataType_QuickTimeMetadataLocation_ISO6709 __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataDataType_QuickTimeMetadataLocation_ISO6709")]
        //unsafe CFStringRef* kCMMetadataDataType_QuickTimeMetadataLocation_ISO6709 { get; }

        //// extern const CFStringRef _Nonnull kCMMetadataDataType_QuickTimeMetadataDirection __attribute__((availability(ios, introduced=8.0))) __attribute__((availability(tvos, introduced=8.0)));
        //[TV(8, 0)]
        //[Field("kCMMetadataDataType_QuickTimeMetadataDirection")]
        //unsafe CFStringRef* kCMMetadataDataType_QuickTimeMetadataDirection { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventWillPauseForAd;
        //[Field("kBCOVPlaybackSessionLifecycleEventWillPauseForAd")]
        //NSString kBCOVPlaybackSessionLifecycleEventWillPauseForAd { get; }
    }

    // @interface BCOVAdSequence : NSObject
    [BaseType(typeof(NSObject))]
    [Protocol]
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
        //[Verify(StronglyTypedNSArray)]
        NSObject[] Ads { get; }

        // @property (readonly, copy, nonatomic) NSDictionary * properties;
        [Export("properties", ArgumentSemantic.Copy)]
        NSDictionary Properties { get; }

        // -(instancetype)initWithAds:(NSArray *)ads properties:(NSDictionary *)properties;
        [Export("initWithAds:properties:")]
        //[Verify(StronglyTypedNSArray)]
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
        void PlaybackSessiondidPauseAd(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVAd ad);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didResumeAd:(BCOVAd *)ad;
        [Export("playbackController:playbackSession:didResumeAd:")]
        void PlaybackSessiondidResumeAd(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVAd ad);
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

    // @interface Unavailable (BCOVAdSequence)
    //[Category]
    //[BaseType(typeof(BCOVAdSequence))]
    [BaseType(typeof(NSObject))]
    [Protocol]
    [DisableDefaultCtor]
    interface BCOVAdSequence_Unavailable : BCOVAdSequence
    {
    }

    // @interface Unavailable (BCOVAd)
    //[Category]
    //[BaseType(typeof(BCOVAd))]
    [BaseType(typeof(NSObject))]
    [Protocol]
    [DisableDefaultCtor]
    interface BCOVAd_Unavailable : BCOVAd
    {
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const CGFloat kBCOVVideo360BaseAngleOfView;
        //[Field("kBCOVVideo360BaseAngleOfView")]
        //nfloat kBCOVVideo360BaseAngleOfView { get; }
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

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        //// extern NSString *const kBCOVBufferOptimizerMethodKey;
        //[Field("kBCOVBufferOptimizerMethodKey")]
        //NSString kBCOVBufferOptimizerMethodKey { get; }

        //// extern NSString *const kBCOVBufferOptimizerMinimumDurationKey;
        //[Field("kBCOVBufferOptimizerMinimumDurationKey")]
        //NSString kBCOVBufferOptimizerMinimumDurationKey { get; }

        //// extern NSString *const kBCOVBufferOptimizerMaximumDurationKey;
        //[Field("kBCOVBufferOptimizerMaximumDurationKey")]
        //NSString kBCOVBufferOptimizerMaximumDurationKey { get; }

        //// extern NSString *const kBCOVAVPlayerViewControllerCompatibilityKey;
        //[Field("kBCOVAVPlayerViewControllerCompatibilityKey")]
        //NSString kBCOVAVPlayerViewControllerCompatibilityKey { get; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const kBCOVDefaultFairPlayApplicationCertificateIdentifier;
        //[Field("kBCOVDefaultFairPlayApplicationCertificateIdentifier")]
        //NSString kBCOVDefaultFairPlayApplicationCertificateIdentifier { get; }
    }

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
        //[Wrap("WeakDelegate"), Abstract]
        //BCOVPlaybackControllerDelegate Delegate { get; set; }

        [Wrap("WeakDelegate")]
        BCOVPlaybackControllerDelegate Delegate { get; set; }

        // @required @property (assign, nonatomic) id<BCOVPlaybackControllerDelegate> delegate;
        //[Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @required @property (getter = isAutoAdvance, assign, nonatomic) BOOL autoAdvance;
        //[Abstract]
        [Export("autoAdvance")]
        bool AutoAdvance { [Bind("isAutoAdvance")] get; set; }

        // @required @property (getter = isAutoPlay, assign, nonatomic) BOOL autoPlay;
        //[Abstract]
        [Export("autoPlay")]
        bool AutoPlay { [Bind("isAutoPlay")] get; set; }

        // @required @property (readonly, nonatomic, strong) UIView * view;
        //[Abstract]
        [Export("view", ArgumentSemantic.Strong)]
        UIView View { get; }

        // @required @property (readwrite, copy, nonatomic) NSDictionary * options;
        //[Abstract]
        [Export("options", ArgumentSemantic.Copy)]
        NSDictionary Options { get; set; }

        // @required @property (readonly, copy, nonatomic) id<BCOVMutableAnalytics> analytics;
        //[Abstract]
        [Export("analytics", ArgumentSemantic.Copy)]
        BCOVMutableAnalytics Analytics { get; }

        // @required @property (readwrite, nonatomic) BOOL adsDisabled;
        //[Abstract]
        [Export("adsDisabled")]
        bool AdsDisabled { get; set; }

        // @required @property (readwrite, nonatomic) BOOL allowsBackgroundAudioPlayback;
        //[Abstract]
        [Export("allowsBackgroundAudioPlayback")]
        bool AllowsBackgroundAudioPlayback { get; set; }

        // @required @property (readwrite, nonatomic) BOOL allowsExternalPlayback;
        //[Abstract]
        [Export("allowsExternalPlayback")]
        bool AllowsExternalPlayback { get; set; }

        // @required @property (readwrite, nonatomic) BOOL usesExternalPlaybackWhileExternalScreenIsActive;
        //[Abstract]
        [Export("usesExternalPlaybackWhileExternalScreenIsActive")]
        bool UsesExternalPlaybackWhileExternalScreenIsActive { get; set; }

        // @required @property (getter = isPictureInPictureActive, assign, readwrite, nonatomic) BOOL pictureInPictureActive;
        //[Abstract]
        [Export("pictureInPictureActive")]
        bool PictureInPictureActive { [Bind("isPictureInPictureActive")] get; set; }

        // @required @property (readwrite, nonatomic) BOOL shutter;
        //[Abstract]
        [Export("shutter")]
        bool Shutter { get; set; }

        // @required @property (readwrite, nonatomic) NSTimeInterval shutterFadeTime;
        //[Abstract]
        [Export("shutterFadeTime")]
        double ShutterFadeTime { get; set; }

        // @required @property (readwrite, copy, nonatomic) BCOVVideo360ViewProjection * viewProjection;
        //[Abstract]
        [Export("viewProjection", ArgumentSemantic.Copy)]
        BCOVVideo360ViewProjection ViewProjection { get; set; }

        // @required -(void)addSessionConsumer:(id<BCOVPlaybackSessionConsumer>)consumer;
        //[Abstract]
        [Export("addSessionConsumer:")]
        void AddSessionConsumer(BCOVPlaybackSessionConsumer consumer);

        // @required -(void)removeSessionConsumer:(id<BCOVPlaybackSessionConsumer>)consumer;
        //[Abstract]
        [Export("removeSessionConsumer:")]
        void RemoveSessionConsumer(BCOVPlaybackSessionConsumer consumer);

        // @required -(void)advanceToNext;
        //[Abstract]
        [Export("advanceToNext")]
        void AdvanceToNext();

        // @required -(void)play;
        //[Abstract]
        [Export("play")]
        void Play();

        // @required -(void)pause;
        //[Abstract]
        [Export("pause")]
        void Pause();

        // @required -(void)seekToTime:(CMTime)time completionHandler:(void (^)(BOOL))completionHandler;
        //[Abstract]
        [Export("seekToTime:completionHandler:")]
        void SeekToTime(CMTime time, Action<bool> completionHandler);

        // @required -(void)seekToTime:(CMTime)time toleranceBefore:(CMTime)toleranceBefore toleranceAfter:(CMTime)toleranceAfter completionHandler:(void (^)(BOOL))completionHandler;
        //[Abstract]
        [Export("seekToTime:toleranceBefore:toleranceAfter:completionHandler:")]
        void SeekToTime(CMTime time, CMTime toleranceBefore, CMTime toleranceAfter, Action<bool> completionHandler);

        // @required -(void)seekWithoutAds:(CMTime)time completionHandler:(void (^)(BOOL))completionHandler;
        //[Abstract]
        [Export("seekWithoutAds:completionHandler:")]
        void SeekWithoutAds(CMTime time, Action<bool> completionHandler);

        // @required -(void)resumeVideoAtTime:(CMTime)time withAutoPlay:(BOOL)autoPlay;
        //[Abstract]
        [Export("resumeVideoAtTime:withAutoPlay:")]
        void ResumeVideoAtTime(CMTime time, bool autoPlay);

        // @required -(void)setVideos:(id<NSFastEnumeration>)videos;
        //[Abstract]
        [Export("setVideos:")]
        //Hack
        void SetVideos(NSArray videos);

        // @required -(void)resumeAd;
        //[Abstract]
        [Export("resumeAd")]
        void ResumeAd();

        // @required -(void)pauseAd;
        //[Abstract]
        [Export("pauseAd")]
        void PauseAd();

        // @required -(void)addFairPlayApplicationCertificate:(NSData *)applicationCertificateData identifier:(NSString *)identifier;
        //[Abstract]
        [Export("addFairPlayApplicationCertificate:identifier:")]
        void AddFairPlayApplicationCertificate(NSData applicationCertificateData, string identifier);
    }

    // @protocol BCOVPlaybackSessionConsumer <BCOVPlaybackSessionBasicConsumer, BCOVPlaybackSessionAdsConsumer>
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
    interface BCOVPlaybackSessionConsumer : IBCOVPlaybackSessionBasicConsumer, IBCOVPlaybackSessionAdsConsumer
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
    interface IBCOVPlaybackSessionBasicConsumer
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
        //Hack
        void DidCompletePlaylist(NSArray playlist);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didReceiveLifecycleEvent:(BCOVPlaybackSessionLifecycleEvent *)lifecycleEvent;
        [Export("playbackSession:didReceiveLifecycleEvent:")]
        void PlaybackSession(BCOVPlaybackSession session, BCOVPlaybackSessionLifecycleEvent lifecycleEvent);

        // @optional -(void)playbackSession:(id<BCOVPlaybackSession>)session didChangeSeekableRanges:(NSArray *)seekableRanges;
        [Export("playbackSession:didChangeSeekableRanges:")]
        //[Verify(StronglyTypedNSArray)]
        void PlaybackSession(BCOVPlaybackSession session, NSObject[] seekableRanges);
    }

    // @protocol BCOVPlaybackControllerDelegate <BCOVPlaybackControllerBasicDelegate, BCOVPlaybackControllerAdsDelegate>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BCOVPlaybackControllerDelegate : IBCOVPlaybackControllerBasicDelegate, IBCOVPlaybackControllerAdsDelegate
    {
    }

    // @protocol BCOVPlaybackControllerBasicDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface IBCOVPlaybackControllerBasicDelegate
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
        //Hack
        void DidCompletePlaylist(BCOVPlaybackController controller, NSObject playlist);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didReceiveLifecycleEvent:(BCOVPlaybackSessionLifecycleEvent *)lifecycleEvent;
        [Export("playbackController:playbackSession:didReceiveLifecycleEvent:")]
        void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVPlaybackSessionLifecycleEvent lifecycleEvent);

        // @optional -(void)playbackController:(id<BCOVPlaybackController>)controller playbackSession:(id<BCOVPlaybackSession>)session didChangeSeekableRanges:(NSArray *)seekableRanges;
        [Export("playbackController:playbackSession:didChangeSeekableRanges:")]
        //[Verify(StronglyTypedNSArray)]
        void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, NSObject[] seekableRanges);
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

    // @interface BCOVPlayerSDKManager : NSObject
    [BaseType(typeof(NSObject))]
    [Protocol]
    interface BCOVPlayerSDKManager : BCOVPlayerSDKManager_BCOVFPSAdditions, BCOVPlayerSDKManager_BCOVSSAdditions
    {
        // +(NSString *)version;
        [Static]
        [Export("version")]
        //[Verify(MethodToProperty)]
        string Version { get; }

        // @property (readonly, nonatomic, strong) NSString * sessionID;
        [Export("sessionID", ArgumentSemantic.Strong)]
        string SessionID { get; }

        // -(id<BCOVPlaybackController>)createPlaybackController;
        [Export("createPlaybackController")]
        //[Verify(MethodToProperty)]
        BCOVPlaybackController CreatePlaybackController();

        // -(id<BCOVPlaybackController>)createPlaybackControllerWithViewStrategy:(BCOVPlaybackControllerViewStrategy)viewStrategy;
        [Export("createPlaybackControllerWithViewStrategy:")]
        BCOVPlaybackController CreatePlaybackControllerWithViewStrategy(BCOVPlaybackControllerViewStrategy viewStrategy);

        // -(id<BCOVPlaybackController>)createPlaybackControllerWithSessionProvider:(id<BCOVPlaybackSessionProvider>)provider viewStrategy:(BCOVPlaybackControllerViewStrategy)viewStrategy;
        [Export("createPlaybackControllerWithSessionProvider:viewStrategy:")]
        BCOVPlaybackController CreatePlaybackControllerWithSessionProvider(BCOVPlaybackSessionProvider provider, BCOVPlaybackControllerViewStrategy viewStrategy);

        // -(id<BCOVPlaybackSessionProvider>)createBasicSessionProviderWithOptions:(BCOVBasicSessionProviderOptions *)options;
        [Export("createBasicSessionProviderWithOptions:")]
        BCOVPlaybackSessionProvider CreateBasicSessionProviderWithOptions(BCOVBasicSessionProviderOptions options);

        // -(void)registerComponent:(id<BCOVComponent>)component;
        [Export("registerComponent:")]
        void RegisterComponent(BCOVComponent component);

        // +(BCOVPlayerSDKManager *)sharedManager;
        [Static]
        [Export("sharedManager")]
        //[Verify(MethodToProperty)]
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
    [Protocol]
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
    [Protocol]
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
        // @required -(id)playbackSessionsForVideos:(id<NSFastEnumeration>)videos __attribute__((deprecated("Do not use")));
        //[Abstract]
        //[Export("playbackSessionsForVideos:")]
        ////Hack
        //NSObject PlaybackSessionsForVideos(NSArray videos);
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
        //[Verify(MethodToProperty)]
        BCOVBasicSessionProviderSourceSelectionPolicy SourceSelectionHLS { get; }
    }

    // @interface BCOVBasicSessionLoadingPolicy : NSObject <NSCopying>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface BCOVBasicSessionLoadingPolicy : INSCopying
    {
        // +(instancetype)sessionPreloadingNever;
        [Static]
        [Export("sessionPreloadingNever")]
        BCOVBasicSessionLoadingPolicy SessionPreloadingNever();

        // +(instancetype)sessionPreloadingWithProgressPercentage:(NSUInteger)progressPercentage;
        [Static]
        [Export("sessionPreloadingWithProgressPercentage:")]
        BCOVBasicSessionLoadingPolicy SessionPreloadingWithProgressPercentage(nuint progressPercentage);
    }

    // @interface Unavailable (BCOVBasicSessionLoadingPolicy)
    //[Category]
    //[BaseType(typeof(BCOVBasicSessionLoadingPolicy))]
    [BaseType(typeof(NSObject))]
    [Protocol]
    [DisableDefaultCtor]
    interface BCOVBasicSessionLoadingPolicy_Unavailable : BCOVBasicSessionLoadingPolicy
    {
    }

    // @interface BCOVBasicSessionProviderOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVBasicSessionProviderOptions
    {
        // @property (copy, nonatomic) BCOVSource * (^sourceSelectionPolicy)(BCOVVideo *);
        [Export("sourceSelectionPolicy", ArgumentSemantic.Copy)]
        Func<BCOVVideo, BCOVSource> SourceSelectionPolicy { get; set; }

        // @property (copy, nonatomic) BCOVBasicSessionLoadingPolicy * sessionPreloadingPolicy __attribute__((deprecated("Refer to the PreloadingVideos section of the README for guidance on using multiple playback controllers to achieve a preloading effect.")));
        [Export("sessionPreloadingPolicy", ArgumentSemantic.Copy)]
        BCOVBasicSessionLoadingPolicy SessionPreloadingPolicy { get; set; }
    }

    // @interface BCOVCuePointProgressPolicy : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVCuePointProgressPolicy
    {
        // -(BCOVCuePointProgressPolicyResult *)applyToEvent:(NSDictionary *)cuePointEvent;
        [Export("applyToEvent:")]
        BCOVCuePointProgressPolicyResult ApplyToEvent(NSDictionary cuePointEvent);

        // +(instancetype)progressPolicyProcessingCuePoints:(BCOVProgressPolicyCuePointsToProcess)cuePointsToProcess resumingPlaybackFrom:(BCOVProgressPolicyResumePosition)resumePosition ignoringPreviouslyProcessedCuePoints:(BOOL)ignorePrevious;
        [Static]
        [Export("progressPolicyProcessingCuePoints:resumingPlaybackFrom:ignoringPreviouslyProcessedCuePoints:")]
        BCOVCuePointProgressPolicy ProgressPolicyProcessingCuePoints(BCOVPlaybackSessionProvider cuePointsToProcess, BCOVProgressPolicyResumePosition resumePosition, bool ignorePrevious);
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

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventReady;
        //[Field("kBCOVPlaybackSessionLifecycleEventReady")]
        //NSString kBCOVPlaybackSessionLifecycleEventReady { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventFail;
        //[Field("kBCOVPlaybackSessionLifecycleEventFail")]
        //NSString kBCOVPlaybackSessionLifecycleEventFail { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlay;
        //[Field("kBCOVPlaybackSessionLifecycleEventPlay")]
        //NSString kBCOVPlaybackSessionLifecycleEventPlay { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventPause;
        //[Field("kBCOVPlaybackSessionLifecycleEventPause")]
        //NSString kBCOVPlaybackSessionLifecycleEventPause { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventFailedToPlayToEndTime;
        //[Field("kBCOVPlaybackSessionLifecycleEventFailedToPlayToEndTime")]
        //NSString kBCOVPlaybackSessionLifecycleEventFailedToPlayToEndTime { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventResumeBegin;
        //[Field("kBCOVPlaybackSessionLifecycleEventResumeBegin")]
        //NSString kBCOVPlaybackSessionLifecycleEventResumeBegin { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventResumeComplete;
        //[Field("kBCOVPlaybackSessionLifecycleEventResumeComplete")]
        //NSString kBCOVPlaybackSessionLifecycleEventResumeComplete { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventResumeFail;
        //[Field("kBCOVPlaybackSessionLifecycleEventResumeFail")]
        //NSString kBCOVPlaybackSessionLifecycleEventResumeFail { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventEnd;
        //[Field("kBCOVPlaybackSessionLifecycleEventEnd")]
        //NSString kBCOVPlaybackSessionLifecycleEventEnd { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlaybackStalled;
        //[Field("kBCOVPlaybackSessionLifecycleEventPlaybackStalled")]
        //NSString kBCOVPlaybackSessionLifecycleEventPlaybackStalled { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlaybackRecovered;
        //[Field("kBCOVPlaybackSessionLifecycleEventPlaybackRecovered")]
        //NSString kBCOVPlaybackSessionLifecycleEventPlaybackRecovered { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlaybackBufferEmpty;
        //[Field("kBCOVPlaybackSessionLifecycleEventPlaybackBufferEmpty")]
        //NSString kBCOVPlaybackSessionLifecycleEventPlaybackBufferEmpty { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventPlaybackLikelyToKeepUp;
        //[Field("kBCOVPlaybackSessionLifecycleEventPlaybackLikelyToKeepUp")]
        //NSString kBCOVPlaybackSessionLifecycleEventPlaybackLikelyToKeepUp { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventTerminate;
        //[Field("kBCOVPlaybackSessionLifecycleEventTerminate")]
        //NSString kBCOVPlaybackSessionLifecycleEventTerminate { get; }

        //// extern NSString *const kBCOVPlaybackSessionLifecycleEventError;
        //[Field("kBCOVPlaybackSessionLifecycleEventError")]
        //NSString kBCOVPlaybackSessionLifecycleEventError { get; }

        //// extern NSString *const kBCOVPlaybackSessionEventKeyError;
        //[Field("kBCOVPlaybackSessionEventKeyError")]
        //NSString kBCOVPlaybackSessionEventKeyError { get; }

        //// extern NSString *const kBCOVPlaybackSessionEventKeyPreviousTime;
        //[Field("kBCOVPlaybackSessionEventKeyPreviousTime")]
        //NSString kBCOVPlaybackSessionEventKeyPreviousTime { get; }

        //// extern NSString *const kBCOVPlaybackSessionEventKeyCurrentTime;
        //[Field("kBCOVPlaybackSessionEventKeyCurrentTime")]
        //NSString kBCOVPlaybackSessionEventKeyCurrentTime { get; }

        //// extern NSString *const kBCOVPlaybackSessionEventKeyCuePoints;
        //[Field("kBCOVPlaybackSessionEventKeyCuePoints")]
        //NSString kBCOVPlaybackSessionEventKeyCuePoints { get; }

        //// extern NSString *const kBCOVPlaybackSessionErrorDomain;
        //[Field("kBCOVPlaybackSessionErrorDomain")]
        //NSString kBCOVPlaybackSessionErrorDomain { get; }

        //// extern const NSInteger kBCOVPlaybackSessionErrorCodeLoadFailed;
        //[Field("kBCOVPlaybackSessionErrorCodeLoadFailed")]
        //nint kBCOVPlaybackSessionErrorCodeLoadFailed { get; }

        //// extern const NSInteger kBCOVPlaybackSessionErrorCodeFailedToPlayToEnd;
        //[Field("kBCOVPlaybackSessionErrorCodeFailedToPlayToEnd")]
        //nint kBCOVPlaybackSessionErrorCodeFailedToPlayToEnd { get; }

        //// extern const NSInteger kBCOVPlaybackSessionErrorCodeNoPlayableSource;
        //[Field("kBCOVPlaybackSessionErrorCodeNoPlayableSource")]
        //nint kBCOVPlaybackSessionErrorCodeNoPlayableSource { get; }
    }

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
        //[Abstract]
        [Export("video", ArgumentSemantic.Copy)]
        BCOVVideo Video { get; }

        // @required @property (readonly, copy, nonatomic) BCOVSource * source;
        //[Abstract]
        [Export("source", ArgumentSemantic.Copy)]
        BCOVSource Source { get; }

        // @required @property (readonly, nonatomic, strong) AVPlayer * player;
        //[Abstract]
        [Export("player", ArgumentSemantic.Strong)]
        AVPlayer Player { get; }

        // @required @property (readonly, nonatomic, strong) AVPlayerLayer * playerLayer;
        //[Abstract]
        [Export("playerLayer", ArgumentSemantic.Strong)]
        AVPlayerLayer PlayerLayer { get; }

        // @required @property (readonly, nonatomic) AVMediaSelectionGroup * audibleMediaSelectionGroup;
        //[Abstract]
        [Export("audibleMediaSelectionGroup")]
        AVMediaSelectionGroup AudibleMediaSelectionGroup { get; }

        // @required @property (readwrite, nonatomic) AVMediaSelectionOption * selectedAudibleMediaOption;
        //[Abstract]
        [Export("selectedAudibleMediaOption", ArgumentSemantic.Assign)]
        AVMediaSelectionOption SelectedAudibleMediaOption { get; set; }

        // @required @property (readonly, nonatomic) AVMediaSelectionGroup * legibleMediaSelectionGroup;
        //[Abstract]
        [Export("legibleMediaSelectionGroup")]
        AVMediaSelectionGroup LegibleMediaSelectionGroup { get; }

        // @required @property (readwrite, nonatomic) AVMediaSelectionOption * selectedLegibleMediaOption;
        //[Abstract]
        [Export("selectedLegibleMediaOption", ArgumentSemantic.Assign)]
        AVMediaSelectionOption SelectedLegibleMediaOption { get; set; }

        // @required @property (readonly, nonatomic, strong) BCOVSessionProviderExtension * providerExtension;
        //[Abstract]
        [Export("providerExtension", ArgumentSemantic.Strong)]
        BCOVSessionProviderExtension ProviderExtension { get; }

        // @required -(void)selectAudibleMediaOptionAutomatically;
        //[Abstract]
        [Export("selectAudibleMediaOptionAutomatically")]
        void SelectAudibleMediaOptionAutomatically();

        // @required -(void)selectLegibleMediaOptionAutomatically;
        //[Abstract]
        [Export("selectLegibleMediaOptionAutomatically")]
        void SelectLegibleMediaOptionAutomatically();

        // @required -(NSString *)displayNameFromAudibleMediaSelectionOption:(AVMediaSelectionOption *)option;
        //[Abstract]
        [Export("displayNameFromAudibleMediaSelectionOption:")]
        string DisplayNameFromAudibleMediaSelectionOption(AVMediaSelectionOption option);

        // @required -(NSString *)displayNameFromLegibleMediaSelectionOption:(AVMediaSelectionOption *)option;
        //[Abstract]
        [Export("displayNameFromLegibleMediaSelectionOption:")]
        string DisplayNameFromLegibleMediaSelectionOption(AVMediaSelectionOption option);

        // @required -(void)terminate;
        //[Abstract]
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

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull kBCOVFPSErrorDomain;
        [Field("kBCOVFPSErrorDomain")]
        NSString kBCOVFPSErrorDomain { get; }

        // extern const NSInteger kBCOVFPSErrorCodeStreamingContentKeyRequest;
        [Field("kBCOVFPSErrorCodeStreamingContentKeyRequest")]
        nint kBCOVFPSErrorCodeStreamingContentKeyRequest { get; }

        // extern const NSInteger kBCOVFPSErrorCodeApplicationCertificateRequest;
        [Field("kBCOVFPSErrorCodeApplicationCertificateRequest")]
        nint kBCOVFPSErrorCodeApplicationCertificateRequest { get; }
    }

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

        // @required -(void)encryptedContentKeyForLoadingRequest:(AVAssetResourceLoadingRequest * _Nonnull)loadingRequest contentKeyRequest:(NSData * _Nonnull)keyRequest source:(BCOVSource * _Nonnull)source completionHandler:(void (^ _Nonnull)(NSURLResponse * _Nullable, NSData * _Nullable, NSError * _Nullable))completionHandler;
        //[Abstract]
        [Export("encryptedContentKeyForLoadingRequest:contentKeyRequest:source:completionHandler:")]
        void EncryptedContentKeyForLoadingRequest(AVAssetResourceLoadingRequest loadingRequest, NSData keyRequest, BCOVSource source, Action<NSUrlResponse, NSData, NSError> completionHandler);

        // @optional -(void)encryptedContentKeyForContentKeyIdentifier:(NSString * _Nonnull)contentKeyIdentifier contentKeyRequest:(NSData * _Nonnull)keyRequest source:(BCOVSource * _Nonnull)source options:(NSDictionary * _Nullable)options completionHandler:(void (^ _Nonnull)(NSURLResponse * _Nullable, NSData * _Nullable, NSError * _Nullable))completionHandler;
        [Export("encryptedContentKeyForContentKeyIdentifier:contentKeyRequest:source:options:completionHandler:")]
        void EncryptedContentKeyForContentKeyIdentifier(string contentKeyIdentifier, NSData keyRequest, BCOVSource source, [NullAllowed] NSDictionary options, Action<NSUrlResponse, NSData, NSError> completionHandler);
    }

    //Hack: FPS Fix
    interface IBCOVFPSAuthorizationProxy { }

    // @interface BCOVFPSAdditions (BCOVPlayerSDKManager)
    //[Category]
    //[BaseType(typeof(BCOVPlayerSDKManager))]
    //[Protocol]
    //[BaseType(typeof(NSObject))]
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

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        //// extern NSString *const _Nonnull kBCOVSourceKeySystemFairPlayV1;
        //[Field("kBCOVSourceKeySystemFairPlayV1")]
        //NSString kBCOVSourceKeySystemFairPlayV1 { get; }

        //// extern NSString *const _Nonnull kBCOVSourceKeySystemFairPlayKeyRequestURLKey;
        //[Field("kBCOVSourceKeySystemFairPlayKeyRequestURLKey")]
        //NSString kBCOVSourceKeySystemFairPlayKeyRequestURLKey { get; }

        //// extern NSString *const _Nonnull kBCOVFPSAuthProxyErrorDomain;
        //[Field("kBCOVFPSAuthProxyErrorDomain")]
        //NSString kBCOVFPSAuthProxyErrorDomain { get; }

        //// extern const NSInteger kBCOVFPSAuthProxyErrorCodeApplicationCertificateRequestFailed;
        //[Field("kBCOVFPSAuthProxyErrorCodeApplicationCertificateRequestFailed")]
        //nint kBCOVFPSAuthProxyErrorCodeApplicationCertificateRequestFailed { get; }

        //// extern const NSInteger kBCOVFPSAuthProxyErrorCodeContentKeyRequestFailed;
        //[Field("kBCOVFPSAuthProxyErrorCodeContentKeyRequestFailed")]
        //nint kBCOVFPSAuthProxyErrorCodeContentKeyRequestFailed { get; }

        //// extern const NSInteger kBCOVFPSAuthProxyErrorCodeContentKeyGenerationFailed;
        //[Field("kBCOVFPSAuthProxyErrorCodeContentKeyGenerationFailed")]
        //nint kBCOVFPSAuthProxyErrorCodeContentKeyGenerationFailed { get; }
    }

    // @interface BCOVFPSBrightcoveAuthProxy : NSObject <BCOVFPSAutorizationProxy>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
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

    // @interface Unavailable (BCOVFPSBrightcoveAuthProxy)
    //[Category]
    //[BaseType(typeof(BCOVFPSBrightcoveAuthProxy))]
    [BaseType(typeof(NSObject))]
    [Protocol]
    [DisableDefaultCtor]
    interface BCOVFPSBrightcoveAuthProxy_Unavailable
    {
    }

    // @interface Deprecated (BCOVFPSBrightcoveAuthProxy)
    //[Category]
    //[BaseType(typeof(BCOVFPSBrightcoveAuthProxy))]
    [BaseType(typeof(NSObject))]
    [Protocol]
    interface BCOVFPSBrightcoveAuthProxy_Deprecated
    {
        // -(instancetype _Nullable)initWithApplicationId:(NSString * _Nonnull)appId publisherId:(NSString * _Nonnull)pubId __attribute__((deprecated("Use -BCOVFPSBrightcoveAuthProxy initWithPublisherId:applicationId: instead")));
        //[Export("initWithApplicationId:publisherId:")]
        //IntPtr Constructor(string appId, string pubId);
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const kBCOVSSVideoPropertiesKeyTextTracks;
        //[Field("kBCOVSSVideoPropertiesKeyTextTracks")]
        //NSString kBCOVSSVideoPropertiesKeyTextTracks { get; }

        //// extern NSString *const kBCOVSSTextTracksKeySource;
        //[Field("kBCOVSSTextTracksKeySource")]
        //NSString kBCOVSSTextTracksKeySource { get; }

        //// extern NSString *const kBCOVSSTextTracksKeySourceLanguage;
        //[Field("kBCOVSSTextTracksKeySourceLanguage")]
        //NSString kBCOVSSTextTracksKeySourceLanguage { get; }

        //// extern NSString *const kBCOVSSTextTracksKeyLabel;
        //[Field("kBCOVSSTextTracksKeyLabel")]
        //NSString kBCOVSSTextTracksKeyLabel { get; }

        //// extern NSString *const kBCOVSSTextTracksKeyDuration;
        //[Field("kBCOVSSTextTracksKeyDuration")]
        //NSString kBCOVSSTextTracksKeyDuration { get; }

        //// extern NSString *const kBCOVSSTextTracksKeyDefault;
        //[Field("kBCOVSSTextTracksKeyDefault")]
        //NSString kBCOVSSTextTracksKeyDefault { get; }

        //// extern NSString *const kBCOVSSTextTracksKeyMIMEType;
        //[Field("kBCOVSSTextTracksKeyMIMEType")]
        //NSString kBCOVSSTextTracksKeyMIMEType { get; }

        //// extern NSString *const kBCOVSSTextTracksKeyKind;
        //[Field("kBCOVSSTextTracksKeyKind")]
        //NSString kBCOVSSTextTracksKeyKind { get; }

        //// extern NSString *const kBCOVSSTextTracksKindSubtitles;
        //[Field("kBCOVSSTextTracksKindSubtitles")]
        //NSString kBCOVSSTextTracksKindSubtitles { get; }

        //// extern NSString *const kBCOVSSTextTracksKindCaptions;
        //[Field("kBCOVSSTextTracksKindCaptions")]
        //NSString kBCOVSSTextTracksKindCaptions { get; }

        //// extern NSString *const kBCOVSSTextTracksKeySourceType;
        //[Field("kBCOVSSTextTracksKeySourceType")]
        //NSString kBCOVSSTextTracksKeySourceType { get; }

        //// extern NSString *const kBCOVSSTextTracksKeySourceTypeWebVTTURL;
        //[Field("kBCOVSSTextTracksKeySourceTypeWebVTTURL")]
        //NSString kBCOVSSTextTracksKeySourceTypeWebVTTURL { get; }

        //// extern NSString *const kBCOVSSTextTracksKeySourceTypeM3U8URL;
        //[Field("kBCOVSSTextTracksKeySourceTypeM3U8URL")]
        //NSString kBCOVSSTextTracksKeySourceTypeM3U8URL { get; }
    }

    // @interface BCOVSSAdditions (BCOVPlayerSDKManager)
    //[Category]
    //[BaseType(typeof(BCOVPlayerSDKManager))]
    [BaseType(typeof(NSObject))]
    [Protocol]
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
    //[BaseType(typeof(BCOVPlayerSDKManager))]
    [BaseType(typeof(NSObject))]
    [Protocol]
    interface BCOVPlayerSDKManager_BCOVSSAdditionsDepricated
    {
        // -(id<BCOVPlaybackSessionProvider>)createSidecarSubtitlesSessionProviderWithOptions:(BCOVSSSessionProviderOption *)options __attribute__((deprecated("Use -[BCOVPlayerSDKManager createSidecarSubtitlesSessionWithUpstreamSessionProvider:] with a nil upstream session provider instead.")));
        //[Export("createSidecarSubtitlesSessionProviderWithOptions:")]
        //BCOVPlaybackSessionProvider CreateSidecarSubtitlesSessionProviderWithOptions(BCOVSSSessionProviderOption options);
    }

    // @interface BCOVCuePointCollection : NSObject <NSCopying, NSFastEnumeration>
    [BaseType(typeof(NSObject))]
    interface BCOVCuePointCollection : INSCopying //, INSFastEnumeration
    {
        // -(instancetype)initWithArray:(NSArray *)cuePoints;
        [Export("initWithArray:")]
        //[Verify(StronglyTypedNSArray)]
        IntPtr Constructor(NSObject[] cuePoints);

        // -(instancetype)initWithCuePoint:(BCOVCuePoint *)cuePoint;
        [Export("initWithCuePoint:")]
        IntPtr Constructor(BCOVCuePoint cuePoint);

        // -(NSArray *)array;
        [Export("array")]
        //[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] Array { get; }

        // -(NSUInteger)count;
        [Export("count")]
        //[Verify(MethodToProperty)]
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
        BCOVCuePointCollection CuePointsAtOrAfterTimebeforeTim(CMTime lowerBound, CMTime upperBound);

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

        // +(instancetype)collectionWithArray:(NSArray *)cuePoints;
        [Static]
        [Export("collectionWithArray:")]
        //[Verify(StronglyTypedNSArray)]
        BCOVCuePointCollection CollectionWithArray(NSObject[] cuePoints);

        // +(instancetype)emptyCollection;
        [Static]
        [Export("emptyCollection")]
        BCOVCuePointCollection EmptyCollection();
    }

    // @interface BCOVTVCommon : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVTVCommon
    {
        // +(UIColor *)liveViewTitleColorForLive;
        [Static]
        [Export("liveViewTitleColorForLive")]
        //[Verify(MethodToProperty)]
        UIColor LiveViewTitleColorForLive { get; }

        // +(UIColor *)progressViewMaximumTrackColor;
        [Static]
        [Export("progressViewMaximumTrackColor")]
        //[Verify(MethodToProperty)]
        UIColor ProgressViewMaximumTrackColor { get; }

        // +(UIColor *)progressViewMinimumTrackColor;
        [Static]
        [Export("progressViewMinimumTrackColor")]
        //[Verify(MethodToProperty)]
        UIColor ProgressViewMinimumTrackColor { get; }

        // +(UIColor *)progressViewBufferTrackColor;
        [Static]
        [Export("progressViewBufferTrackColor")]
        //[Verify(MethodToProperty)]
        UIColor ProgressViewBufferTrackColor { get; }
    }

    // @interface BCOVTVControlsView : UIView
    [BaseType(typeof(UIView))]
    interface BCOVTVControlsView
    {
        // @property (nonatomic) UIEdgeInsets insets;
        [Export("insets", ArgumentSemantic.Assign)]
        UIEdgeInsets Insets { get; set; }

        // @property (nonatomic) BOOL showClockTime;
        [Export("showClockTime")]
        bool ShowClockTime { get; set; }

        // @property (readwrite, nonatomic) BOOL advertisingMode;
        [Export("advertisingMode")]
        bool AdvertisingMode { get; set; }

        // @property (readonly, nonatomic, weak) BCOVTVProgressView * progressView;
        [Export("progressView", ArgumentSemantic.Weak)]
        BCOVTVProgressView ProgressView { get; }

        // @property (readonly, nonatomic, weak) UIView * currentTimeIndicatorView;
        [Export("currentTimeIndicatorView", ArgumentSemantic.Weak)]
        UIView CurrentTimeIndicatorView { get; }

        // @property (readonly, nonatomic, weak) UILabel * currentTimeLabel;
        [Export("currentTimeLabel", ArgumentSemantic.Weak)]
        UILabel CurrentTimeLabel { get; }

        // @property (readonly, nonatomic, weak) UILabel * timeRemainingLabel;
        [Export("timeRemainingLabel", ArgumentSemantic.Weak)]
        UILabel TimeRemainingLabel { get; }

        // @property (readonly, nonatomic, weak) UILabel * descriptionLabel;
        [Export("descriptionLabel", ArgumentSemantic.Weak)]
        UILabel DescriptionLabel { get; }
    }

    // @protocol BCOVTVPlayerViewDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BCOVTVPlayerViewDelegate
    {
        // @optional -(void)playerView:(BCOVTVPlayerView *)playerView controlsFadingViewWillFadeOut:(UIView *)controlsFadingView;
        [Export("playerView:controlsFadingViewWillFadeOut:")]
        void PlayerView(BCOVTVPlayerView playerView, UIView controlsFadingView);

        // @optional -(void)playerView:(BCOVTVPlayerView *)playerView controlsFadingViewWillFadeIn:(UIView *)controlsFadingView;
        [Export("playerView:controlsFadingViewWillFadeIn:")]
        void PlayerViewcontrolsFadingViewWillFadeIn(BCOVTVPlayerView playerView, UIView controlsFadingView);

        // @optional -(void)playerView:(BCOVTVPlayerView *)playerView controlsFadingViewDidFadeOut:(UIView *)controlsFadingView;
        [Export("playerView:controlsFadingViewDidFadeOut:")]
        void PlayerViewcontrolsFadingViewDidFadeOut(BCOVTVPlayerView playerView, UIView controlsFadingView);

        // @optional -(void)playerView:(BCOVTVPlayerView *)playerView controlsFadingViewDidFadeIn:(UIView *)controlsFadingView;
        [Export("playerView:controlsFadingViewDidFadeIn:")]
        void PlayerViewcontrolsFadingViewDidFadeIn(BCOVTVPlayerView playerView, UIView controlsFadingView);

        // @optional -(BOOL)playerViewShouldRequireLinearPlayback:(BCOVTVPlayerView *)playerView;
        [Export("playerViewShouldRequireLinearPlayback:")]
        bool PlayerViewShouldRequireLinearPlayback(BCOVTVPlayerView playerView);
    }

    // @interface BCOVTVPlayerViewOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface BCOVTVPlayerViewOptions
    {
        // @property (nonatomic, weak) UIViewController * presentingViewController;
        [Export("presentingViewController", ArgumentSemantic.Weak)]
        UIViewController PresentingViewController { get; set; }

        // @property (assign, nonatomic) NSTimeInterval jumpInterval;
        [Export("jumpInterval")]
        double JumpInterval { get; set; }

        // @property (assign, nonatomic) NSTimeInterval hideControlsInterval;
        [Export("hideControlsInterval")]
        double HideControlsInterval { get; set; }

        // @property (assign, nonatomic) NSTimeInterval hideControlsAnimationDuration;
        [Export("hideControlsAnimationDuration")]
        double HideControlsAnimationDuration { get; set; }

        // @property (assign, nonatomic) NSTimeInterval showControlsAnimationDuration;
        [Export("showControlsAnimationDuration")]
        double ShowControlsAnimationDuration { get; set; }

        [Wrap("WeakAccessibilityDelegate")]
        //Hack
        NSObject AccessibilityDelegate { get; set; }

        // @property (nonatomic, weak) id<BCOVTVAccessibilityDelegate> accessibilityDelegate;
        [NullAllowed, Export("accessibilityDelegate", ArgumentSemantic.Weak)]
        NSObject WeakAccessibilityDelegate { get; set; }
    }

    // @interface BCOVTVPlayerView : UIView
    [BaseType(typeof(UIView))]
    interface BCOVTVPlayerView
    {
        // @property (nonatomic, weak) id<BCOVPlaybackController> playbackController;
        [Export("playbackController", ArgumentSemantic.Weak)]
        BCOVPlaybackController PlaybackController { get; set; }

        [Wrap("WeakDelegate")]
        BCOVTVPlayerViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BCOVTVPlayerViewDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, copy, nonatomic) BCOVTVPlayerViewOptions * options;
        [Export("options", ArgumentSemantic.Copy)]
        BCOVTVPlayerViewOptions Options { get; }

        // @property (nonatomic) BCOVTVPlayerType playerType;
        [Export("playerType", ArgumentSemantic.Assign)]
        BCOVTVPlayerType PlayerType { get; set; }

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

        // @property (readonly, nonatomic) BCOVTVSettingsView * settingsView;
        [Export("settingsView")]
        BCOVTVSettingsView SettingsView { get; }

        // @property (readonly, nonatomic) BCOVTVControlsView * controlsView;
        [Export("controlsView")]
        BCOVTVControlsView ControlsView { get; }

        // @property (nonatomic, strong) UIFocusGuide * settingsControlFocusGuide;
        [Export("settingsControlFocusGuide", ArgumentSemantic.Strong)]
        UIFocusGuide SettingsControlFocusGuide { get; set; }

        // -(instancetype)initWithOptions:(BCOVTVPlayerViewOptions *)options __attribute__((objc_designated_initializer));
        [Export("initWithOptions:")]
        [DesignatedInitializer]
        IntPtr Constructor(BCOVTVPlayerViewOptions options);

        // -(void)dimVideoView:(BOOL)dim;
        [Export("dimVideoView:")]
        void DimVideoView(bool dim);

        // -(void)showView:(BCOVTVShowViewType)viewType;
        [Export("showView:")]
        void ShowView(BCOVTVShowViewType viewType);

        // -(void)showControlsFadingView:(BOOL)show completion:(void (^)(void))completion;
        [Export("showControlsFadingView:completion:")]
        void ShowControlsFadingView(bool show, Action completion);

        // -(void)showTopTabBar:(BOOL)showTopTabBar;
        [Export("showTopTabBar:")]
        void ShowTopTabBar(bool showTopTabBar);

        // -(void)resetHideControlsIntervalTimer;
        [Export("resetHideControlsIntervalTimer")]
        void ResetHideControlsIntervalTimer();
    }

    // @interface BCOVTVProgressView : UIView
    [BaseType(typeof(UIView))]
    interface BCOVTVProgressView
    {
        // @property (readwrite, nonatomic) CGFloat trackHeight;
        [Export("trackHeight")]
        nfloat TrackHeight { get; set; }

        // @property (readwrite, nonatomic) double progress;
        [Export("progress")]
        double Progress { get; set; }

        // @property (readwrite, nonatomic) double bufferProgress;
        [Export("bufferProgress")]
        double BufferProgress { get; set; }

        // @property (readwrite, nonatomic) double duration;
        [Export("duration")]
        double Duration { get; set; }

        // @property (readwrite, nonatomic) BOOL advertisingMode;
        [Export("advertisingMode")]
        bool AdvertisingMode { get; set; }

        // @property (nonatomic) UIColor * minimumTrackTintColor;
        [Export("minimumTrackTintColor", ArgumentSemantic.Assign)]
        UIColor MinimumTrackTintColor { get; set; }

        // @property (nonatomic) UIColor * maximumTrackTintColor;
        [Export("maximumTrackTintColor", ArgumentSemantic.Assign)]
        UIColor MaximumTrackTintColor { get; set; }

        // @property (nonatomic) UIColor * bufferProgressTintColor;
        [Export("bufferProgressTintColor", ArgumentSemantic.Assign)]
        UIColor BufferProgressTintColor { get; set; }

        // @property (nonatomic) UIColor * advertisingMinimumTrackTintColor;
        [Export("advertisingMinimumTrackTintColor", ArgumentSemantic.Assign)]
        UIColor AdvertisingMinimumTrackTintColor { get; set; }

        // @property (nonatomic) UIColor * advertisingMaximumTrackTintColor;
        [Export("advertisingMaximumTrackTintColor", ArgumentSemantic.Assign)]
        UIColor AdvertisingMaximumTrackTintColor { get; set; }

        // @property (nonatomic) UIColor * minimumTrackAdMarkerColor;
        [Export("minimumTrackAdMarkerColor", ArgumentSemantic.Assign)]
        UIColor MinimumTrackAdMarkerColor { get; set; }

        // @property (nonatomic) UIColor * bufferTrackAdMarkerColor;
        [Export("bufferTrackAdMarkerColor", ArgumentSemantic.Assign)]
        UIColor BufferTrackAdMarkerColor { get; set; }

        // @property (nonatomic) UIColor * maximumTrackAdMarkerColor;
        [Export("maximumTrackAdMarkerColor", ArgumentSemantic.Assign)]
        UIColor MaximumTrackAdMarkerColor { get; set; }

        // @property (nonatomic) UIColor * minimumTrackMarkerColor;
        [Export("minimumTrackMarkerColor", ArgumentSemantic.Assign)]
        UIColor MinimumTrackMarkerColor { get; set; }

        // @property (nonatomic) UIColor * bufferTrackMarkerColor;
        [Export("bufferTrackMarkerColor", ArgumentSemantic.Assign)]
        UIColor BufferTrackMarkerColor { get; set; }

        // @property (nonatomic) UIColor * maximumTrackMarkerColor;
        [Export("maximumTrackMarkerColor", ArgumentSemantic.Assign)]
        UIColor MaximumTrackMarkerColor { get; set; }

        // -(void)addMarkerAt:(double)position duration:(double)duration isAd:(BOOL)isAd color:(UIColor *)color;
        [Export("addMarkerAt:duration:isAd:color:")]
        void AddMarkerAt(double position, double duration, bool isAd, UIColor color);

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
    }

    // @interface BCOVTVSettingsView : UIView
    [BaseType(typeof(UIView))]
    interface BCOVTVSettingsView
    {
        // @property (nonatomic) UIEdgeInsets insets;
        [Export("insets", ArgumentSemantic.Assign)]
        UIEdgeInsets Insets { get; set; }

        // @property (readonly, nonatomic, weak) UITabBar * topTabBar;
        [Export("topTabBar", ArgumentSemantic.Weak)]
        UITabBar TopTabBar { get; }

        // @property (readonly, nonatomic, weak) UIVisualEffectView * topTabBarBackgroundView;
        [Export("topTabBarBackgroundView", ArgumentSemantic.Weak)]
        UIVisualEffectView TopTabBarBackgroundView { get; }

        // @property (readonly, nonatomic, weak) UIView * topTabBarItemContainerView;
        [Export("topTabBarItemContainerView", ArgumentSemantic.Weak)]
        UIView TopTabBarItemContainerView { get; }

        // @property (readonly, nonatomic, weak) UIView * topTabBarIndicatorView;
        [Export("topTabBarIndicatorView", ArgumentSemantic.Weak)]
        UIView TopTabBarIndicatorView { get; }

        // @property (readonly, nonatomic, weak) UIFocusGuide * topTabBarItemContainerViewFocusGuide;
        [Export("topTabBarItemContainerViewFocusGuide", ArgumentSemantic.Weak)]
        UIFocusGuide TopTabBarItemContainerViewFocusGuide { get; }

        // @property (readonly, nonatomic, weak) BCOVTVTabBarItemView * currentTopTabBarItemView;
        [Export("currentTopTabBarItemView", ArgumentSemantic.Weak)]
        BCOVTVTabBarItemView CurrentTopTabBarItemView { get; }

        // @property (nonatomic) NSArray<BCOVTVTabBarItemView *> * topTabBarItemViews;
        [Export("topTabBarItemViews", ArgumentSemantic.Assign)]
        BCOVTVTabBarItemView[] TopTabBarItemViews { get; set; }

        // @property (readwrite, nonatomic) BOOL advertisingMode;
        [Export("advertisingMode")]
        bool AdvertisingMode { get; set; }

        // @property (assign, nonatomic) BOOL isPlaying;
        [Export("isPlaying")]
        bool IsPlaying { get; set; }

        [Wrap("WeakAccessibilityDelegate")]
        //Hack
        NSObject AccessibilityDelegate { get; set; }

        // @property (nonatomic, weak) id<BCOVTVAccessibilityDelegate> accessibilityDelegate;
        [NullAllowed, Export("accessibilityDelegate", ArgumentSemantic.Weak)]
        NSObject WeakAccessibilityDelegate { get; set; }

        // -(void)showTopTabBar:(BOOL)show;
        [Export("showTopTabBar:")]
        void ShowTopTabBar(bool show);

        // -(void)enable:(BOOL)enable tabBarItemView:(BCOVTVTabBarItemView *)tabBarItemView;
        [Export("enable:tabBarItemView:")]
        void Enable(bool enable, BCOVTVTabBarItemView tabBarItemView);
    }

    // @interface BCOVTVTabBarItemView : UIView <BCOVPlaybackSessionConsumer>
    [BaseType(typeof(UIView))]
    interface BCOVTVTabBarItemView : BCOVPlaybackSessionConsumer
    {
        // @property (nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { get; set; }

        // @property (nonatomic) NSString * title;
        [Export("title")]
        string Title { get; set; }

        // @property (readonly, nonatomic, weak) BCOVTVPlayerView * playerView;
        [Export("playerView", ArgumentSemantic.Weak)]
        BCOVTVPlayerView PlayerView { get; }

        // -(instancetype)initWithSize:(CGSize)size playerView:(BCOVTVPlayerView *)playerView;
        [Export("initWithSize:playerView:")]
        IntPtr Constructor(CGSize size, BCOVTVPlayerView playerView);

        // -(void)tabBarItemViewDidAdvanceToPlaybackSession:(id<BCOVPlaybackSession>)session;
        [Export("tabBarItemViewDidAdvanceToPlaybackSession:")]
        void TabBarItemViewDidAdvanceToPlaybackSession(BCOVPlaybackSession session);

        // -(void)tabBarItemViewWillAppear:(BOOL)animated;
        [Export("tabBarItemViewWillAppear:")]
        void TabBarItemViewWillAppear(bool animated);

        // -(void)tabBarItemViewDidAppear:(BOOL)animated;
        [Export("tabBarItemViewDidAppear:")]
        void TabBarItemViewDidAppear(bool animated);

        // -(void)tabBarItemViewWillDisappear:(BOOL)animated;
        [Export("tabBarItemViewWillDisappear:")]
        void TabBarItemViewWillDisappear(bool animated);

        // -(void)tabBarItemViewDidDisappear:(BOOL)animated;
        [Export("tabBarItemViewDidDisappear:")]
        void TabBarItemViewDidDisappear(bool animated);

        // -(void)updateForDarkMode:(BOOL)usingDarkMode;
        [Export("updateForDarkMode:")]
        void UpdateForDarkMode(bool usingDarkMode);
    }

    // @interface BCOVTVInfoTabBarItemView : BCOVTVTabBarItemView
    [BaseType(typeof(BCOVTVTabBarItemView))]
    interface BCOVTVInfoTabBarItemView
    {
        // @property (nonatomic) UIImageView * posterImageView;
        [Export("posterImageView", ArgumentSemantic.Assign)]
        UIImageView PosterImageView { get; set; }

        // @property (nonatomic) UILabel * titleLabel;
        [Export("titleLabel", ArgumentSemantic.Assign)]
        UILabel TitleLabel { get; set; }

        // @property (nonatomic) UILabel * infoLabel;
        [Export("infoLabel", ArgumentSemantic.Assign)]
        UILabel InfoLabel { get; set; }

        // @property (nonatomic) UILabel * descriptionLabel;
        [Export("descriptionLabel", ArgumentSemantic.Assign)]
        UILabel DescriptionLabel { get; set; }

        // @property (nonatomic) UIButton * moreButton;
        [Export("moreButton", ArgumentSemantic.Assign)]
        UIButton MoreButton { get; set; }

        // +(instancetype)viewWithPlayerView:(BCOVTVPlayerView *)playerView;
        [Static]
        [Export("viewWithPlayerView:")]
        BCOVTVInfoTabBarItemView ViewWithPlayerView(BCOVTVPlayerView playerView);
    }

    // @interface BCOVTVSubtitlesTabBarItemView : BCOVTVTabBarItemView
    [BaseType(typeof(BCOVTVTabBarItemView))]
    interface BCOVTVSubtitlesTabBarItemView
    {
        // +(BOOL)sessionHasSubtitles:(id<BCOVPlaybackSession>)session;
        [Static]
        [Export("sessionHasSubtitles:")]
        bool SessionHasSubtitles(BCOVPlaybackSession session);

        // +(instancetype)viewWithPlayerView:(BCOVTVPlayerView *)playerView;
        [Static]
        [Export("viewWithPlayerView:")]
        BCOVTVSubtitlesTabBarItemView ViewWithPlayerView(BCOVTVPlayerView playerView);
    }

    // @interface BCOVTVAudioTabBarItemView : BCOVTVTabBarItemView
    [BaseType(typeof(BCOVTVTabBarItemView))]
    interface BCOVTVAudioTabBarItemView
    {
        // +(BOOL)sessionHasAdditionalAudioTracks:(id<BCOVPlaybackSession>)session;
        [Static]
        [Export("sessionHasAdditionalAudioTracks:")]
        bool SessionHasAdditionalAudioTracks(BCOVPlaybackSession session);

        // +(instancetype)viewWithPlayerView:(BCOVTVPlayerView *)playerView;
        [Static]
        [Export("viewWithPlayerView:")]
        BCOVTVAudioTabBarItemView ViewWithPlayerView(BCOVTVPlayerView playerView);
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
