using System;

namespace BasicWebApplication.Models
{
    public class Amp : IAmp
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public bool PluggedIn { get; set; }
        public bool Powered { get; set; }

        public IKnob VolumeKnob { get; set; }
        public IKnob TrebleKnob { get; set; }
        public IKnob MiddleKnob { get; set; }
        public IKnob BassKnob { get; set; }

        protected static int ampCount;

        public Amp() : this("Line 6 - Spider") { }
        public Amp(string model)
        {
            ID = ampCount++;

            Model = model;
            PluggedIn = false;
            Powered = false;
            VolumeKnob = new Knob("Volume");
            TrebleKnob = new Knob("Treble");
            MiddleKnob = new Knob("Middle");
            BassKnob = new Knob("Bass");
        }

        public string About()
        {
            return $"[--{Model}--]" +
                $"\nPower Status: {PowerStatus()}." +
                $"\n{VolumeKnob.About()}" +
                $"\n{TrebleKnob.About()}" +
                $"\n{MiddleKnob.About()}" +
                $"\n{BassKnob.About()}\n";
        }

        public void TogglePower()
        {

            if (Powered == false)
            {
                Powered = true;
            }
            else
            {
                Powered = false;
            }

        }
        public string PowerStatus()
        {
            if (Powered == true)
            {
                return "On";
            }
            else
            {
                return "Off";
            }
        }
        public void Plug()
        {
            if (PluggedIn == false)
            {
                PluggedIn = true;
            }
            else if (Powered == false && PluggedIn == true)
            {
                PluggedIn = false;
            }
        }
        public virtual string PlugStatus()
        {
            if (PluggedIn == true) { return "Plugged In"; }
            else { return "Unplugged"; }
        }
    }
}
