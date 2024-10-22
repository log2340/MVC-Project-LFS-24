namespace shawIschoolProject.Models
{
    public class DegreesModel
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public required List<Undergraduate> undergraduate { get; set; }
        public required List<Undergraduate> graduate { get; set; }
        public string pageTitle {  get; set; }

    }


    public class Undergraduate { 
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public required List<string> concentrations { get; set; }
        public List<string> availableCertificates { get; set; }
    }

    public class Graduate
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> conentrations { get; set; }
        public List<string> availableCertificates { get; set; }


    }

}
