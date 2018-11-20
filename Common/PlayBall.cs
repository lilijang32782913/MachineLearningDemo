using System;
using static Common.PlyballEnums;

namespace Common
{
    public class Playball
    {
        public Outlook Outlook { get; set; }

        public Temperature Temperature { get; set; }

        public Humidity Humidity { get; set; }

        public Wind Wind { get; set; }

        public bool Play { get; set; }

        public Playball()
        {

        }

        public Playball(Outlook outlook, Temperature temperature, Humidity humidity, Wind wind,bool play)
        {
            this.Outlook = outlook;
            this.Temperature = temperature;
            this.Humidity = humidity;
            this.Wind = wind;
            this.Play = play;
        }
    }

    public class PlyballEnums
    {
        public enum Outlook
        {
            Sunny, Overcast, Rain
        }

        public enum Temperature { Hot, Mild, Cool }

        public enum Humidity { High, Normal }

        public enum Wind { Weak, Strong }
    }
}
