using UnityEngine;
public class TaskIndex {
    public static int[] index = new int[96] { 
        0,0,0,0,0,0,0,0,0,0,0,
        1,1,1,1,1,1,1,
        2,
        3,3,3,3,3,3,3,3,
        4,4,4,4,4,4,4,4,4,
        5,5,5,5,5,5,
        6,6,6,6,6,6,
        7,7,7,
        8,8,8,
        9,9,9,9,9,
        10,10,10,10,10,10,10,10,10,10,
        11,11,11,
        12,
        13,
        14,14,14,14,14,14,14,14,14,14,14,
        15,16,17,18,19,
        20,20,20,20,20,20,
    };

    public static int[,] taskNum = {
        { 2,3,3 },
        { 2,2,3 },
        { 2,1,1 },
        { 2,2,2 },

        { 3,4,5 },
        { 3,4,4 },
        { 3,3,4 },
        { 3,2,2 },
        
        { 4,4,4 },
        { 4,3,3 },
        { 3,3,3 },
        { 1,2,2 },
        
        { 1,2,3 },
        { 1,1,2 },
        { 1,1,1 },
        { 2,3,5 },
        
        { 2,4,5 },
        { 2,5,6 },
        { 4,5,6 },
        { 3,3,2 },

        { 2,3,4 },
    };

    public static int GetDiff(int taskType,int playerNum) {
        return taskNum[taskType,playerNum-3];
    }

    public static int GetTaskType(int taskID) { 
        return index[taskID];
    }
}