using System.ComponentModel;

namespace controleDeContactos.src.Enums
{
    public enum StatusTask
    {
        [Description("To Do")]
        ToDO = 1,
        [Description("In Progress")]
        InProgress = 2,
        [Description("Completed")]
        Completed = 3
    }
}