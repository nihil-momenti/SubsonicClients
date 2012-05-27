using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class ChatMessage {
        public string Username { get; set; }
        public string Time { get; set; }
        public string Message { get; set; }
    }
}
