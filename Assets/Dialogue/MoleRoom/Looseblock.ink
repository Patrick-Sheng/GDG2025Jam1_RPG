EXTERNAL wallCracked()

-> main

=== main ===


This brick wobbles when touched. #layout:default
Seems like something is behind it. #layout:default
+ [Push the wall]
    -> repush
+ [Leave]
    -> END 

=== repush ===

{ wallCracked():
    It's a ruby! #layout:default
    ++ [Pick up]
        You picked up the ruby.#UPDATE_VAR:pickedUpRuby,TRUE
        -> END
    -> DONE
- else:
    #UPDATE_VAR:pushTimes,1
    You push the brick. It shifts slightly... 
    You see red glint behind the bricks
    + [Push the wall]
        -> repush
    + [Leave]
        -> END
}