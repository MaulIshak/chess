using Godot;
using Godot.Collections;
using System;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class Board : Sprite2D
{
    private void DrawBoard()
    {
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                PieceType piece = board[i, j];
                if (piece != PieceType.EMPTY)
                {
                    Sprite2D holder = textureHolderScene.Instantiate<Sprite2D>();
                    piecesNode.AddChild(holder);
                    holder.GlobalPosition = new Vector2(j * TILE_SIZE + (TILE_SIZE / 2), -i * TILE_SIZE - (TILE_SIZE / 2));
                    holder.Texture = pieceTextures[piece];
                }
            }
        }
    }

    private void ShowAvailableMove()
    {
        movesAvailable = GetMoves();
        DrawPieceMoves();
    }

    private void DrawPieceMoves()
    {
        for (int i = 0; i < movesAvailable.Count; i++)
        {
            Vector2 move = movesAvailable[i];
            Sprite2D holder = textureHolderScene.Instantiate<Sprite2D>();
            piecesNode.AddChild(holder);
            holder.GlobalPosition = new Vector2(move.Y * TILE_SIZE + (TILE_SIZE / 2), -move.X * TILE_SIZE - (TILE_SIZE / 2));
            holder.Texture = pieceMoveTexture;
        }
    }
    private Array<Vector2> GetMoves()
    {
        return [];
    }
    private void InitBoard()
    {
        board[0, 0] = PieceType.WHITE_ROOK;
        board[0, 1] = PieceType.WHITE_KNIGHT;
        board[0, 2] = PieceType.WHITE_BISHOP;
        board[0, 3] = PieceType.WHITE_QUEEN;
        board[0, 4] = PieceType.WHITE_KING;
        board[0, 5] = PieceType.WHITE_BISHOP;
        board[0, 6] = PieceType.WHITE_KNIGHT;
        board[0, 7] = PieceType.WHITE_ROOK;
        board[7, 0] = PieceType.BLACK_ROOK;
        board[7, 1] = PieceType.BLACK_KNIGHT;
        board[7, 2] = PieceType.BLACK_BISHOP;
        board[7, 3] = PieceType.BLACK_QUEEN;
        board[7, 4] = PieceType.BLACK_KING;
        board[7, 5] = PieceType.BLACK_BISHOP;
        board[7, 6] = PieceType.BLACK_KNIGHT;
        board[7, 7] = PieceType.BLACK_ROOK;
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            board[1, i] = PieceType.WHITE_PAWN;
            board[6, i] = PieceType.BLACK_PAWN;
        }

        // fill the empty
        for (int i = 2; i < 6; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                board[i, j] = PieceType.EMPTY;
            }
        }

    }

    private void LoadPieceTextures()
    {
        pieceTextures = new Dictionary<PieceType, Texture2D>
        {
            [PieceType.WHITE_PAWN] = ResourceLoader.Load<Texture2D>("res://Assets/white_pawn.png"),
            [PieceType.WHITE_BISHOP] = ResourceLoader.Load<Texture2D>("res://Assets/white_bishop.png"),
            [PieceType.WHITE_KNIGHT] = ResourceLoader.Load<Texture2D>("res://Assets/white_knight.png"),
            [PieceType.WHITE_ROOK] = ResourceLoader.Load<Texture2D>("res://Assets/white_rook.png"),
            [PieceType.WHITE_QUEEN] = ResourceLoader.Load<Texture2D>("res://Assets/white_queen.png"),
            [PieceType.WHITE_KING] = ResourceLoader.Load<Texture2D>("res://Assets/white_king.png"),
            [PieceType.BLACK_PAWN] = ResourceLoader.Load<Texture2D>("res://Assets/black_pawn.png"),
            [PieceType.BLACK_BISHOP] = ResourceLoader.Load<Texture2D>("res://Assets/black_bishop.png"),
            [PieceType.BLACK_KNIGHT] = ResourceLoader.Load<Texture2D>("res://Assets/black_knight.png"),
            [PieceType.BLACK_ROOK] = ResourceLoader.Load<Texture2D>("res://Assets/black_rook.png"),
            [PieceType.BLACK_QUEEN] = ResourceLoader.Load<Texture2D>("res://Assets/black_queen.png"),
            [PieceType.BLACK_KING] = ResourceLoader.Load<Texture2D>("res://Assets/black_king.png")
        };
    }
    private bool IsMouseInsideBoard()
    {
        return GetGlobalMousePosition().X >= 0 && GetGlobalMousePosition().X <= BOARD_SIZE * TILE_SIZE &&
               GetGlobalMousePosition().Y <= 0 && GetGlobalMousePosition().Y >= -BOARD_SIZE * TILE_SIZE;

    }

}