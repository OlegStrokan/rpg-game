using System;
using System.Collections.Generic;
using System.IO;


namespace Engine.Utils;

public static class FileData
{
    private static StreamReader reader;
    private static StreamWriter writer;
    public static List<string> data = new List<string>();
    public static string basePath = @"C:\Users\oleh.strokan\RiderProjects\rpg-game\User data\";

    public static List<string> ReadFromFile(string path)
    {
        try
        {
            if (!File.Exists(basePath + path))
            {
                File.Create(basePath + path);
            }
            reader = new StreamReader(basePath + path);

            while (reader.Peek() >= 0)
            {
                data.Add(reader.ReadLine());
            }


            reader.Close();
            return data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return data;
    }

    public static void WriteToFile(string data, string path = @"C:\Users\oleh.strokan\RiderProjects\rpg-game\User data\items.txt")
    {
        try
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            writer = new StreamWriter(path);
            writer.WriteLine(data);
            writer.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
           
        }
    }
  
}