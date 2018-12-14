using UnityEngine;

public static class GameUtilities
{
	public static bool GetRandomRoll(int _chance)
    {
        return _chance > Random.Range(0, 100);
    }
}
