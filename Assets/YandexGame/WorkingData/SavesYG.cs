namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public bool[] openLevels = new bool[2];
        public int Currentlevel;

        public SavesYG()
        {
            openLevels[0] = true;
        }
    }
}