-->main

===main===

Which pokemon do you choose?#speaker:Ms. Yellow #portrait:ms_yellow_neutral #layout:default
    +[Charmander]
        -> chosen("Charmander")
    +[Bulbasaur]
        -> chosen("Bulbasaur")
    +[Squirtle]
        -> chosen("Squirtle")
===chosen(pokemon)===
You chose {pokemon}! #layout:default
-> END