public class SaveGame
{
    public void Save()
    {
        var progressSave = new SaveProgressSystem();
        var settingsSave = new SaveSettingsSystem();
        
        progressSave.Save();
    }
}