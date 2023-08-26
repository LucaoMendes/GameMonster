

using UnityEngine;

public class Logger
{
    private static string FormatMessage(string message, string type){
        string actualTime = System.DateTime.Now.ToString("HH:mm:ss");
        return "[" + actualTime + "] " + type + ": " + message;
    }

    private static void Log(string message, string type = null){
        if(type == null)
            type = "INFO";
            
        if(type.Equals("WARN"))
            Debug.LogWarning(FormatMessage(message, type));
        else if(type.Equals("ERROR"))
            Debug.LogError(FormatMessage(message, type));
        else
            Debug.Log(FormatMessage(message, type));
    }

    private static void Warn(string message){
        Log(message, "WARN");
    }

    private static void Error(string message){
        Log(message, "ERROR");
    }

    public static void Info(string message){
        Log(message);
    }
}
