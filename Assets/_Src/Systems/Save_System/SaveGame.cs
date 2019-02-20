public class SaveGame
{
    public void Save()
    {
        var progressSave = new SaveProgressSystem();
        var settingsSave = new SaveSettingsSystem();
        
        settingsSave.Save();
        progressSave.Save();
    }
}