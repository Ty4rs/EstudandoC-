namespace geralAp;
using System;
using System.IO;

public class Files(){
    

    List<string> static carregar(string arquivo){
        if(File.Exists(arquivo)){
            return File.ReadAllLines(arquivo);
        }

    }
}