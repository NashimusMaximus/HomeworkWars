using System;
/// <summary>
/// Zach Darrow | Caleb Fraser | Matt Cooley | Nash Lyke
/// The Main
/// 
/// </summary>
namespace GUI
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
