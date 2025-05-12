EXTERNAL hasRuby()

--> main

=== main ===

Place item for riddle 3 here:
#UPDATE_VAR:currentInteractingStoneTable,3

{ hasRuby():
    + [Place the Ruby]
        You placed the Ruby on the table. #UPDATE_VAR:placedRuby,true

        -> END
    + [Leave]
        -> END
 - else: 
    + [I don't have the item]
        -> END
}
