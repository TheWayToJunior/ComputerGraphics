using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork8.Models
{
    /// <summary>
    /// The class responsible for the margins between frames in the original image
    /// </summary>
    public class Gap
    {
        public float BetweenSprites { get; set; }

        public float BetweenFrames { get; set; }

        public Gap(float sprites, float frames)
        {
            BetweenSprites = sprites;
            BetweenFrames = frames;
        }
    }
}
