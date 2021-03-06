﻿using System.Collections.Generic;
using UnityEngine;

using Chess.Configuration;
using Chess.Enums;

namespace Chess.Errors
{
    public class QueenError : AbstractFigureAbleJumpError
    {
        internal QueenError(Position startPosition, Position endPosition) : base(startPosition, endPosition)
        {
            ErrorMove();
        }

        internal override List<string> GetError() => Errors;

        protected override void ErrorMove()
        {
            if (Mathf.Abs(startPos.x - endPos.x) - Mathf.Abs(startPos.z - endPos.z) == 0 ||
                startPos.x == endPos.x && startPos.z != endPos.z ||
                startPos.x != endPos.x && startPos.z == endPos.z)
            {
                if (startColor == endColor)
                {
                    switch (endTepe)
                    {
                        case EFigureType.Bishop:
                            Errors.Add($"{name} отказывается атаковать своего слона");
                            break;
                        case EFigureType.King:
                            Errors.Add($"{name} верна своему королю");
                            break;
                        case EFigureType.Knight:
                            Errors.Add($"{name} отказывается атаковать своего коня");
                            break;
                        case EFigureType.Pown:
                            Errors.Add($"{name} отказывается атаковать свою пешку");
                            break;
                        case EFigureType.Rock:
                            Errors.Add($"{name} отказывается атаковать свою ладью");
                            break;
                    }
                }
            }
            else
            {
                if (endColor == EFigureColor.None)
                {
                    Errors.Add($"Королева не может так ходить");
                }
                else
                {
                    Errors.Add($"Королева не может так атаковать");
                }
            }
        }
    }
}