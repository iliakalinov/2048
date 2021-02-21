using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private int width = 10;

    [SerializeField]
    private int length = 10;

    public GameObject Platform;
    public GameObject Camera;

    public GameObject BorderLift;
    public GameObject BorderBack;
    public GameObject BorderRight;
    public GameObject BorderEndGame;

    public GameObject Box;

    public void Start()
    {
        GenerateLevel(width, length);
        GenerateBox();
    }

    public void GenerateLevel()
    {
        GenerateLevel(width, length);
        GenerateBox();
    }

    public void GenerateLevel(float width, float length)//TODO
    {
        Platform.transform.localScale = new Vector3(width, 1, length);
        Platform.transform.position = new Vector3((width / 2 + .5f), 1, (length / 2 + .5f));

        BorderLift.transform.position = new Vector3(0.45f, 1.2f, (length / 2 + 0.5f));
        BorderLift.transform.localScale = new Vector3(.1f, 1f, length);

        BorderRight.transform.position = new Vector3(width + 0.55f, 1.2f, (length / 2 + 0.5f));
        BorderRight.transform.localScale = new Vector3(.1f, 1f, length);

        BorderBack.transform.position = new Vector3((width / 2 + 0.5f), 1.2f, (length / 2 + 1f) + length / 2 - 0.45f);
        BorderBack.transform.localScale = new Vector3(width, 1f, .1f);

        BorderEndGame.transform.position = new Vector3((width / 2 + 0.5f), 1.2f,0);
        BorderEndGame.transform.localScale = new Vector3(width, 1f, .1f);

        СhangePositionCamera(width, length);
    }

    public void GenerateBox()
    {
        for (int i = 1; i <= width; i++)
        {
            Instantiate(Box, new Vector3(i, 2, length), Quaternion.identity);
            Instantiate(Box, new Vector3(i, 2, length - 1), Quaternion.identity);
            Instantiate(Box, new Vector3(i, 2, length - 2), Quaternion.identity);
        }
    }

    public void СhangePositionCamera(float width, float length)//TODO bad position,not include Length 
    {
        Camera.transform.position = new Vector3(width / 2 + 0.05f, 13f, -8f);
    }

    public int GetWidth()
    {
        return width;
    }
    public int GetLengthh()
    {
        return length;
    }

}
