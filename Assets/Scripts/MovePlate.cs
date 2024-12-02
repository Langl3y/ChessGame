using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    GameObject reference = null;
    int matrixX;
    int matrixY;
    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        Game game = controller.GetComponent<Game>();

        // Check if the destination square is already occupied (unless it's an attack move)
        if (!attack && game.GetPosition(matrixX, matrixY) != null)
        {
            // Square is occupied, don't allow the move
            reference.GetComponent<Chessman>().DestroyMovePlates();
            Destroy(gameObject);
            return;
        }

        if (attack)
        {
            GameObject cp = game.GetPosition(matrixX, matrixY);
            if (cp != null)
            {
                if (cp.name == "white_king") game.Winner("black");
                if (cp.name == "black_king") game.Winner("white");
                Destroy(cp);
            }
        }

        // Update the board state
        if (reference != null)
        {
            // Clear the old position
            game.SetPositionEmpty(
                reference.GetComponent<Chessman>().GetXBoard(),
                reference.GetComponent<Chessman>().GetYBoard()
            );

            // Update piece position
            reference.GetComponent<Chessman>().SetXBoard(matrixX);
            reference.GetComponent<Chessman>().SetYBoard(matrixY);
            reference.GetComponent<Chessman>().SetCoords();

            // Set the new position
            game.SetPosition(reference);
        }

        // Clean up ALL move plates
        reference.GetComponent<Chessman>().DestroyMovePlates();

        // Switch turns
        game.NextTurn();

        // Destroy this move plate
        Destroy(gameObject);
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
