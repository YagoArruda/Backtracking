# Backtracking
Repositorio para estudo de backtracking

***Adendo do problema: esqueci de colocar no arquivo 
 A ideia é que o código seja capaz de encontrar um caminho para chegar uma rua saindo de outra, não é o melhor caminho, mas uma das possibilidades 

(Ignore esse processo se for clonar o repositório do github)
Crie o projeto com: dotnet new console -n backtracking <br>
Entre na pasta com: cd .\backtracking\ <br>
Cole o codigo no arquivo: program.cs <br>
Rode com: dotnet run <br>


Formato entrada (modelo):
Nome dos elementos separado por;
Ex: 1;2;3;4
Em cada linha: nome elemento; com quem se conecta separado por /
Ex: 1;2/3/4


Formato entrada (exemplo):
1;2;3;4;5;6;7;8;9;b
1;4/2
2;5/4/3
3;6
4;7/5/1
5;8/6
6;9
7;8
8;9
9;b


*O resultado vai ser um dos caminhos possíveis, mas não o melhor possivel
