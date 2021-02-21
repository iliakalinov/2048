
using UnityEngine;

[CreateAssetMenu(menuName = "Progress/ControllerProgress")]

public class Progress : ScriptableObject
{
    [SerializeField]
    private int maxCount;
    [SerializeField]
    private bool isGame = false;

    public void SetIsGame(bool states)
    {
        isGame = states;
    }
    public bool GetIsGame()
    {
        return isGame;
    }

    public void SetmaxCount(int Count)
    {
        maxCount = Count;
    }
    public int GetmaxCount()
    {
        return maxCount;
    }

}
