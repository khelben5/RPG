using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public class SpriteManager
    {
        protected Rectangle[] _rectangles;
        protected int _frameIndex = 0;

        private readonly Texture2D _texture;
        private readonly float _rotation = 0f;
        private readonly float _scale = 1f;

        private Vector2 _position = Vector2.Zero;

        public Vector2 Position { get => _position; set => _position = value; }

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
                _position,
                _rectangles[_frameIndex],
                Color.White,
                _rotation,
                new(),
                _scale,
                new(),
                0f
            );
        }

        public float Width => _rectangles[0].Width;
        public float Height => _rectangles[0].Height;
    }

    public class SpriteAnimation : SpriteManager
    {
        private const int _stopFrameIndex = 1;

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
