using System;

namespace pt9
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (main game = new main())
                game.Run();
        }
    }
}
