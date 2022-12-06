namespace BasicWebApplication.Models
{
    public interface IAmpRepo
    {
        List<IAmp> Amps { get; protected set; }
        IAmp GetAmpById(int id);
        void AddAmp(IAmp amp);
        void RemoveAmp(IAmp a);
    }

    public class AmpRepo : IAmpRepo
    {
        public List<IAmp> Amps { get; set; }

        public AmpRepo()
        {
            Amps = new List<IAmp>()
            {
                new Amp(),
                new Amp("Fender Ultimate Chorus"),
                new Amp("Marshell JCM 900")
            };

        }
        public IAmp GetAmpById(int id)
        {
            return Amps.Where(d => d.ID == id).First();
        }

        public void AddAmp(IAmp a)
        {
            this.Amps.Add(a);
        }

        public void RemoveAmp(IAmp a)
        {
            this.Amps.Remove(a);
        }
    }
}
