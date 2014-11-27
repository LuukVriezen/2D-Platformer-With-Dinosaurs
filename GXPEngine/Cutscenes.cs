using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GXPEngine
{
    class Cutscenes : GameObject
    {
        #region oldShit
        //Video video;
        //VideoPlayer videoPlayer;
        //GraphicsDeviceManager graphics;
        //SpriteBatch spriteBatch;
        //Microsoft.Xna.Framework.Game game = Microsoft.Xna.Framework.Game;
        #endregion
        AnimSprite endScene;
        AnimSprite startScene;

        float endFrame = 0.0f;
        int endFirstFrame = 0;
        int endLastFrame = 14;

        float startFrame = 0.0f;
        int startFirstFrame = 0;
        int startLastFrame = 26;

        //int[] endFrameSequence = new int[] { 0, 3, 6, 9, 12, 15, 1, 4, 7, 10, 13, 16, 2, 5, 8, 11, 14 };

        public bool isEndScene = false;

        public Cutscenes(int width, int height)
        {
            #region oldShit
            //    graphics = new GraphicsDeviceManager(this);
        //    game.graphics.PreferredBackBufferHeight = 720;
        //    graphics.PreferredBackBufferWidth = 1280;

        //    Content.RootDirectory = "../../Assets/Video";
        //    spriteBatch = new SpriteBatch(GraphicsDevice);
        //    video = Content.Load<Video>("first cut scene");
            //    videoPlayer = new VideoPlayer();
            #endregion
            startScene = new AnimSprite("../../Assets/Video/cut1sprite1111.png", 6, 5);
            startScene.width = width;
            startScene.height = height;
            AddChild(startScene);

            endScene = new AnimSprite("../../Assets/Video/spritesheet01.png", 5, 3);
            endScene.width = width;
            endScene.height = height;
            //AddChild(endScene);
        }

        void Update()
        {
            //Console.WriteLine();
        }

        public bool OpeningScene()
        {
            startFrame = startFrame + 0.1f;
            if (startFrame >= startLastFrame + 1)
            {
                startFrame = startFirstFrame;
            }
            if (startFrame < startFirstFrame)
            {
                startFrame = startLastFrame;
            }
            startScene.SetFrame((int)startFrame);
            if ((int)startFrame >= 26)
            {
                startFrame = 0;
                return false;
            }
            return true;
        }

        public bool EndScene()
        {
            endFrame = endFrame + 0.1f;
            //endScene.SetFrame(0);
            if (endFrame >= endLastFrame + 1)
            {
                endFrame = endFirstFrame;
            }
            if (endFrame < endFirstFrame)
            {
                endFrame = endLastFrame;
            }
            endScene.SetFrame((int)endFrame);

            if (endLastFrame >= 14)
            {
                return true;
            }
            return false;
        }
    }
}
