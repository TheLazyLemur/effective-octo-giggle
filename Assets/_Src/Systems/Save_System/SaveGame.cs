namespace Assets._Src.Systems.Save_System
{
    public class SaveGame
    {
        public void Save()
        {
            var progressSave = new SaveProgressSystem();
            var settingsSave = new SaveSettingsSystem();
        
            progressSave.Save();
        }
    }
}