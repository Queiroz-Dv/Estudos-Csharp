namespace SetupApi.Business.Entities
{
    public class Course
    {
        public int Coding { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int UserCoding { get; set; }

        public virtual User User { get; set; }
    }
}
