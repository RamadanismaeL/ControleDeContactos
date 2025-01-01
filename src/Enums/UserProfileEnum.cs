using System.ComponentModel;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.Enums
{
    public enum UserProfileEnum
    {
        [Description("Administrator User")]
        Admin = 1,
        [Description("Pattern User")]
        Pattern = 0
    }
}