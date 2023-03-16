using System.Collections;
using System.Collections.Generic;
using Clingo;
using UnityEngine;

public class LightLevelHandler : ASPLevelHandler
{
    [SerializeField] LightGenerator generator;
    [SerializeField] MapPixel wallMap, pathMap, mirrorMap;
    [SerializeField] MapKeyPixel wallMapKey, pathMapKey, mirrorMapKey;

    // Start is called before the first frame update
    void Start()
    {
        initializeGenerator(generator);
        generator.StartGenerator(); 
    }

    protected override void ERROR(string error, string jobID)
    {
        throw new System.NotImplementedException();
    }

    protected override void SATISFIABLE(AnswerSet answerSet, string jobID)
    {
        wallMap.DisplayMap(answerSet, wallMapKey);
        wallMap.AdjustCamera();
        mirrorMap.DisplayMap(answerSet, mirrorMapKey);
        pathMap.DisplayMap(answerSet, pathMapKey);
    }

    protected override void TIMEDOUT(int time, string jobID)
    {
        throw new System.NotImplementedException();
    }

    protected override void UNSATISFIABLE(string jobID)
    {
        throw new System.NotImplementedException();
    }

    

    
}
