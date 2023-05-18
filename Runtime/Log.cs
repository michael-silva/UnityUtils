using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityUtils
{
    public enum LogLevel
    {
        Debug = 0,
        Info,
        Warning,
        Error,
        Success,
    }

    public class Log
    {
        private string[] messageTemplates = new[] {
        "<size=10><color=orange>DEBUG:</color></size> <size=12>{{message}}</size>",
        "<size=10><color=blue>Info:</color></size> <size=12>{{message}}</size>",
        "<size=12><color=yellow>Warning:</color></size> <size=15>{{message}}</size>",
        "<size=15><color=red>Error:</color></size> <size=17>{{message}}</size>",
        "<size=10><color=green>Success:</color></size> <size=12>{{message}}</size>",
    };
        private static Log _instance = new Log();

        private Log() { }

        private string FormatMessage(object message, LogLevel level)
        {
            string template = messageTemplates[(int)level];
            return template.Replace("{{message}}", message.ToString());
        }

        private void Print(object message, LogLevel level = LogLevel.Info)
        {
            string formattedMessage = FormatMessage(message, level);
            UnityEngine.Debug.Log(formattedMessage);
        }

        private static void Messages(LogLevel level = LogLevel.Info, params object[] messages)
        {
            foreach (var message in messages)
            {
                _instance.Print(message, level);
            }
        }

        public static void Debug(params object[] messages)
        {
            Messages(LogLevel.Debug, messages);
        }

        public static void Info(params object[] messages)
        {
            Messages(LogLevel.Info, messages);
        }

        public static void Warning(params object[] messages)
        {
            Messages(LogLevel.Warning, messages);
        }

        public static void Error(params object[] messages)
        {
            Messages(LogLevel.Error, messages);
        }

        public static void Success(params object[] messages)
        {
            Messages(LogLevel.Success, messages);
        }

    }
}