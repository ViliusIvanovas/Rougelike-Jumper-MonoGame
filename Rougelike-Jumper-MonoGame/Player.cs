using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Rougelike_Jumper_MonoGame;

public class Player : Game
{
    public int Health;
    public Vector2 Position;
    
    public Texture2D[] IdleTextures = new Texture2D[3];
    public Dictionary<string, Texture2D[]> AnimationTextures = new Dictionary<string, Texture2D[]>();

    public int CurrentAnimationIndex;

    public Player(int health, Vector2 startPosition)
    {
        Health = health;
        Position = startPosition;
    }

    protected override void BeginRun()
    {
        base.BeginRun();

        
    }
}