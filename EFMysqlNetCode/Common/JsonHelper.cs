using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Json.Net;

namespace EFMysqlNetCode.Common
{
    public static partial class JsonHelper 
    {
        public static JsonConverter<DateTime> dateConverter = new JsonConverter<DateTime>(
        dt => dt.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
        s => DateTime.ParseExact(s, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
 
    }
}
