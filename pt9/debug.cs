using System;
using System.IO;

namespace pt9
{
    public static class debug
    {
        public static async void write_characters(String error)
        {
            using (StreamWriter writer = File.CreateText("log.txt"))
            {
                await writer.WriteLineAsync(error);
            }
        }
    }
}