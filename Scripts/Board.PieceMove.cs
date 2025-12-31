using Godot;
using Godot.Collections;
using System;
using System.Collections;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class Board : Sprite2D
{
    
    private Array<Vector2> GetMoves()
    {
        DrawPieceMoves();
        if (IsEnemyPiecePos(selectedPiecePosition))
        {
            GD.Print("Enemy");
        }
        else
        {
            GD.Print("Ally");
        }
        switch (board[(int)selectedPiecePosition.X, (int)selectedPiecePosition.Y])
        {
            case PieceType.WHITE_PAWN:
            case PieceType.BLACK_PAWN:
                GD.Print("Pawn");
                break;
            case PieceType.WHITE_ROOK:
            case PieceType.BLACK_ROOK:
                GD.Print("Rook");
                break;
            case PieceType.WHITE_KNIGHT:
            case PieceType.BLACK_KNIGHT:
                GD.Print("Knight");
                break;
            case PieceType.WHITE_BISHOP:
            case PieceType.BLACK_BISHOP:
                GD.Print("Bishop");
                break;
            case PieceType.WHITE_QUEEN:
            case PieceType.BLACK_QUEEN:
                GD.Print("Queen");
                break;
            case PieceType.WHITE_KING:
            case PieceType.BLACK_KING:
                GD.Print("King");
                break;
            default:
                GD.Print("No piece found");
                break;
        }
        return [];
    }

    private Array<Vector2> GetRookMoves()
    {
        Array<Vector2> moves = [];
        int row = (int)selectedPiecePosition.X;
        int col = (int)selectedPiecePosition.Y;

        // Up
        for (int r = row - 1; r >= 0; r--)
        {
            if (board[r, col] == PieceType.EMPTY)
            {
                moves.Add(new Vector2(r, col));
            }
            else
            {
                break;
            }
        }

        // Down
        for (int r = row + 1; r < BOARD_SIZE; r++)
        {
            if (board[r, col] == PieceType.EMPTY)
            {
                moves.Add(new Vector2(r, col));
            }
            else
            {
                break;
            }
        }

        // Left
        for (int c = col - 1; c >= 0; c--)
        {
            if (board[row, c] == PieceType.EMPTY)
            {
                moves.Add(new Vector2(row, c));
            }
            else
            {
                break;
            }
        }

        // Right
        for (int c = col + 1; c < BOARD_SIZE; c++)
        {
            if (board[row, c] == PieceType.EMPTY)
            {
                moves.Add(new Vector2(row, c));
            }
            else
            {
                break;
            }
        }

        return moves;
    }

    private bool IsValidPosition(Vector2 pos)
    {
        return pos.X >= 0 && pos.X < BOARD_SIZE && pos.Y >= 0 && pos.Y < BOARD_SIZE;
    }

    private bool IsEnemyPiecePos(Vector2 pos)
    {
        if (isWhiteTurn && board[(int)pos.X, (int)pos.Y] != PieceType.EMPTY)
        {
            return board[(int)pos.X, (int)pos.Y] >= PieceType.BLACK_PAWN && board[(int)pos.X, (int)pos.Y] <= PieceType.BLACK_KING;
        }
        else
        {
            return board[(int)pos.X, (int)pos.Y] <= PieceType.WHITE_KING && board[(int)pos.X, (int)pos.Y] >= PieceType.WHITE_PAWN;
        }
    }

}