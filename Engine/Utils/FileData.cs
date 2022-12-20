using System;
using System.IO;


namespace Engine.Utils;

public static class FileData
{
    private static StreamReader reader;
    private static StreamWriter writer;
    public static string data;
    
    public static string ReadFromFile(string path = @"C:\Users\oleh.strokan\RiderProjects\rpg-game\User data\items.txt")
    {
        try
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            reader = new StreamReader(path);
            
            data = reader.ReadLine();
            
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
           
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