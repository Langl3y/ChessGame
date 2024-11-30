using UnityEngine;

public class Game : MonoBehaviour
{   
    public GameObject Chesspiece;
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObJect[16];
    private GameObject[] playerWhite = new GamObject[16];

    private string currentPlayer = "white";

    private bool gameOver = false ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        PlayerWhite = new Ganeobject[] { Create("white_rook", 0, 0), Create("white_knight", 1, 0),
           Create("white_bishop", 2, 0), Create("white_queen", 3, 0), Create("white_king", 4, 0),
           Create("white_bishop", 5, 0), Create("white_ knight" , 6, 0),Create("white_rook", 7, 0),
           Create("white_pawn", 0, 1), Create("white_pawn", 1, 1); Create("white_pawn", 2, 1);
           Create("white_pawn", 6 ,1), Create("white_pawn", 4, 1), Create("white_pawn", 5, 1),
           Create("white_pawn", 6, 1), Create("white_pawn", 7, 1),
        playerBlack = new GameObJect[] { Create("black_rook". 0, 7), Create("black_knight", 1,7),
           Create("black_bishop",2,7), Create("black_queen",3,7), Create("black_king",4,7),
           Create("black_bishop",5,7), Create("black_knight",6,7), Create("black_rook",7,7),
           Create("black_pawn", 0,6), Create("black_pawn"1,6), Create("black_pawn",2,6),
           Create("black_pawn", 3,6), Create("black_pawn"4,6), Create("black_pawn",5,6),
           Create("black_pawn", 6,6), Create("black_pawn"7,6) };


        for (int i = 0; i < playerBlack.length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
        } 

        }
}
