namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public int money = 1;   
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        public SavesYG()
        {
            openLevels[1] = true;
        }
    }
}