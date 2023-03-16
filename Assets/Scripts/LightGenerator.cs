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

            width (1..max_width).
            height (1..max_height).

            wall_types({TileTypes.Walls.empty}; {TileTypes.Walls.filled}).
            mirror_types({TileTypes.Appartus.mirror135};{TileTypes.Appartus.mirror45}).
            apparatus_types(Type) :- mirror_types(Type).
            1{{tile(XX,YY,Type) : wall_types(Type)}}1 :- width(XX), height(YY).

            tile(1,YY, {TileTypes.Walls.filled}) :- height(YY).
            tile(max_width,YY, {TileTypes.Walls.filled}) :- height(YY).
            tile(XX,1, {TileTypes.Walls.filled}) :- width(XX).
            tile(XX,max_height, {TileTypes.Walls.filled}) :- width(XX).

            
            1{{mirror(XX,YY,Type)}}1 :- mirror_types(Type), tile(XX+1,YY,{TileTypes.Walls.empty}), tile(XX,YY+1,{TileTypes.Walls.empty}), tile(XX,YY,{TileTypes.Walls.empty}).
            1{{mirror(XX,YY,Type)}}1 :- mirror_types(Type), tile(XX-1,YY,{TileTypes.Walls.empty}), tile(XX,YY+1,{TileTypes.Walls.empty}), tile(XX,YY,{TileTypes.Walls.empty}).
            1{{mirror(XX,YY,Type)}}1 :- mirror_types(Type), tile(XX+1,YY,{TileTypes.Walls.empty}), tile(XX,YY-1,{TileTypes.Walls.empty}), tile(XX,YY,{TileTypes.Walls.empty}).
            1{{mirror(XX,YY,Type)}}1 :- mirror_types(Type), tile(XX-1,YY,{TileTypes.Walls.empty}), tile(XX,YY-1,{TileTypes.Walls.empty}), tile(XX,YY,{TileTypes.Walls.empty}).
            
          
            1{{start(XX,YY): width(XX),height(YY)}}1.
            1{{end(XX,YY): width(XX),height(YY)}}1.
            
            directions(upStart;rightStart;downStart;leftStart).
            1{{apparatus(XX,YY,Direction): directions(Direction)}}1 :- start (XX,YY).

            :- apparatus(XX,YY,upStart), not tile(XX,YY -1, {TileTypes.Walls.filled}).
            :- apparatus(XX,YY,rightStart), not tile(XX -1,YY, {TileTypes.Walls.filled}).
            :- apparatus(XX,YY,downStart), not tile(XX,YY +1, {TileTypes.Walls.filled}).
            :- apparatus(XX,YY,leftStart), not tile(XX+1,YY, {TileTypes.Walls.filled}).

            path(XX,YY,up,0,0) :- apparatus(XX,YY, upStart).
            path(XX,YY,right,0,0) :- apparatus(XX,YY, rightStart).
            path(XX,YY,down,0,0) :- apparatus(XX,YY, downStart).
            path(XX,YY,left,0,0) :- apparatus(XX,YY, leftStart).
            apparatus(XX,YY, acceptor) :- end(XX,YY).

            %% none mirrored paths
            path(XX,YY,left,Count45,Count135) :- path(XX+1,YY,left,Count45,Count135), tile(XX,YY,{TileTypes.Walls.empty}).
            path(XX,YY,right,Count45,Count135) :- path(XX-1,YY,right,Count45,Count135), tile(XX,YY,{TileTypes.Walls.empty}).
            path(XX,YY,down,Count45,Count135) :- path(XX,YY+1,down,Count45,Count135), tile(XX,YY,{TileTypes.Walls.empty}).
            path(XX,YY,up,Count45,Count135) :- path(XX,YY-1,up,Count45,Count135), tile(XX,YY,{TileTypes.Walls.empty}).



            %% 135 mirror path reflections
            path(XX,YY,right,Count45,Count135+1) :- tile(XX,YY,{TileTypes.Walls.empty}), mirror(XX,YY,{TileTypes.Appartus.mirror135}), path(XX,YY+1,down,Count45,Count135), Count135 = (0..max_mirror135_count).
            path(XX,YY,up,Count45,Count135+1) :- tile(XX,YY,{TileTypes.Walls.empty}), mirror(XX,YY,{TileTypes.Appartus.mirror135}), path(XX+1,YY,left,Count45,Count135), Count135 = (0..max_mirror135_count).    
            path(XX,YY,left,Count45,Count135+1) :- tile(XX,YY,{TileTypes.Walls.empty}), mirror(XX,YY,{TileTypes.Appartus.mirror135}), path(XX,YY-1,up,Count45,Count135), Count135 = (0..max_mirror135_count).
            path(XX,YY,down,Count45,Count135+1) :- tile(XX,YY,{TileTypes.Walls.empty}), mirror(XX,YY,{TileTypes.Appartus.mirror135}), path(XX-1,YY,right,Count45,Count135), Count135 = (0..max_mirror135_count).

            %% 45 mirror path relections
            path(XX,YY,right,Count45+1,Count135) :- tile(XX,YY,{TileTypes.Walls.empty}), mirror(XX,YY,{TileTypes.Appartus.mirror45}), path(XX,YY-1,up,Count45,Count135), Count45 = (0..max_mirror45_count).
            path(XX,YY,up,Count45+1,Count135) :- tile(XX,YY,{TileTypes.Walls.empty}), mirror(XX,YY,{TileTypes.Appartus.mirror45}), path(XX-1,YY,right,Count45,Count135), Count45 = (0..max_mirror45_count).
            path(XX,YY,left,Count45+1,Count135) :- tile(XX,YY,{TileTypes.Walls.empty}), mirror(XX,YY,{TileTypes.Appartus.mirror45}), path(XX,YY+1,down,Count45,Count135), Count45 = (0..max_mirror45_count).
            path(XX,YY,down,Count45+1,Count135) :- tile(XX,YY,{TileTypes.Walls.empty}), mirror(XX,YY,{TileTypes.Appartus.mirror45}), path(XX+1,YY,left,Count45,Count135), Count45 = (0..max_mirror45_count).

            

            :- end(XX,YY), tile(XX,YY,{TileTypes.Walls.filled}).
            :- start(XX,YY), tile(XX,YY,{TileTypes.Walls.filled}).

            :- end(XX,YY), mirror(XX,YY,_).
            :- start(XX,YY), mirror(XX,YY,_).


            :- end(XX,YY), path(XX,YY,_,_,Count), Count < min_mirror135_count.
            :- end(XX,YY), path(XX,YY,_,_,Count), Count > max_mirror135_count.

            :- end(XX,YY), path(XX,YY,_,Count45,_), Count45 < min_mirror45_count.
            :- end(XX,YY), path(XX,YY,_,Count45,_), Count45 > max_mirror45_count.
            

            :- end(XX,YY), not path(XX,YY,_,_,_).
            
            directions(up;right;down;left).
            


            :- tile(XX,YY,{TileTypes.Walls.empty}), not path(XX,YY,_,_,_).

            light_path(XX,YY,blue) :- path(XX,YY,_,_,_).
            poi(XX,YY,end) :- end(XX,YY).
            poi(XX,YY,start) :- start(XX,YY).
            
            

            
            
        ";
        return aspCode;
    }
    protected override string getAdditionalParameters()
    {

        return $" -c max_width={width} -c max_height={height} -c min_mirror45_count={minMirror45Count}  -c max_mirror45_count={maxMirror45Count}  -c min_mirror135_count={minMirror135Count}  -c max_mirror135_count={maxMirror135Count} " + base.getAdditionalParameters();
    }
}
