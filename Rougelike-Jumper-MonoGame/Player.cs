using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rougelike_Jumper_MonoGame
{
    class Player
    {
        public Vector2 Position;
        public Vector2 RestartPosition;
        public bool IsAlive;

        public Player(Vector2 SpawnPosition)
        {
            RestartPosition = SpawnPosition;

            LoadContent();
        }

        public void LoadContent()
        {

        }

        public void Reset(Vector2 SpawnPosition)
        {
            Position = RestartPosition;
            Velocity = Vector2.Zero;
            IsAlive = true;
            sprite.PlayAnimation(idleAnimation);
        }
    }
}