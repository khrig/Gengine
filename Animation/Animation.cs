using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Gengine.Animation {
    public class Animation {
        public List<AnimationFrame> AnimationFrames { get; set; }
        public AnimationFrame CurrentFrame { get { return AnimationFrames[CurrentFrameIndex]; } }
        public int CurrentFrameIndex { get; set; }

        public Rectangle SourceRectangle{
            get { return CurrentFrame.SourceRectangle; }
        }

        public Animation(){
            AnimationFrames = new List<AnimationFrame>();
        }

        /// <summary>
        /// Add a frame of animation, duration in Milliseconds
        /// </summary>
        /// <param name="duration">duration of this frame in Milliseconds</param>
        /// <param name="sourceRectangle"></param>
        public void AddFrame(float duration, Rectangle sourceRectangle){
            var frame = new AnimationFrame{Duration = duration, SourceRectangle = sourceRectangle};
            AnimationFrames.Add(frame);
        }
    }
}
