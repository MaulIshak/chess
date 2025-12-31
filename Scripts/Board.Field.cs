using Godot;
using Godot.Collections;
using System;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class Board : Sprite2D
{
    enum PieceType
    {
        EMPTY,
        BLACK_PAWN,
        BLACK_BISHOP,
        BLACK_KNIGHT,
        BLACK_ROOK,
        BLACK_QUEEN,
        BLACK_KING,
        WHITE_PAWN,
        WHITE_BISHOP,
        WHITE_KNIGHT,
        WHITE_ROOK,
        WHITE_QUEEN,
        WHITE_KING
    }
    private bool isPieceSelected;
    const int BOARD_SIZE = 8;
    const float TILE_SIZE = 22f;
    private Dictionary<PieceType, Texture2D> pieceTextures;
    private PieceType[,] board = new PieceType[BOARD_SIZE, BOARD_SIZE];
    private Node2D piecesNode;
    private PackedScene textureHolderScene;
    private bool isWhiteTurn = true;
    private Array<Vector2> movesAvailable = [];
    private Vector2 selectedPiecePosition = new(-1, -1);
    private Texture2D pieceMoveTexture;

    private Node2D dots;
}