﻿//  This file is part of YamlDotNet - A .NET library for YAML.
//  Copyright (c) Antoine Aubry and contributors

//  Permission is hereby granted, free of charge, to any person obtaining a copy of
//  this software and associated documentation files (the "Software"), to deal in
//  the Software without restriction, including without limitation the rights to
//  use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
//  of the Software, and to permit persons to whom the Software is furnished to do
//  so, subject to the following conditions:

//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.

//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.

namespace YamlDotNet.Core
{
    /// <summary>
    /// Keeps track of the <see cref="Current"/> recursion level,
    /// and throws <see cref="MaximumRecursionLevelReachedException"/>
    /// whenever <see cref="Maximum"/> is reached.
    /// </summary>
    internal class RecursionLevel
    {
        public int Current { get; private set; }
        public int Maximum { get; }

        public RecursionLevel(int maximum)
        {
            Maximum = maximum;
        }

        /// <summary>
        /// Increments the <see cref="Current"/> recursion level,
        /// and throws <see cref="MaximumRecursionLevelReachedException"/>
        /// if <see cref="Maximum"/> is reached.
        /// </summary>
        internal void Increment()
        {
            Current++;
            if (Current >= Maximum)
            {
                throw new MaximumRecursionLevelReachedException();
            }
        }

        /// <summary>
        /// Increments the <see cref="Current"/> recursion level,
        /// and returns whether <see cref="Current"/> is still less than <see cref="Maximum"/>.
        /// </summary>
        internal bool TryIncrement()
        {
            Current++;
            return Current < Maximum;
        }

        internal void Decrement()
        {
            Current--;
        }
    }
}
