using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class Settings
    {
        [PrimaryKey]
        public int SettingsID { get; set; }
        public bool IsVibrationActivated { get; set; }
    }
}
