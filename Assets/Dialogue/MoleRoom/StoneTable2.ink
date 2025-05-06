EXTERNAL hasTruffle()

--> main

=== main ===
Place item for riddle 2 here: #layout:default
#UPDATE_VAR:currentInteractingStoneTable,2

{ hasTruffle():
    + [Place the Truffle]
        You placed the Truffle on the table.
        #UPDATE_VAR:placedTruffle,true
        -> END
    + [Leave]
    -> END
 - else: 
    + [I don't have the item]
        -> END
}