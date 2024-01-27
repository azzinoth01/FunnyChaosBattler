public enum TypeEnum
{

    Fire = 0,
    Water = 1,
    Earth = 2,
    None = 3
}

public static class Extension
{
    public static float GetTypeMultiplier(this TypeEnum type, TypeEnum attackType)
    {
        if (type == TypeEnum.None || type == attackType)
        {
            return 1;
        }

        TypeEnum leftCheck = attackType - 1;
        TypeEnum rightCheck = attackType + 1;
        if (rightCheck == TypeEnum.None)
        {
            rightCheck = (TypeEnum)0;
        }
        if ((int)leftCheck == -1)
        {
            leftCheck = (TypeEnum)2;
        }
        if (type == leftCheck)
        {
            return 2;
        }
        else if (type == rightCheck)
        {
            return 0.5f;
        }


        return 1;
    }

}