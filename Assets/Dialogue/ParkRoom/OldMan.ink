-->main

===main===

Ah, hello there! Lovely day, isn’t it? 
    +[Greetings]
        Heh! At my age, every good day’s a victory. 
        -> END
    +[How can I get across the road?]
        Across the road? Hmm... gates’re locked tight these days. 
        ++ [How can I unlock the gate?]
            Might need to find yourself a key first. Could’ve sworn I saw one lyin’ around the park somewhere...#UPDATE_VAR:talkedToOldMan,TRUE
            -> END
    +[Nod and leave]
        Off so soon? Well, enjoy the sunshine! 
        -> END