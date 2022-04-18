using UnityEngine;

namespace com.sail.gamelogger
{
    public static class Gamelogger
    {
        public static void onEvent(string eventName)
        {
            using (var gamelogger = new AndroidJavaObject("com.sail.gamelogger.Gamelogger"))
            {
                gamelogger.CallStatic("onEvent", eventName);
            } 
        }
    }
}
