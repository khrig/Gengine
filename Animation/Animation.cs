using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Gengine.Animation {
    public class Animation {
        List<AnimationFrame> _frames = new List<AnimationFrame>();
        TimeSpan _timeIntoAnimation;

        TimeSpan Duration {
            get {
                double totalSeconds = 0;
                foreach (var frame in _frames) {
                    totalSeconds += frame.Duration.TotalSeconds;
                }

                return TimeSpan.FromSeconds(totalSeconds);
            }
        }

        public void AddFrame(Rectangle rectangle, TimeSpan duration) {
            AnimationFrame newFrame = new AnimationFrame() {
                SourceRectangle = rectangle,
                Duration = duration
            };

            _frames.Add(newFrame);
        }

        public void Update(GameTime gameTime) {
            double secondsIntoAnimation = _timeIntoAnimation.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds;
            double remainder = secondsIntoAnimation % Duration.TotalSeconds;
            _timeIntoAnimation = TimeSpan.FromSeconds(remainder);
        }

        public Rectangle CurrentRectangle {
            get {
                AnimationFrame currentFrame = null;

                // See if we can find the frame
                TimeSpan accumulatedTime = TimeSpan.Zero;
                foreach (var frame in _frames){
                    if (accumulatedTime + frame.Duration >= _timeIntoAnimation) {
                        currentFrame = frame;
                        break;
                    }
                    accumulatedTime += frame.Duration;
                }

                // If no frame was found, then try the last frame, 
                // just in case timeIntoAnimation somehow exceeds Duration
                if (currentFrame == null) {
                    currentFrame = _frames.LastOrDefault();
                }

                // If we found a frame, return its rectangle, otherwise
                // return an empty rectangle (one with no width or height)
                if (currentFrame != null) {
                    return currentFrame.SourceRectangle;
                }

                return Rectangle.Empty;
            }
        }
    }
}
