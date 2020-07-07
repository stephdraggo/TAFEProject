namespace Saving
{
    [System.Serializable]
    public class Data
    {
        //game variables that get saved
        public string playerName, checkPoint; //checkpoint not blocked out yet
        public int level;
        public float[] statusMaxValues, statusCurrentValues = new float[3]; //health mana stamina, does this make both 3 long?
        public float pX, pY, pZ, rX, rY, rZ, rW, currentExp, neededExp, maxExp; //position rotation experience

        //add customisation stats here
        public Data(Jim.Player player) //constructor, must have same name as class
        {
            playerName = player.name;
            level = player.level;
            checkPoint = player.checkPoint.name; //need checkpoints in player, why name??
            for (int i = 0; i < statusMaxValues.Length; i++) //health mana stamina
            {
                statusCurrentValues[i] = player.lifeForce[i].currentValue;
                statusMaxValues[i] = player.lifeForce[i].maxValue;
            }
            //position
            pX = player.transform.position.x;
            pY = player.transform.position.y;
            pZ = player.transform.position.z;
            //rotation
            rX = player.transform.rotation.x;
            rY = player.transform.rotation.y;
            rZ = player.transform.rotation.z;
            rW = player.transform.rotation.w;
            //experience
            currentExp = player.currentExp;
            neededExp = player.neededExp;
            maxExp = player.maxExp;
        }
    }
}