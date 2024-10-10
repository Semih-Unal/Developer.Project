namespace LenaSoftware.Developer.Project.Models
{
    public class AddForm
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<FormField> FormFields { get; set; }
    }
}
