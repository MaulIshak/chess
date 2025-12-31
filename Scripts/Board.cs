using Godot;
using Godot.Collections;
using System;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class Board : Sprite2D
{
	public override void _Ready()
	{
		textureHolderScene = ResourceLoader.Load<PackedScene>("res://Scenes/texture_holder.tscn");
		piecesNode = GetNode<Node2D>("Pieces");
		pieceMoveTexture = ResourceLoader.Load<Texture2D>("res://Assets/Piece_move.png");
		LoadPieceTextures();
		InitBoard();

		DrawBoard();
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent)
		{
			if (mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed)
			{
				Vector2 mousePosition = GetGlobalMousePosition();
				if (IsMouseInsideBoard())
				{
					int row = (int)(-mousePosition.Y / TILE_SIZE);
					int col = (int)(mousePosition.X / TILE_SIZE);

					if (!isPieceSelected)
					{
						PieceType piece = board[row, col];
						if (piece != PieceType.EMPTY)
						{
							selectedPiecePosition = new Vector2(row, col);
							isPieceSelected = true;
							GD.Print($"Selected piece at ({row}, {col})");
							ShowAvailableMove();
						}
					}
					else 
					{
						Vector2 targetPosition = new Vector2(row, col);
						GD.Print($"Moving piece from ({selectedPiecePosition.X}, {selectedPiecePosition.Y}) to ({targetPosition.X}, {targetPosition.Y})");
						isPieceSelected = false;
						selectedPiecePosition = new Vector2(-1, -1);

					}
				}
				else
				{
					GD.Print("Clicked outside the board");
				}
			}
		}
	}

	public override void _Process(double delta)
	{
		return;
	}

}
