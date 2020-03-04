//
// BCOVGoogleCastManager.h
// BrightcoveGoogleCast
//
// Copyright (c) 2019 Brightcove, Inc. All rights reserved.
// License: https://accounts.brightcove.com/en/terms-and-conditions
//

#import <BCOVPlaybackController.h>

@class GCKUICastButton, GCKImage;

/**
 * Conform to this protocol to receive information about the state
 * the Google Cast session
 */
@protocol BCOVGoogleCastManagerDelegate<NSObject>


@property (nonatomic, strong, readonly) id<BCOVPlaybackController> _Nullable playbackController;

@optional

/**
 * @abstract This method is called when a cast session ends
 *
 * @discussion You can use this to show/hide UI elements, or trigger
 * other events, once a cast session ends
 *
 * @param lastKnownStreamPosition An NSTimeInterval value of the last known stream position
 * @param error If we received an error from the Google Cast SDK, it will be passed through here
 *
 */
- (void)switchedToLocalPlayback:(NSTimeInterval)lastKnownStreamPosition withError:(nullable NSError *)error;

/**
 * @abstract This method is called when a cast session starts
 *
 * @discussion You can use this to show/hide UI elements, or trigger
 * other events, once a cast session begins.
 */
- (void)switchedToRemotePlayback;

/**
 * @abstract This method is called when a casted video has finished playing.
 *
 * @discussion You can use this to show/hide UI elements, or trigger
 * other events, once a casted video has completed playback
 */
- (void)currentCastedVideoDidComplete;

/**
 * @abstract This method is called when a casted video fails to play.
 *
 * @discussion You can use this to show/hide UI elements, or trigger
 * other events, once a casted video fails to play
 */
- (void)castedVideoFailedToPlay;

/**
 * @abstract This method is called when a suitable source is not found.
 *
 * @discussion The BCOVGoogleCastManager will look for HTTPS version of
 * HLS v3, then check for DASH, and finally an MP4 source. If no HTTPS
 * versions are found it will then check for HTTP versions of the same
 * source types. If no HTTP versions are found this method will be called.
 */
- (void)suitableSourceNotFound;

@end

NS_ASSUME_NONNULL_BEGIN

@interface BCOVGoogleCastManager : NSObject<BCOVPlaybackSessionConsumer>

/**
 * Returns the Google Cast Manager singleton.
 *
 * @return The Google Cast Manager singleton.
 */
+ (BCOVGoogleCastManager *)sharedManager;

/**
 * The delegate object that will receive events from the manager
 */
@property (nonatomic, weak) id<BCOVGoogleCastManagerDelegate> delegate;

/**
 * The GCKImage that will be used when there is no poster image
 * available for a video
 */
@property (nonatomic, strong) GCKImage *fallbackPosterImage;

/**
 * The height and width that you want to use for the GCKImage object
 * image that is created. Defaults to 480h x 720w
 */
@property (nonatomic, assign) CGSize posterImageSize;

@end

NS_ASSUME_NONNULL_END
