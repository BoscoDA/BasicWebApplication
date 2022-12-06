using System.Runtime.Serialization;

namespace BasicWebApplication.Models
{
    public class Knob : IKnob
    {
        public int MaxSetting { get; set; }
        public int MinSetting { get; set; }
        public int Setting
        { get; set;
            //get { return Setting; }
            //set
            //{
            //    if(value >= MinSetting && value <= MaxSetting)
            //    {
            //        Setting = value;
            //    }
            //}
        }
        public string Function { get; set; }

        public Knob() : this("Volume") { }
        public Knob(string function)
        {
            MaxSetting = 10;
            MinSetting = 0;
            Setting = 0;
            Function = function;
        }

        public Knob(SerializationInfo info, StreamingContext context)
        {
            MaxSetting = info.GetInt32("Max Setting");
            MinSetting = info.GetInt32("Min Setting");
            Setting = info.GetInt32("Setting");
            Function = info.GetString("Function")!;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Max Setting", MaxSetting);
            info.AddValue("Min Setting", MinSetting);
            info.AddValue("Setting", Setting);
            info.AddValue("Function", Function);
        }

        public virtual void TurnKnobCounterClockwise(int howMuch = 1)
        {
            if (Setting > MinSetting & Setting - howMuch >= MinSetting)
            {
                Setting -= howMuch;
            }
            else if (Setting >= MinSetting & Setting - howMuch < MinSetting)
            {
                Setting = MinSetting;
            }
        }

        public virtual void TurnKnobClockwise(int howMuch = 1)
        {
            if ((Setting < MaxSetting) & ((Setting + howMuch) < MaxSetting && (Setting + howMuch) >= MinSetting))
            {
                Setting += howMuch;
            }
            else if (Setting <= MaxSetting & Setting + howMuch >= MaxSetting)
            {
                Setting = MaxSetting;
            }
        }

        public virtual int GetKnobSetting()
        {
            return this.Setting;
        }

        public virtual string About()
        {
            return $"{this.Function}: {GetKnobSetting()}.";
        }
    }
}
