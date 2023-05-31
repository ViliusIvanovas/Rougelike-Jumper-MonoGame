using System.Runtime.InteropServices;
using Silk.NET.Core;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

internal class Program
{
    private static IWindow window;
    private static IInputContext input;

    private static void Main(string[] args)
    {
        WindowOptions options = new WindowOptions();
        options.API = GraphicsAPI.Default;
        options.Title = "Rougelike Jumper";
        options.Size = new Vector2D<int>(1280, 720);
        window = Window.Create(options);

        window.Load += OnWindowLoad;
        window.Update += Update;
        window.Render += Render;

        window.Run();
    }

    public static void OnWindowLoad()
    {
        input = window.CreateInput();

        foreach (IMouse mouse in input.Mice)
        {
            mouse.Click += (IMouse cursor, MouseButton button, System.Numerics.Vector2 pos) => { };
            Console.WriteLine("Click");
        }
    }

    public static void Update(double d)
    {

    }

    public static void Render(double d)
    { 

    }
}