namespace ProductManagementSystemTest.Model
{
    public class Categories
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public object Products { get; internal set; }
    }
}
