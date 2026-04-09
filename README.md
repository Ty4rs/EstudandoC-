# Repositório para os meus estudos de C# e .NET



##ANOTAÇÔES 
</br>
* Para converter uma String para int, eu posso usar o Convert.ToInt32() </br>
* Para dividir duas váriaveis que são inteiras e mostrar um resultado real, eu preciso converter uma das vars para double na hora de dividir:<br/>
    --> double resultado = (double)n1 / n2; </br>
        //esse double converte a váriavel temporariamente.</br>
* Para pular uma linha usa o \n dentro de uma string. </br>
* Posso utilizar o + pra contatenar ou o $: ($"{variavel ou operação}, seja bem vindo!") ou ((variavel ou operação) + ", seja bem vindo!")</br>
* operadores de atribuição: ++, --, +=, *=, /=. </br>
* Operadores relacionais: ==, !=, >, <, >=, <=;</br>
* Operadores lógicos: &&(e), ||(Ou) , !(negação)</br>
* estruturas de repetição:</br>
    //while comum.
    while(true){</br>
        //laço;</br>
        }</br>
        </br>
    //do-while</br>
    do{</br>
    //Faz isso primeiro</br>
    }while(true);</br>
    </br>

    //for</br>
    for(int i=0; i<10; i++){</br>
        //laço;</br>
        }</br>

    //foreach</br>
        foreach(int i in lista){</br>
            Console.WriteLine(i);</br>
        }</br>
        //O foreach percorre uma lista. (((Porém))) o i não é o indice, ele é o item da lista na posição percorrida.

* O Console.WriteLine escreve e pula uma linha </br>
  O Console.Write escreve e não pula</br>
  Console.Write($"{nome4} olá {nome4, 10}"); //o número 10 adiciona 10 de espaço antes da váriavel</br>
