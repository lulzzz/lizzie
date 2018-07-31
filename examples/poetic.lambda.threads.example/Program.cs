﻿/*
 * Copyright (c) 2018 Thomas Hansen - thomas@gaiasoul.com
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using System;

namespace poetic.lambda.threads.example
{
    class MainClass
    {
        /// <summary>
        /// An example of how to use the Threads class to spawn of multiple threads,
        /// with some slightly simplified syntax.
        /// </summary>
        public static void Main()
        {
            /*
             * Creating our list of actions.
             */
            var actions = new Sequence();

            /*
             * Adding an Action to our list, making sure we're able to determine
             * if it was executed.
             */
            var shared1 = "not changed!";
            actions.Add(() => { shared1 = "1 was changed!"; });

            // Adding another Action to our list.
            var shared2 = "not changed!";
            actions.Add(() => { shared2 = "2 was changed!"; });

            /*
             * Creating a thread for each action, and waiting for all threads
             * to finish their work.
             */
            actions.JoinParallel();

            /*
             * Writing out results on Console.
             */
            Console.WriteLine(shared1);
            Console.WriteLine(shared2);

            // Waiting for user input.
            Console.Read();
        }
    }
}
