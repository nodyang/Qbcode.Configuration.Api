﻿using BeetleX.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qbcode.Configuration.Api.Models
{
    public class SettingModel
    {
        public LogType LogLevel { get; set; } = LogType.Error;
        public bool LogConsole { get; set; } = true;
        public int LogCacheSize { get; set; } = 0;
        public bool AutoGzip { get; set; } = false;
        public int BufferPoolSize { get; set; } = 0;
        public int BufferSize { get; set; } = 0;
        public bool OutputServerAddress { get; set; } = false;
        public bool StatisticsEnabled { get; set; } = false;
        public string StatisticsExts { get; set; } = string.Empty;

        public int MaxConnections { get; set; } = 0;
        public int MaxWaitQueue { get; set; } = 0;
        public int MaxBodyLength { get; set; } = 0;

        public string NoGzipFiles { get; set; } = string.Empty;
    }
}
