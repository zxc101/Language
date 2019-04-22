﻿using System.Collections.Generic;
using UnityEngine;

using Chess.Configuration;
using Chess.Enums;

namespace Chess.Errors
{
    public class BishopError : AbstractFigureAbleJumpError
    {
        internal BishopError(Position startPosition, Position endPosition) : base(startPosition, endPosition)
        {
            ErrorMove();
        }

        internal override List<string> GetError() => Errors;

        protected override void ErrorMove()
        {
            if (Mathf.Abs(startPos.x - endPos.x) - Mathf.Abs(startPos.z - endPos.z) == 0)
            {
                if (startColor == endColor)
                {
                    switch (endTepe)
                    {
                        case EFigureType.Bishop:
                            Errors.Add($"{name} не может атаковать своего слона");
                            break;
                        case EFigureType.King:
                            Errors.Add($"{name} не может атаковать своего короля");
                            break;
                        case EFigureType.Knight:
                            Errors.Add($"{name} не может атаковать своего коня");
                            break;
                        case EFigureType.Pown:
                            Errors.Add($"{name} не может атаковать свою пешку");
                            break;
                        case EFigureType.Queen:
                            Errors.Add($"{name} не может атаковать свою королеву");
                            break;
                        case EFigureType.Rock:
                            Errors.Add($"{name} не может атаковать свою ладью");
                            break;
                    }
                }
            }
            else
            {
                if (endColor == EFigureColor.None)
                {
                    Errors.Add($"{name} не может так ходить");
                }
                else
                {
                    Errors.Add($"{name} не может так атаковать");
                }
            }
        }
    }
}
