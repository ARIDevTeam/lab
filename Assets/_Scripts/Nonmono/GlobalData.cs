using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData {
    //faults = number of wrong guesses
    //presentation cap = the length of the presentation sequence (ie, if it's 3 they'll be shown 3 numbers)
    //number of answers = the number of times they've put in answers for a sequence (reset when answer is right)
    //total faults = the total number of wrong answers the user input (never reset)
    public static int faults, presentationCap = 2, numberFailedTests, totalFailedTests, totalFaults;
    //currentSequence = the list of numbers shown to the user
    public static List<int> currentSequence;
    //tracks the user's time
    public static float elapsedTime;
}
