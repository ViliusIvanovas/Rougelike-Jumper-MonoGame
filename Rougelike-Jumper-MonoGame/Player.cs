using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Rougelike_Jumper_MonoGame;

public class Player : Object
{
    public int Health;
    public Vector2 Position;

    public Texture2D[] IdleTextures = new Texture2D[3];
    public Dictionary<string, Texture2D[]> AnimationTextures = new Dictionary<string, Texture2D[]>();
    public string CurrentAnimationState = "Idle";

    public int CurrentAnimationIndex;
    public double TimeSinceAnimationChange = 0;

    public Player(int health, Vector2 startPosition)
    {
        Health = health;
        Position = startPosition;
    }

    public void Update(double DeltaTime)
    {
        TimeSinceAnimationChange += DeltaTime;

        if (TimeSinceAnimationChange > 3)
        {
            TimeSinceAnimationChange = 0;
            CurrentAnimationIndex++;
            if (CurrentAnimationIndex >= AnimationTextures["Idle"].Length)
            {
                CurrentAnimationIndex = 0;
            }
        }
    }
}