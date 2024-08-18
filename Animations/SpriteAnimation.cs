using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public class SpriteManager
    {
        protected const int _stopFrameIndex = 1;

        protected Rectangle[] _rectangles;
        protected int _frameIndex = 0;

        private readonly Texture2D _texture;
        private readonly float _rotation = 0f;
        private readonly float _scale = 1f;

        public Vector2 Position { get; set; }
        public Vector2 Size => _rectangles[_stopFrameIndex].Size.ToVector2();

        public SpriteManager(Texture2D texture, int frames)
        {
            _texture = texture;
            int width = texture.Width / frames;
            _rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
                _rectangles[i] = new Rectangle(i * width, 0, width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture,
                Position - Size / 2,
                _rectangles[_frameIndex],
                Color.White,
                _rotation,
                new(),
                _scale,
                new(),
                0f
            );
        }
    }

    public class SpriteAnimation : SpriteManager
    {
        private readonly bool _isLooping = true;
        private readonly float _timeToUpdate;

        private float _elapsedTime;

        public SpriteAnimation(Texture2D Texture, int frames, int fps) : base(Texture, frames)
        {
            _timeToUpdate = 1f / fps;
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_elapsedTime > _timeToUpdate)
            {
                _elapsedTime -= _timeToUpdate;

                if (_frameIndex < _rectangles.Length - 1)
                    _frameIndex++;

                else if (_isLooping)
                    _frameIndex = 0;
            }
        }

        public void Stop()
        {
            _frameIndex = _stopFrameIndex;
        }
    }
}
