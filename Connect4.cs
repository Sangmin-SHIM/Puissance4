using System;
using System.Collections.Generic;
using System.Text;

namespace Puissance4
{
    class Connect4
    {
        // TODO : Compléter cette classe pour implémenter les règles du puissance 4
        // Etape 1

        private int colCount;
        private int lineCount;
        private int[,] game;
        private int playerNumber;
        private int occupe1;
        private int count;
        private int winner;
        private int currentX, currentY, currentX2, currentY2;
        private bool ended;


        public Connect4(int colcount, int linecount) {
            
            if(colcount<5 || linecount <5)
            {
                throw new ArgumentException("Veuillez saisir au moins (5,5) Grilles");
            }
            this.colCount = colcount;
            this.lineCount = linecount;
            this.game = new int[colcount,linecount];
            this.playerNumber = 1;
            this.occupe1 = LineCount - 1;
            this.count = 0;
            this.winner = 0;
            this.currentX = 0;
            this.currentY = 0;
            this.currentX2 = 0;
            this.currentY2 = 0;


            this.ended = false;
           
        }

        public int LineCount
        {
            get { return this.lineCount; }
        }
        public int ColCount => this.colCount;

        // Etape 2
        // TODO : Utiliser un tableau à deux dimensions
        public char GetPawn(int col, int line) { 

            if(game[col,line] == 1)
            {
                return 'O';
            }
            if(game[col,line] == 2)
            {
                return 'X';
            }
            else
            {
                return ' ';
            }
        
        }

        // Etape 3
        // Remplir la colonne jouée et changer de joueur
        public int PlayerNumber => this.playerNumber;
        public int Count => this.count;
    

        public int CurrentX => this.currentX;
        public int CurrentY => this.currentY;

        public int CurrentX2 => this.currentX2;
        public int CurrentY2 => this.currentY2;


