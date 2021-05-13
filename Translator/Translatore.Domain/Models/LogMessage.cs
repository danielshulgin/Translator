using System;

namespace Translator.Domain.Models
{
    public class LogMessage : DomainObject
    {
        public string Text { get; private set; }

        public DateTime Time { get; private set; }
        

        public LogMessage(string text, DateTime time)
        {
            Text = text;
            Time = time;
        }
    }
}