using System;
using System.Collections;
using System.Collections.Generic;

public class Stim{
    private int ant1, ant2, ant3, cons, fault;
    private bool trueAnswer;
    Random rand = new Random();
    public Stim() { 
        //decide if the stim will be true or false and generate stim
        trueAnswer = rand.Next(0, 29) % 2 == 0;
        //generate addition part (set ant1 and ant2 to random numbers until the result is < 9)
        do {
            ant1 = rand.Next(0, 9);
            ant2 = rand.Next(0, 9);
        }
        while (ant1 + ant2 > 9);
        cons = ant1 + ant2;
        //generate subtraction part (set ant3 to random numbers until the result is > 0)
        do ant3 = rand.Next(0, 9);
        while (cons - ant3 < 0);
        cons -= ant3;
        //if the stim is false, offset the consequent
        if (!trueAnswer) {
            do {
                int offset = rand.Next(1, 3);
                //if cons is even and will be greater than 0 after subtraction, subtract. else add
                cons = (cons % 2 == 0 && cons - offset > 0) ? cons - offset : cons + offset;
            }
            while (cons > 9);
        }
    }

    public bool getAnswer() {return trueAnswer;}
    override public string ToString() {return ant1.ToString() + "+" + ant2.ToString() + "-" + 
            ant3.ToString() + "=" + cons.ToString();}
}
