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
    Something winks in the dim light! It's a pebble! #layout:default
    ++ [Pick it up]
        You picked up the pebble.
        -> END
    -> DONE
- else:
    #UPDATE_VAR:pushTimes,1
    You push the brick. It shifts slightly...
    + [Push the wall]
        -> repush
    + [Leave]
        -> END
}