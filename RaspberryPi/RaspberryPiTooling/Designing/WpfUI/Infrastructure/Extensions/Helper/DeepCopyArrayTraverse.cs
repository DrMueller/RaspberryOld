﻿using System;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.Extensions.Helper
{
    internal class DeepCopyArrayTraverse
    {
        private readonly int[] _maxLengths;

        public DeepCopyArrayTraverse(Array array)
        {
            _maxLengths = new int[array.Rank];
            for (var i = 0; i < array.Rank; ++i)
            {
                _maxLengths[i] = array.GetLength(i) - 1;
            }

            Position = new int[array.Rank];
        }

        #region Properties

        public int[] Position { get; set; }

        #endregion

        #region Public/Internal Methods

        public bool Step()
        {
            for (var i = 0; i < Position.Length; ++i)
            {
                if (Position[i] < _maxLengths[i])
                {
                    Position[i]++;
                    for (var j = 0; j < i; j++)
                    {
                        Position[j] = 0;
                    }

                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}