﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services.Configuration
{
    public static class ConfigurationProvider
    {
        public static string CpuSettingsFile { get; } = ConfigurationManager.AppSettings["CpuSettingsFile"] ?? "cpu.config";
    }
}
