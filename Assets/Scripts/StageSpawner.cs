using UnityEngine;
using System.Collections;

public class StageSpawner : MonoBehaviour {

	[SerializeField] GameObject HardBlock;
    [SerializeField] GameObject SoftBlock;
	[SerializeField] GameObject FloorA;
	[SerializeField] GameObject FloorB;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject EnemyA;
    [SerializeField] GameObject FireUp;
    [SerializeField] GameObject SpeedUp;
    [SerializeField] GameObject BombUp;
    bool createOnce;
    bool createOncePlayer;
    bool createOnceEnemyA;
    bool playerPos;
	float positionX;
    float positionY;
    float positionZ;
    float lastBuild;
    int firstWidth;
    int sideWidth;
    int howBig;
    int posZ;
    int a;
    int b;
    int y;
    int placeSB;
    int placePU;
    int enemyACounter;

    // Use this for initialization
    void Start () {
        positionY = 1;
        firstWidth = 19;
        sideWidth = firstWidth - 10;
        howBig = 9;

	}
	
	// Update is called once per frame
	void Update () {
        if (!createOnce)
        {
            //FLOOR
            while(y != howBig)
            {
                for (int x = 0; x < firstWidth; x++)
                {
                    if (x % 2 == posZ)
                    {
                        Instantiate(FloorA, new Vector3(positionX, 0, positionZ), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(FloorB, new Vector3(positionX, 0, positionZ), Quaternion.identity);
                    }
                    positionX += 1f;
                }
                y++;
                positionZ += 1f;
                positionX = 0;
                if(posZ == 0)
                {
                    posZ = 1;
                }
                else
                {
                    posZ = 0;
                }
            }

            //HARD BLOCKS BARRIER
            //TOP
            positionZ -= 1f;
            for (int x = 0; x < firstWidth; x++)
            {
                Instantiate(HardBlock, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                positionX += 1f;
            }

            //BOTTOM
            positionX = 0;
            positionZ = 0;
            for (int x = 0; x < firstWidth; x++)
            {
                Instantiate(HardBlock, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                positionX += 1f;
            }

            //LEFT
            positionX -= 1f;
            for (int x = 0; x < sideWidth; x++)
            {
                Instantiate(HardBlock, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                positionZ += 1f;
            }

            //RIGHT
            positionX = 0;
            positionZ = 0;
            for (int x = 0; x < sideWidth; x++)
            {
                Instantiate(HardBlock, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                positionZ += 1f;
            }

            positionX = 2;
            positionZ = 1;
            ////HARD BLOCKS ON PLAYER
            while (a != howBig)
            {
                for (int x = 0; x < firstWidth; x++)
                {
                    if (x / 2 != 0 || posZ / 2 != 0)
                    {
                        if (x % 2 == posZ + 1)
                        {
                            Instantiate(HardBlock, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                        }
                        positionX += 1f;
                    }

                }
                a++;
                positionZ += 1f;
                positionX = 1f;
                if (posZ == 0)
                {
                    posZ = 1;
                }
                else
                {
                    posZ = 0;
                }

            }

            //SOFT BLOCKS
            positionX = 1;
            positionZ = 1;
            while (b != howBig - 2)
            {
                for (int x = 0; x < firstWidth; x++)
                {
                    placeSB = Random.Range(1, 10);
                    placePU = Random.Range(1, 10);
                    if (x / 2 != 0)
                    {
                        if ((x % 2 == posZ) &&
                            (placeSB == 1 || placeSB == 2 || placeSB == 7))
                        {
                            Instantiate(SoftBlock, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                            if (placePU == 2)
                            {
                                Instantiate(BombUp, new Vector3(positionX, positionY, positionZ), Quaternion.Euler(0, 180, 0));
                            }

                        }
                        else if (x % 2 != posZ && (placeSB == 3 || placeSB == 4
                            || placeSB == 5 || placeSB == 8))
                        {
                            Instantiate(SoftBlock, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                            if (placePU == 5)
                            {
                                Instantiate(FireUp, new Vector3(positionX, positionY, positionZ), Quaternion.Euler(0, 180, 0));
                            }
                            else if(placePU == 8)
                            {
                                Instantiate(SpeedUp, new Vector3(positionX, positionY, positionZ), Quaternion.Euler(0, 180, 0));
                            }
                        }
                        else if (!createOncePlayer)
                        {
                            Instantiate(Player, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                            createOncePlayer = true;
                        }
                        else
                        {
                            if (!createOnceEnemyA && x > firstWidth - 3 && (x % 2 == posZ && (placeSB == 2 || placeSB == 3 || placeSB == 4
                            || placeSB == 5 || placeSB == 8)))
                            {
                                Instantiate(EnemyA, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                                enemyACounter++;
                                createOnceEnemyA = true;
                            }
                        }

                        positionX += 1f;
                        createOnceEnemyA = false;
                    }

                }
                b++;
                positionZ += 1f;
                positionX = 1f;
                if (posZ == 0)
                {
                    posZ = 1;
                }
                else
                {
                    posZ = 0;
                }

            }
        }
    createOnce = true;
	}
		
}

