using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGenerator : ASPGenerator
{
    public int width = 20, height = 20;
    public int minMirror45Count = 3, maxMirror45Count = 4, minMirror135Count = 3, maxMirror135Count = 4;


    protected override string getASPCode()
    {
        string aspCode = $@"

            
            write asp here (very awesome).
            
            
        ";
        return aspCode;
    }
    protected override string getAdditionalParameters()
    {

        return $" -c max_width={width} -c max_height={height} -c min_mirror45_count={minMirror45Count}  -c max_mirror45_count={maxMirror45Count}  -c min_mirror135_count={minMirror135Count}  -c max_mirror135_count={maxMirror135Count} " + base.getAdditionalParameters();
    }
}