        // Method Play - Main Method
        public void Play(int column)
        {
            
            this.occupe1 = this.lineCount - 1;
            this.count++;

            int total = ColCount * LineCount;

            Console.WriteLine($"{Count} Fois Essais sur {total}");

            /* Match Nul*/
            if (Count == total)
            {
                this.winner = 0;
                this.ended = true;
            }

            /* Checking if player already puts on*/
            while (game[column - 1, this.occupe1] == 1 || game[column - 1, this.occupe1] == 2) 
            {
                this.occupe1--;


                if (this.occupe1 < 0)
                {
                    Console.WriteLine("Vous ne pouvez plus mettre dans ce column");
                    return;
                }
            }


            if (this.playerNumber == 1)
               {  
               game[column - 1, this.occupe1] = 1;
                this.currentX = column-1;
                this.currentY = this.occupe1;

               Console.WriteLine($"Player {PlayerNumber} CurrentX : {CurrentX}, CurrentY : {CurrentY}");
                

                // Etape 4 
                // Améliorer le Play pour qu'il détecte la victoire/nul et implémenter Winner et Ended

                /*Vertical*/
                if (CurrentY<LineCount - 3
                    && game[CurrentX, CurrentY] ==1 
                    && game[CurrentX, CurrentY+1] == 1 
                    && game[CurrentX, CurrentY+2] == 1
                    && game[CurrentX, CurrentY+3] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 1");
                    this.ended = true;
                }

                /*Horizontal*/
                /*(1) CurrentX ==0 */
                if (game[0, CurrentY] ==1
                    && game[1, CurrentY] ==1
                    && game[2, CurrentY] ==1
                    && game[3, CurrentY] ==1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 2");
                    this.ended = true;
                }
                /*(2) CurrentX == ColCount-1 */
                else if (game[ColCount-1, CurrentY] ==1
                    && game[ColCount-2, CurrentY] ==1
                    && game[ColCount-3, CurrentY] ==1
                    && game[ColCount-4, CurrentY] ==1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 3");
                    this.ended = true;
                }
                /*(3) 0 < CurrentX < ColCount */
                else if  (CurrentX != ColCount-1
                    && CurrentX >2
                    && game[CurrentX-1, CurrentY] == 1
                    && game[CurrentX-2, CurrentY] == 1)
                {                     
                    if (game[CurrentX-3, CurrentY] ==1)
                    {
                        this.winner = 1;
                        Console.WriteLine("Case 4");
                        this.ended = true;
                    }
                    else if(game[CurrentX+1, CurrentY] ==1)
                    {
                        this.winner = 1;
                        Console.WriteLine("Case 5");
                        this.ended = true;
                    }

                }
                else if (CurrentX < ColCount - 3
                    && CurrentX > 0
                    && game[CurrentX + 1, CurrentY] == 1
                    && game[CurrentX + 2, CurrentY] == 1)
                {
                    if (game[CurrentX + 3, CurrentY] == 1)
                    {
                        this.winner = 1;
                        Console.WriteLine("Case 6");
                        this.ended = true;
                    }
                    else if (game[CurrentX - 1, CurrentY] == 1)
                    {
                        this.winner = 1;
                        Console.WriteLine("Case 7");
                        this.ended = true;
                    }

                }
                else if (CurrentX < ColCount - 2
                    && CurrentX > 1
                    && game[CurrentX + 1, CurrentY] == 1
                    && game[CurrentX - 1, CurrentY] == 1)
                {
                    if (game[CurrentX - 2, CurrentY] == 1)
                    {
                        this.winner = 1;
                        Console.WriteLine("Case 8");
                        this.ended = true;
                    }
                    else if (game[CurrentX + 2 , CurrentY] == 1)
                    {
                        this.winner = 1;
                        Console.WriteLine("Case 9");
                        this.ended = true;
                    }

                }


                /*Diagonal*/
                /*(1) CurrentX ==0 */


                /*Up + Right*/
                if (game[0, CurrentY] == 1
                    && CurrentY > 2
                    && game[1, CurrentY-1] ==1
                    && game[2, CurrentY-2] == 1
                    && game[3, CurrentY-3] == 1
                    )
                {
                    this.winner = 1;
                    Console.WriteLine("Case 10");
                    this.ended = true;
                }

                /*Down + Right*/
                else if (game[0, CurrentY] ==1
                    && CurrentY<LineCount-3 
                    && game[1, CurrentY + 1] == 1
                    && game[2, CurrentY + 2] == 1
                    && game[3, CurrentY + 3] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 11");
                    this.ended = true;
                }
                /*(2) CurrentX ==ColCount-1*/

                /*Up + Left*/
                else if(game[ColCount-1, CurrentY] ==1
                    && CurrentY >2
                    && game[ColCount-2, CurrentY-1]==1
                    && game[ColCount-3, CurrentY-2] ==1
                    && game[ColCount-4, CurrentY-3] ==1
                    )
                {
                    this.winner = 1;
                    Console.WriteLine("Case 12");
                    this.ended = true;
                }

                /*Down + Left*/
                else if (game[ColCount - 1, CurrentY] == 1
                && CurrentY < LineCount - 3
                && game[ColCount - 2, CurrentY + 1] == 1
                && game[ColCount - 3, CurrentY + 2] == 1
                && game[ColCount - 4, CurrentY + 3] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 13");
                    this.ended = true;
                }

                /*(3) CurrentX == 1 or 2*/
                /*Up + Right*/
                if (CurrentX == 1
                    && game[CurrentX, CurrentY] == 1
                    && CurrentY > 2
                    && game[CurrentX+1, CurrentY - 1] == 1
                    && game[CurrentX + 2, CurrentY - 2] == 1
                    && game[CurrentX + 3, CurrentY - 3] == 1
                    )
                {
                    this.winner = 1;
                    Console.WriteLine("Case 14");
                    this.ended = true;
                }

                /*Down + Right*/
                else if (CurrentX == 1
                    && game[CurrentX, CurrentY] == 1
                    && CurrentY < LineCount - 3
                    && game[CurrentX + 1, CurrentY + 1] == 1
                    && game[CurrentX + 2, CurrentY + 2] == 1
                    && game[CurrentX + 3, CurrentY + 3] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 15");
                    this.ended = true;
                }

                /*Up + Right*/
               else if (CurrentX == 2
                    && game[CurrentX, CurrentY] == 1
                    && CurrentY > 2
                    && game[CurrentX + 1, CurrentY - 1] == 1
                    && game[CurrentX + 2, CurrentY - 2] == 1
                    && game[CurrentX + 3, CurrentY - 3] == 1
                    )
                {
                    this.winner = 1;
                    Console.WriteLine("Case 16");
                    this.ended = true;
                }

                /*Down + Right*/
                else if (CurrentX == 2
                    && game[CurrentX, CurrentY] == 1
                    && CurrentY < LineCount - 3
                    && game[CurrentX + 1, CurrentY + 1] == 1
                    && game[CurrentX + 2, CurrentY + 2] == 1
                    && game[CurrentX + 3, CurrentY + 3] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 17");
                    this.ended = true;
                }

                /*(4) CurrentX == ColCount-2 or ColCount-3*/
                /*Up + Left*/
                else if (game[ColCount - 2, CurrentY] == 1
                    && CurrentY > 2
                    && game[ColCount - 3, CurrentY - 1] == 1
                    && game[ColCount - 4, CurrentY - 2] == 1
                    && game[ColCount - 5, CurrentY - 3] == 1
                    )
                {
                    this.winner = 1;
                    Console.WriteLine("Case 18");
                    this.ended = true;
                }

                /*Down + Left*/
                else if (game[ColCount - 2, CurrentY] == 1
                && CurrentY < LineCount - 3
                && game[ColCount - 3, CurrentY + 1] == 1
                && game[ColCount - 4, CurrentY + 2] == 1
                && game[ColCount - 5, CurrentY + 3] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 19");
                    this.ended = true;
                }

                /*Up + Left*/

                else if (game[ColCount - 3, CurrentY] == 1
                    && CurrentY > 2
                    && game[ColCount - 4, CurrentY - 1] == 1
                    && game[ColCount - 5, CurrentY - 2] == 1
                    && game[ColCount - 6, CurrentY - 3] == 1
                    )
                {
                    this.winner = 1;
                    Console.WriteLine("Case 20");
                    this.ended = true;
                }

                /*Down + Left*/
                else if (game[ColCount - 3, CurrentY] == 1
                && CurrentY < LineCount - 3
                && game[ColCount - 4, CurrentY + 1] == 1
                && game[ColCount - 5, CurrentY + 2] == 1
                && game[ColCount - 6, CurrentY + 3] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 21");
                    this.ended = true;
                }


                /*(5) 2 < CurrentX < ColCount-3*/
                /* Up + Right*/
                else if ( 2 < CurrentX && CurrentX < ColCount - 3
                    && game[CurrentX, CurrentY] == 1
                    && CurrentY > 2
                    && game[CurrentX + 1, CurrentY - 1] == 1
                    && game[CurrentX + 2, CurrentY - 2] == 1
                    && game[CurrentX + 3, CurrentY - 3] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 22");
                    this.ended = true;
                }
                /* Down + Right */
                else if (2 < CurrentX && CurrentX < ColCount - 3
                    && game[CurrentX, CurrentY] == 1
                    && CurrentY < LineCount - 3
                    && game[CurrentX + 1, CurrentY + 1] == 1
                    && game[CurrentX + 2, CurrentY + 2] == 1
                    && game[CurrentX + 3, CurrentY + 3] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 23");
                    this.ended = true;
                }
                /* Up + Left */
                else if (2 < CurrentX && CurrentX < ColCount - 3
                    && CurrentY > 2
                    && game[CurrentX - 1, CurrentY - 1] == 1
                    && game[CurrentX - 2, CurrentY - 2] == 1
                    && game[CurrentX - 3, CurrentY - 3] == 1
                    )
                {
                    this.winner = 1;
                    Console.WriteLine("Case 24");
                    this.ended = true;
                }
                /* Down + Left */
                else if (2 < CurrentX && CurrentX < ColCount - 3
                && CurrentY < LineCount - 3
                && game[CurrentX - 1, CurrentY + 1] == 1
                && game[CurrentX - 2, CurrentY + 2] == 1
                && game[CurrentX - 3, CurrentY + 3] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 25");
                    this.ended = true;
                }


                /* Up + Right 2nd Position */
                else if (CurrentX > 0 
                    && game[CurrentX, CurrentY] == 1
                    && CurrentY < LineCount-1
                    && CurrentY > 1
                    && game[CurrentX - 1, CurrentY + 1] == 1
                    && game[CurrentX + 1, CurrentY - 1] == 1
                    && game[CurrentX + 2, CurrentY - 2] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 26");
                    this.ended = true;
                }

                /* Up + Right 3rd Position */
                else if (CurrentX > 1
                    && game[CurrentX, CurrentY] == 1
                    && CurrentY < LineCount - 2
                    && CurrentY > 1
                    && game[CurrentX - 1, CurrentY + 1] == 1
                    && game[CurrentX - 2, CurrentY + 2] == 1
                    && game[CurrentX + 1, CurrentY - 1] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 27");
                    this.ended = true;
                }

                /* Down + Right 2nd Position */
                else if (CurrentX > 0
                    && game[CurrentX, CurrentY] == 1
                    && CurrentY < LineCount - 2
                    && CurrentY > 2
                    && game[CurrentX - 1, CurrentY - 1] == 1
                    && game[CurrentX + 1, CurrentY + 1] == 1
                    && game[CurrentX + 2, CurrentY + 2] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 28");
                    this.ended = true;
                }

                /* Down + Right 3rd Position */
                else if (CurrentX > 2
                    && game[CurrentX, CurrentY] == 1
                    && CurrentY < LineCount - 1
                    && CurrentY > 1
                    && game[CurrentX - 1, CurrentY - 1] == 1
                    && game[CurrentX - 2, CurrentY - 2] == 1
                    && game[CurrentX + 1, CurrentY + 1] == 1)
                {
                    this.winner = 1;
                    Console.WriteLine("Case 29");
                    this.ended = true;
                }


                /* Changing player for each Play ('O' -> 'X')*/
                this.playerNumber++;
               }

            else if (this.playerNumber == 2)
               {
                game[column - 1, this.occupe1] = 2;
                
                this.currentX2 = column - 1;
                this.currentY2 = this.occupe1;

                Console.WriteLine($"Player {PlayerNumber} CurrentX2 : {CurrentX2}, CurrentY2 : {CurrentY2}");


                // Etape 4 
                // Améliorer le Play pour qu'il détecte la victoire/nul et implémenter Winner et Ended

                /*Vertical*/
                if (CurrentY2 < LineCount - 3
                    && game[CurrentX2, CurrentY2] == 2
                    && game[CurrentX2, CurrentY2 + 1] == 2
                    && game[CurrentX2, CurrentY2 + 2] == 2
                    && game[CurrentX2, CurrentY2 + 3] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 1");
                    this.ended = true;
                }

                /*Horizontal*/
                /*(1) CurrentX ==0 */
                if (game[0, CurrentY2] == 2
                    && game[1, CurrentY2] == 2
                    && game[2, CurrentY2] == 2
                    && game[3, CurrentY2] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 2");
                    this.ended = true;
                }
                /*(2) CurrentX == ColCount-1 */
                else if (game[ColCount - 1, CurrentY2] == 2
                    && game[ColCount - 2, CurrentY2] == 2
                    && game[ColCount - 3, CurrentY2] == 2
                    && game[ColCount - 4, CurrentY2] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 3");
                    this.ended = true;
                }
                /*(3) 0 < CurrentX < ColCount */
                else if (CurrentX2 != ColCount - 1
                    && CurrentX2 > 2
                    && game[CurrentX2 - 1, CurrentY2] == 2
                    && game[CurrentX2 - 2, CurrentY2] == 2)
                {
                    if (game[CurrentX2 - 3, CurrentY2] == 2)
                    {
                        this.winner = 2;
                        Console.WriteLine("Case 4");
                        this.ended = true;
                    }
                    else if (game[CurrentX2 + 1, CurrentY2] == 2)
                    {
                        this.winner = 2;
                        Console.WriteLine("Case 5");
                        this.ended = true;
                    }

                }
                else if (CurrentX2 < ColCount - 3
                    && CurrentX2 > 0
                    && game[CurrentX2 + 1, CurrentY2] == 2
                    && game[CurrentX2 + 2, CurrentY2] == 2)
                {
                    if (game[CurrentX2 + 3, CurrentY2] == 2)
                    {
                        this.winner = 2;
                        Console.WriteLine("Case 6");
                        this.ended = true;
                    }
                    else if (game[CurrentX2 - 1, CurrentY2] == 2)
                    {
                        this.winner = 2;
                        Console.WriteLine("Case 7");
                        this.ended = true;
                    }

                }
                else if (CurrentX2 < ColCount - 2
                    && CurrentX2 > 1
                    && game[CurrentX2 + 1, CurrentY2] == 2
                    && game[CurrentX2 - 1, CurrentY2] == 2)
                {
                    if (game[CurrentX2 - 2, CurrentY2] == 2)
                    {
                        this.winner = 2;
                        Console.WriteLine("Case 8");
                        this.ended = true;
                    }
                    else if (game[CurrentX2 + 2, CurrentY2] == 2)
                    {
                        this.winner = 2;
                        Console.WriteLine("Case 9");
                        this.ended = true;
                    }

                }


                /*Diagonal*/
                /*(1) CurrentX ==0 */


                /*Up + Right*/
                if (game[0, CurrentY2] == 2
                    && CurrentY2 > 2
                    && game[1, CurrentY2 - 1] == 2
                    && game[2, CurrentY2 - 2] == 2
                    && game[3, CurrentY2 - 3] == 2
                    )
                {
                    this.winner = 2;
                    Console.WriteLine("Case 10");
                    this.ended = true;
                }

                /*Down + Right*/
                else if (game[0, CurrentY2] == 2
                    && CurrentY2 < LineCount - 3
                    && game[1, CurrentY2 + 1] == 2
                    && game[2, CurrentY2 + 2] == 2
                    && game[3, CurrentY2 + 3] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 11");
                    this.ended = true;
                }
                /*(2) CurrentX ==ColCount-1*/

                /*Up + Left*/
                else if (game[ColCount - 1, CurrentY2] == 2
                    && CurrentY2 > 2
                    && game[ColCount - 2, CurrentY2 - 1] == 2
                    && game[ColCount - 3, CurrentY2 - 2] == 2
                    && game[ColCount - 4, CurrentY2 - 3] == 2
                    )
                {
                    this.winner = 2;
                    Console.WriteLine("Case 12");
                    this.ended = true;
                }

                /*Down + Left*/
                else if (game[ColCount - 1, CurrentY2] == 2
                && CurrentY2 < LineCount - 3
                && game[ColCount - 2, CurrentY2 + 1] == 2
                && game[ColCount - 3, CurrentY2 + 2] == 2
                && game[ColCount - 4, CurrentY2 + 3] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 13");
                    this.ended = true;
                }

                /*(3) CurrentX == 1 or 2*/
                /*Up + Right*/
                if (CurrentX2 == 1
                    && game[CurrentX2, CurrentY2] == 2
                    && CurrentY > 2
                    && game[CurrentX2 + 1, CurrentY2 - 1] == 2
                    && game[CurrentX2 + 2, CurrentY2 - 2] == 2
                    && game[CurrentX + 3, CurrentY - 3] == 2
                    )
                {
                    this.winner = 2;
                    Console.WriteLine("Case 14");
                    this.ended = true;
                }

                /*Down + Right*/
                else if (CurrentX2 == 1
                    && game[CurrentX2, CurrentY2] == 2
                    && CurrentY2 < LineCount - 3
                    && game[CurrentX2 + 1, CurrentY2 + 1] == 2
                    && game[CurrentX2 + 2, CurrentY2 + 2] == 2
                    && game[CurrentX2 + 3, CurrentY2 + 3] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 15");
                    this.ended = true;
                }

                /*Up + Right*/
                else if (CurrentX2 == 2
                     && game[CurrentX2, CurrentY2] == 2
                     && CurrentY2 > 2
                     && game[CurrentX2 + 1, CurrentY2 - 1] == 2
                     && game[CurrentX2 + 2, CurrentY2 - 2] == 2
                     && game[CurrentX2 + 3, CurrentY2 - 3] == 2
                     )
                {
                    this.winner = 2;
                    Console.WriteLine("Case 16");
                    this.ended = true;
                }

                /*Down + Right*/
                else if (CurrentX2 == 2
                    && game[CurrentX2, CurrentY2] == 2
                    && CurrentY2 < LineCount - 3
                    && game[CurrentX2 + 1, CurrentY2 + 1] == 2
                    && game[CurrentX2 + 2, CurrentY2 + 2] == 2
                    && game[CurrentX2 + 3, CurrentY2 + 3] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 17");
                    this.ended = true;
                }

                /*(4) CurrentX == ColCount-2 or ColCount-3*/
                /*Up + Left*/
                else if (game[ColCount - 2, CurrentY2] == 2
                    && CurrentY2 > 2
                    && game[ColCount - 3, CurrentY2 - 1] == 2
                    && game[ColCount - 4, CurrentY2 - 2] == 2
                    && game[ColCount - 5, CurrentY2 - 3] == 2
                    )
                {
                    this.winner = 2;
                    Console.WriteLine("Case 18");
                    this.ended = true;
                }

                /*Down + Left*/
                else if (game[ColCount - 2, CurrentY2] == 2
                && CurrentY2 < LineCount - 3
                && game[ColCount - 3, CurrentY2 + 1] == 2
                && game[ColCount - 4, CurrentY2 + 2] == 2
                && game[ColCount - 5, CurrentY2 + 3] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 19");
                    this.ended = true;
                }

                /*Up + Left*/

                else if (game[ColCount - 3, CurrentY2] == 2
                    && CurrentY2 > 2
                    && game[ColCount - 4, CurrentY2 - 1] == 2
                    && game[ColCount - 5, CurrentY2 - 2] == 2
                    && game[ColCount - 6, CurrentY2 - 3] == 2
                    )
                {
                    this.winner = 2;
                    Console.WriteLine("Case 20");
                    this.ended = true;
                }

                /*Down + Left*/
                else if (game[ColCount - 3, CurrentY2] == 2
                && CurrentY2 < LineCount - 3
                && game[ColCount - 4, CurrentY2 + 1] == 2
                && game[ColCount - 5, CurrentY2 + 2] == 2
                && game[ColCount - 6, CurrentY2 + 3] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 21");
                    this.ended = true;
                }


                /*(5) 2 < CurrentX < ColCount-3*/
                /* Up + Right*/
                else if (2 < CurrentX2 && CurrentX2 < ColCount - 3
                    && game[CurrentX2, CurrentY2] == 2
                    && CurrentY2 > 2
                    && game[CurrentX2 + 1, CurrentY2 - 1] == 2
                    && game[CurrentX2 + 2, CurrentY2 - 2] == 2
                    && game[CurrentX2 + 3, CurrentY2 - 3] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 22");
                    this.ended = true;
                }
                /* Down + Right */
                else if (2 < CurrentX2 && CurrentX2 < ColCount - 3
                    && game[CurrentX2, CurrentY2] == 2
                    && CurrentY2 < LineCount - 3
                    && game[CurrentX2 + 1, CurrentY2 + 1] == 2
                    && game[CurrentX2 + 2, CurrentY2 + 2] == 2
                    && game[CurrentX2 + 3, CurrentY2 + 3] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 23");
                    this.ended = true;
                }
                /* Up + Left */
                else if (2 < CurrentX2 && CurrentX2 < ColCount - 3
                    && CurrentY > 2
                    && game[CurrentX2 - 1, CurrentY2 - 1] == 2
                    && game[CurrentX2 - 2, CurrentY2 - 2] == 2
                    && game[CurrentX2 - 3, CurrentY2 - 3] == 2
                    )
                {
                    this.winner = 2;
                    Console.WriteLine("Case 24");
                    this.ended = true;
                }
                /* Down + Left */
                else if (2 < CurrentX2 && CurrentX2 < ColCount - 3
                && CurrentY2 < LineCount - 3
                && game[CurrentX2 - 1, CurrentY2 + 1] == 2
                && game[CurrentX2 - 2, CurrentY2 + 2] == 2
                && game[CurrentX2 - 3, CurrentY2 + 3] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 25");
                    this.ended = true;
                }


                /* Up + Right 2nd Position */
                else if (CurrentX2 > 0
                    && game[CurrentX2, CurrentY2] == 2
                    && CurrentY2 < LineCount - 1
                    && CurrentY2 > 1
                    && game[CurrentX2 - 1, CurrentY2 + 1] == 2
                    && game[CurrentX2 + 1, CurrentY2 - 1] == 2
                    && game[CurrentX2 + 2, CurrentY2 - 2] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 26");
                    this.ended = true;
                }

                /* Up + Right 3rd Position */
                else if (CurrentX2 > 1
                    && game[CurrentX2, CurrentY2] == 2
                    && CurrentY2 < LineCount - 2
                    && CurrentY2 > 1
                    && game[CurrentX2 - 1, CurrentY2 + 1] == 2
                    && game[CurrentX2 - 2, CurrentY2 + 2] == 2
                    && game[CurrentX2 + 1, CurrentY2 - 1] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 27");
                    this.ended = true;
                }

                /* Down + Right 2nd Position */
                else if (CurrentX2 > 0
                    && game[CurrentX2, CurrentY2] == 2
                    && CurrentY2 < LineCount - 2
                    && CurrentY2 > 2
                    && game[CurrentX2 - 1, CurrentY2 - 1] == 2
                    && game[CurrentX2 + 1, CurrentY2 + 1] == 2
                    && game[CurrentX2 + 2, CurrentY2 + 2] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 28");
                    this.ended = true;
                }

                /* Down + Right 3rd Position */
                else if (CurrentX2 > 2
                    && game[CurrentX2, CurrentY2] == 2
                    && CurrentY2 < LineCount - 1
                    && CurrentY2 > 1
                    && game[CurrentX2 - 1, CurrentY2 - 1] == 2
                    && game[CurrentX2 - 2, CurrentY2 - 2] == 2
                    && game[CurrentX2 + 1, CurrentY2 + 1] == 2)
                {
                    this.winner = 2;
                    Console.WriteLine("Case 29");
                    this.ended = true;
                }


                /* Changing player for each Play ('X' -> 'O')*/
                this.playerNumber--;
            }



        }
        // Etape 4 W
        // Améliorer le Play pour qu'il détecte la victoire/nul et implémenter Winner et Ended
        public int Winner => this.winner;

        public bool Ended => this.ended;
    }
}
