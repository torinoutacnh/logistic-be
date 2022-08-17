using FU.Domain.Entities.Form;

namespace API.Models.Form
{
    public class CreateFormModel
    {
        public FormInfo Info { get; set; }
        public string[] Labels { get; set; }
    }
}
