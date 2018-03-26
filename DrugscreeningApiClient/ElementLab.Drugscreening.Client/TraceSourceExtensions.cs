﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Json = Newtonsoft.Json;

namespace ElementLab
{
    internal static class TraceSourceExtensions
    {
        /// <summary>
        /// Записывает отладочное сообщение в журнал
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Текст сообщения</param>
        /// <param name="data">Данные</param>
        public static void Verbose(this TraceSource logger, string message, object data = null)
        {
            logger.Write(TraceEventType.Verbose, 0, message, data);
        }

        /// <summary>
        /// Записывает информационное сообщение в журнал
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Текст сообщения</param>
        /// <param name="data">Данные</param>
        public static void Info(this TraceSource logger, string message, object data = null)
        {
            logger.Write(TraceEventType.Information, 0, message, data);
        }

        /// <summary>
        /// Записывает предупреждающее сообщение в журнал
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Текст сообщения</param>
        /// <param name="data">Данные</param>
        public static void Warn(this TraceSource logger, string message, object data = null)
        {
            logger.Write(TraceEventType.Warning, 0, message, data);
        }

        /// <summary>
        /// Записывает сообщение об ошибке в журнал
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Текст сообщения</param>
        /// <param name="data">Данные</param>
        public static void Error(this TraceSource logger, string message, object data = null)
        {
            logger.Write(TraceEventType.Error, 0, message, data);
        }

        /// <summary>
        /// Записывает сообщение о критической ошибке в журнал
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Текст сообщения</param>
        /// <param name="data">Данные</param>
        public static void Fatal(this TraceSource logger, string message, object data = null)
        {
            logger.Write(TraceEventType.Critical, 0, message, data);
        }

        public static void Write(this TraceSource source, TraceEventType eventType, string message, object data = null)
        {
            source.Write(eventType, 0, message, data);
        }

        static void Write(this TraceSource source, TraceEventType eventType, int eventId, string message, object data)
        {
            if (data == null)
            {
                source.TraceEvent(eventType, eventId, message);
            }
            else
            {
                var dataJson = Json.JsonConvert.SerializeObject(data, _serializationSettings);
                source.TraceData(eventType, eventId, message, dataJson);
            }
        }

        public static MonitoredScope Monitor(this TraceSource source, string message)
        {
            return new MonitoredScope(source, message);
        }

        static readonly Json.JsonSerializerSettings _serializationSettings = new Json.JsonSerializerSettings()
        {
            NullValueHandling = Json.NullValueHandling.Ignore,
            Converters = { new Json.Converters.StringEnumConverter() },
            DateFormatString = "yyyy-MM-dd",
            DateTimeZoneHandling = Json.DateTimeZoneHandling.Local,
            Formatting = Json.Formatting.None
        };

        internal class MonitoredScope : IDisposable
        {
            Action _dispose;

            public MonitoredScope(TraceSource trace, string message)
            {
                var sw = new Stopwatch();
                var beginMessage = $"Begin [{message}]";
                trace.TraceEvent(TraceEventType.Verbose, 0, beginMessage);
                sw.Start();
                _dispose = () =>
                {
                    sw.Stop();
                    var endMessage = $"Completed [{message}]. Time elapsed {sw.ElapsedMilliseconds} ms.";
                    trace.TraceEvent(TraceEventType.Verbose, 0, endMessage);
                };
            }

            public void Dispose()
            {
                if (_dispose != null)
                {
                    _dispose();
                    _dispose = null;
                }
                GC.SuppressFinalize(this);
            }
        }

    }
}