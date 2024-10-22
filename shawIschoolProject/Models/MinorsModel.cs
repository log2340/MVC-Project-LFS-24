namespace shawIschoolProject.Models
{
    public class MinorsModel
    {
        public List<UgMinors> UgMinors { get; set; }
        public string pageTitle { get; set; }
    }
        public class UgMinors
        {
            public string name { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public List<string> courses { get; set; }
            public string note { get; set; }
            public string pageTitle { get; set; }

        }

    }

