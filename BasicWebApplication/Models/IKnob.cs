namespace BasicWebApplication.Models
{
        public interface IKnob : IAboutable
        {
            int MaxSetting { get; }
            int MinSetting { get; }
            int Setting { get; }
            string Function { get; }
            void TurnKnobClockwise(int howMuch = 1);
            void TurnKnobCounterClockwise(int howMuch = 1);
            int GetKnobSetting();
        }
}
