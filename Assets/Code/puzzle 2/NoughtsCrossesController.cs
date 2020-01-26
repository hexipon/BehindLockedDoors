using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoughtsCrossesController : MonoBehaviour
{
    private char turn = 'O';
    private bool finished = false;

    [SerializeField]
    private InteractableNoughtsCrosses[] interactableSlots = new InteractableNoughtsCrosses[9];

    [SerializeField]
    private InventoryItem noughtItem = null;
    [SerializeField]
    private GameObject crossPrefab = null;
    private char[] tiles = new char[9];

    public GameObject key;

    int[][] checkLines = new int[][] { new int[] { 0, 1, 2 },
                                       new int[] { 3, 4, 5 },
                                       new int[] { 6, 7, 8 },
                                       new int[] { 0, 3, 6 },
                                       new int[] { 1, 4, 7 },
                                       new int[] { 2, 5, 8 },
                                       new int[] { 0, 4, 8 },
                                       new int[] { 2, 4, 6 } };

    public static NoughtsCrossesController Instance { get; private set; } = null;
    public static InventoryItem GetNoughtPrefab()
    {
        return Instance.noughtItem;
    }
    public static GameObject GetCrossPrefab()
    {
        return Instance.crossPrefab;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        for (int i = 0; i < 9; i++)
        {
            tiles[i] = 'n'; // none (empty)
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTile(int tileIndex, char type)
    {
        if (finished)
        {
            return;
        }

        if (tileIndex >= 0 && tileIndex < 9)
        {
            if (type == turn)
            {
                tiles[tileIndex] = type;

                turn = (turn == 'X') ? 'O' : 'X';
            }
        }

        for (int line = 0; line < checkLines.Length; line++)
        {
            char checkType = tiles[checkLines[line][0]];
            if (checkType != 'n')
            {
                if (checkType == tiles[checkLines[line][1]] && checkType == tiles[checkLines[line][2]])
                {
                    Debug.Log("Winner is: " + checkType);
                    //key becomes visible on table
                    if (checkType == 'O')
                    {
                        key.SetActive(true);
                        finished = true;
                        Objective.Instance.AssignObjective(" ");
                        return;
                    }
                    else
                    {
                        RestartBoard();
                    }
                }
            }
        }

        if (BoardFull())
        {
            RestartBoard();
            turn = 'O';
        }
        else if (turn == 'X')
        {
            // AI here!

            OpponentUpdate();
            //turn = 'O';
        }
    }

    private void OpponentUpdate()
    {
        // If there are 2 'X's in a row, get the third and win
        for (int line = 0; line < checkLines.Length; line++)
        {
            int checkCount = 0;
            int notCross = 0;
            bool emptySpace = false;
            for (int i = 0; i < 3; i++)
            {
                if (tiles[checkLines[line][i]] == 'X')
                {
                    checkCount++;
                }
                else if (tiles[checkLines[line][i]] == 'n')
                {
                    notCross = i;
                    emptySpace = true;
                }
            }

            if (checkCount == 2 && emptySpace)
            {
                interactableSlots[checkLines[line][notCross]].AddCrossTile();
                line = checkLines.Length;

                return;
            }
        }

        // If there are 2 'O's in a row, block the third to prevent the player winning
        for (int line = 0; line < checkLines.Length; line++)
        {
            int checkCount = 0;
            int notNought = 0;
            bool emptySpace = false;
            for (int i = 0; i < 3; i++)
            {
                if (tiles[checkLines[line][i]] == 'O')
                {
                    checkCount++;
                }
                else if (tiles[checkLines[line][i]] == 'n')
                {
                    notNought = i;
                    emptySpace = true;
                }
            }

            if (checkCount == 2 && emptySpace)
            {
                // There are 2 'X's in a row, get the third and win
                interactableSlots[checkLines[line][notNought]].AddCrossTile();
                line = checkLines.Length;

                return;
            }
        }

        // Yoink center tile if it's free
        if (tiles[4] == 'n')
        {
            interactableSlots[4].AddCrossTile();

            return;
        }

        // Grab a random corner tile
        {
            int emptyCount = 0;
            for (int i = 0; i < 9; i += 2)
            {
                if (tiles[i] == 'n')
                {
                    emptyCount++;
                }
            }

            if (emptyCount > 0)
            {
                int choice = Random.Range(0, emptyCount);
                int j = 0;

                for (int i = 0; i < 9; i += 2)
                {
                    if (tiles[i] == 'n')
                    {
                        if (j == choice)
                        {
                            interactableSlots[i].AddCrossTile();

                            return;
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
            }
        }

        // Grab a random edge tile
    }

    private bool BoardFull()
    {
        bool foundSpace = false;

        int i = 0;
        while (i < 9 && !foundSpace)
        {
            if (tiles[i] == 'n')
            {
                foundSpace = true;
            }

            i++;
        }

        return !foundSpace;
    }

    public bool PlayerTurn()
    {
        return (turn == 'O');
    }

    private void RestartBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            if (tiles[i] == 'X')
            {
                // Remove tile from board
                tiles[i] = 'n';
                interactableSlots[i].Restart();
            }
            else if (tiles[i] == 'O')
            {
                // Remove tile from board, and add it to inventory
                tiles[i] = 'n';
                interactableSlots[i].Restart();

                Inventory.Instance.AddItem(noughtItem);
            }
        }
    }
}
