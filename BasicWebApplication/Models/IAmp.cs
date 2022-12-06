namespace BasicWebApplication.Models
{
    public interface IAmp : IAboutable
    {
        int ID { get; set; }
        string Model { get; }
        bool PluggedIn { get; }
        bool Powered { get; }
        IKnob VolumeKnob { get; set; }
        IKnob TrebleKnob { get; set; }
        IKnob MiddleKnob { get; set; }
        IKnob BassKnob { get; set; }

        void TogglePower();
        string PowerStatus();
        void Plug();
        string PlugStatus();

    }

    public interface IAboutable
    {
        string About();
    }
}
