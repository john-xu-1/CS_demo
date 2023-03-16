using System.Collections;
using System.Collections.Generic;
using Clingo;
using UnityEngine;

public class LightGameLevelHandler : ASPLevelHandler
{
    [SerializeField] LightGenerator generator;
    [SerializeField] MapTilemap MapWalls, MapMirrors45, MapMirrors135;
    [SerializeField] MapKeyTileBase MapKeyWalls, MapKeyMirrors45, MapKeyMirrors135;
    [SerializeField] MapGameObject MapApparatus;
    [SerializeField] MapKeyGameObject MapKeyApparatus;

    private void Start()
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
        MapWalls.DisplayMap(answerSet, MapKeyWalls);
        MapWalls.AdjustCamera();
        //MapMirrors45.DisplayMap(answerSet, MapKeyMirrors45);
        //MapMirrors135.DisplayMap(answerSet, MapKeyMirrors135);
        MapApparatus.DisplayMap(answerSet, MapKeyApparatus);
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
